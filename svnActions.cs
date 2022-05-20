using SharpSvn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Libertas
{
    public class svnActions
    {
        public Dispatcher SVNThread;
        public string log = "";
        public LibertasForm mainForm;
        public int progress;
        public Dispatcher UIThread;
        public SvnClient client;
        private static string selfupdateRepo = "https://svn.code.sf.net/p/ls-fe/libertas/";
        public void Init()
        {
            UIThread = mainForm.UIThread;
        }

        public void setCredentials(SvnClient client,string login, string pass)
        {
            client.Authentication.ForceCredentials(login, pass);
        }

        public void updateChangelog(string url)
        {
            try
            {

                using (client = new SvnClient())
                {
                    client.SvnError += mainForm.Client_SvnError;
                    SVNThread = Dispatcher.CurrentDispatcher;
                    string result = "";
                    System.Collections.ObjectModel.Collection<SvnLogEventArgs> logitems;
                    Uri uri = new Uri(url);
                    //Uri uri = new Uri(getParam(modsList.SelectedItem.ToString(), "SVN_URL"));
                    if (!client.IsCommandRunning) //
                    {
                        SvnInfoEventArgs info;
                        client.GetInfo(uri, out info);
                        client.GetLog(uri, new SvnLogArgs(), out logitems);
                        foreach (SvnLogEventArgs item in logitems)
                        {
                            if (item.LogMessage != "")
                            {
                                result += "Version: " + item.Revision + ", uploaded by: " + item.Author + Environment.NewLine
                                    + "Changelog: " + item.LogMessage + Environment.NewLine + Environment.NewLine;
                            }
                        }
                        log = result;
                        mainForm.upToDate = isUpToDate(new Uri(mainForm.MODURL), mainForm.MODDIR);
                        UIThread.Invoke((Action)(mainForm.TaskCompleted));
                    }
                }
            }
            catch (SharpSvn.SvnSystemException e)
            {
                mainForm.upToDate = false;
                log = "Error connecting to repository: " + e.Message;
                UIThread.Invoke((Action)(mainForm.TaskCompleted));

            }
        }
        public bool isUpToDate(Uri uri, string RepoPath)
        {
            using (client = new SvnClient())
            {
                client.SvnError += mainForm.Client_SvnError;
                Uri workCopyUri = client.GetUriFromWorkingCopy(RepoPath);
                SvnInfoEventArgs infoLocal;
                SvnInfoEventArgs infoRemote;
                long localRev = 0;
                long remoteRev = 0;
                if (workCopyUri != null)
                {
                    localRev = client.GetInfo(RepoPath, out infoLocal) ? infoLocal.Revision : 0;
                }
                remoteRev = client.GetInfo(uri, out infoRemote) ? infoRemote.Revision : 0;
                if (localRev == remoteRev) { return true; } else { return false; }
            }
        }

        public void updateMod(string url)
        {
            updateMod(url, false);
        }

        public void updateMod(string url, bool diffMode)
        {
                using (client = new SvnClient())
                {
                    client.Progress += mainForm.Client_Progress;
                    client.Notify += mainForm.Client_Notify;
                    client.SvnError += mainForm.Client_SvnError;
                    SVNThread = Dispatcher.CurrentDispatcher;
                    Uri uri = new Uri(url + "/");
                    if (!client.IsCommandRunning) //
                    {
                        SvnInfoEventArgs info;
                        client.GetInfo(uri, out info);
                        var workUri = client.GetUriFromWorkingCopy(mainForm.MODDIR);
                        if (Directory.Exists(mainForm.MODDIR))
                        {
                            //  First we check if the target is empty, then its all simple
                            if (workUri == null) {
                            try
                            {
                                svnFullCheckout(uri, mainForm.MODDIR);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    svnCleanup(uri, mainForm.MODDIR);
                                    svnFullCheckout(uri, mainForm.MODDIR);
                                }
                                catch (Exception)
                                {

                                    throw;
                                }
                            } }
                            else
                            {
                                //  Then we check if it exists and its the correct one, still simple
                                if (workUri == uri)
                                {
                                    svnCleanup(uri, mainForm.MODDIR);
                                    svnUpdate(uri, mainForm.MODDIR,diffMode);
                                }
                                else
                                //  If it exists, but is wrong, then we're in trouble
                                if (workUri != uri)
                                {
                                    Directory.Delete(Path.Combine(mainForm.MODDIR, ".svn"));
                                    svnFullCheckout(uri, mainForm.MODDIR);
                                }
                            }

                        }
                    }
                    mainForm.upToDate = isUpToDate(new Uri(mainForm.MODURL), mainForm.MODDIR);

                }
            


        }

        private void svnFullCheckout(Uri uri, string RepoPath)
        {
            string SourcePath = RepoPath;
            string DestinationPath = Libertas.Properties.Settings.Default.GameDirectory;
            using (client = new SvnClient())
            {
                client.CheckOut(uri, RepoPath);
            }
            installMod(SourcePath);
        }

        private void svnUpdate(Uri uri, string RepoPath)
        {
            svnUpdate(uri, RepoPath, false);
        }

        private void svnUpdate(Uri uri, string RepoPath,bool diffMode)
        {
            string SourcePath = RepoPath;
            string DestinationPath = Libertas.Properties.Settings.Default.GameDirectory;
            using (client = new SvnClient())
            {
                client.CleanUp(RepoPath);
                client.Update(RepoPath);
            }
            installMod(SourcePath,diffMode);
        }

        public void installMod(string SourcePath)
        {
            installMod(SourcePath, false);
        }

        public void installMod(string SourcePath, bool diffMode)
        {
            string DestinationPath = Libertas.Properties.Settings.Default.GameDirectory;
            //Now Create all of the directories
            
            List<String> sourceDirectories = Directory.GetDirectories(SourcePath, "*", SearchOption.AllDirectories).ToList<string>();
            List<String> targetDirectories = new List<string>(sourceDirectories);

            for (int i = 0; i < sourceDirectories.Count; i++)
            {
                try
                {
                    targetDirectories[i] = sourceDirectories[i].Replace(SourcePath, DestinationPath);
                }
                catch (Exception e)
                {
                    e.Source = "Error while creating directory "+ targetDirectories[i] + " from " + sourceDirectories[i]+ " Error Source: " + e.Source;
                    throw;
                }
            }

            string modFolder = Path.Combine(DestinationPath,mainForm.curModName.ToLowerInvariant());
            if (Directory.Exists(modFolder))
            {
                List<string> modFiles = Directory.GetFiles(modFolder, "*.*", SearchOption.AllDirectories).ToList<string>();
                List<string> svnFiles = Directory.GetFiles(mainForm.MODDIR, "*.*", SearchOption.AllDirectories).ToList<string>();
                List<string> newModFiles = new List<string>(modFiles);
                List<string> newSvnFiles = new List<string>(svnFiles);
                foreach (string file in modFiles)
                {
                    if (file.Contains(".svn"))
                    {
                        newModFiles.Remove(file);
                    }
                }
                modFiles = new List<string>(newModFiles);
                foreach (string file in svnFiles)
                {
                    if (file.Contains(".svn"))
                    {
                        newSvnFiles.Remove(file);
                    }
                }
                svnFiles = new List<string>(newSvnFiles);
                newModFiles = new List<string>(modFiles);

                foreach (string existingFile in modFiles)
                {
                    string newpath = existingFile.Replace(modFolder, Path.Combine(SourcePath, mainForm.curModName.ToLowerInvariant()));
                    if (!svnFiles.Contains(newpath))
                    {
                        fileOperationDelete(existingFile, DestinationPath);
                    }
                }
                modFiles = new List<string>(newModFiles);
            }
            foreach (string dirPath in targetDirectories)
            {
                if (!dirPath.Contains(".svn") && !Directory.Exists(dirPath))
                    Directory.CreateDirectory(dirPath.Replace(SourcePath, DestinationPath));
            }
            string[] repoFiles = Directory.GetFiles(SourcePath, "*.*",
                SearchOption.AllDirectories);

            //Copy all the files & Replaces any files with the same name
            foreach (string filePathname in repoFiles)
            {
                string targetPathname = filePathname.Replace(SourcePath, DestinationPath);
                if (!filePathname.Contains(".svn"))
                {
                        if (diffMode == true)
                        {
                            if (File.Exists(targetPathname) && File.Exists(filePathname))
                            {
                                if (File.GetLastWriteTimeUtc(filePathname) != File.GetLastWriteTimeUtc(targetPathname))
                                {
                                    fileOperation(filePathname, targetPathname, DestinationPath, "copy");
                                }
                            }
                            else if (File.Exists(targetPathname) && !File.Exists(filePathname))
                            {
                            }
                            else
                            {
                                fileOperation(filePathname, targetPathname, DestinationPath, "add");
                            }
                        }
                        else
                        {
                            fileOperation(filePathname, targetPathname, DestinationPath, "copy");
                        }
                }
            }

            foreach (string ucs in Directory.GetFiles(SourcePath, "*.ucs", SearchOption.AllDirectories))
            {
                foreach (string folder in Directory.GetDirectories(Path.Combine(new string[] { DestinationPath, "GameAssets", "Locale" })))
                {
                    File.Copy(ucs, Path.Combine(folder, Path.GetFileName(ucs)), true);
                }
            }
        }

        private void fileOperationDelete(string targetPathname, string DestinationPath)
        {
            fileOperation(null, targetPathname, DestinationPath, "delete");
        }

        private void fileOperation(string filePathname, string targetPathname,string operation)
        {
            fileOperation(filePathname, targetPathname, null, operation);
        }
        private void fileOperation(string filePathname,string targetPathname, string DestinationPath,string operation)
        {
            try
            {
                switch (operation.ToLower())
                {
                    case "copy":
                        Delimon.Win32.IO.File.Copy(filePathname, targetPathname, true);
                        logFileAction(operation, targetPathname, DestinationPath);
                        break;
                    case "delete":
                        Delimon.Win32.IO.File.Delete(targetPathname);
                        logFileAction(operation, targetPathname, DestinationPath);
                        break;
                    case "add":
                        Delimon.Win32.IO.File.Copy(filePathname, targetPathname, true);
                        logFileAction(operation, targetPathname, DestinationPath);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                string exceptionText = "Exception during file operation, type \"{0}\", TargetPathname: \"{1}\", filePathname: \"{2}\" " + Environment.NewLine;
                Exception exception = new Exception(String.Format(exceptionText,operation,targetPathname,filePathname), e);
                throw exception;
            }
        }

        public void logFileAction(string operation, string targetPathname)
        {
            logFileAction(operation, targetPathname, null);
        }
        public void logFileAction(string operation,string targetPathname,string DestinationPath)
        {
            string textAppend = "";
            string writeText = "";
            switch (operation.ToLower())
            {
                case "copy":
                    textAppend = "Updated ";
                    break;
                case "delete":
                    textAppend = "Deleted ";
                    break;
                case "add":
                    textAppend = "Added ";
                    break;
                default:
                    break;
            }
            if (targetPathname[0] == '\\') { targetPathname=targetPathname.Substring(1); }
            if (DestinationPath != null)
            {
                writeText = textAppend + targetPathname.Replace(DestinationPath, "");
            }
            else
            {
                writeText = textAppend + targetPathname;
            }
            UIThread.Invoke((Action)(() => mainForm.writeLogLine(writeText)));
        }
        
        public void svnCleanup(Uri uri, string RepoPath)
        {
            using (client = new SvnClient())
            {
                client.CleanUp(RepoPath);
            }
        }

        private static void CombineMultipleFilesIntoSingleFile(string inputDirectoryPath, string inputFileNamePattern, string outputFilePath)
        {
            string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
            Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
            using (var outputStream = File.Create(outputFilePath))
            {
                foreach (var inputFilePath in inputFilePaths)
                {
                    using (var inputStream = File.OpenRead(inputFilePath))
                    {
                        // Buffer size can be passed as the second argument.
                        inputStream.CopyTo(outputStream);
                    }
                    Console.WriteLine("The file {0} has been processed.", inputFilePath);
                }
            }
        }
        public bool checkSelfUpdates()
        {
            using (client = new SvnClient())
            {
                //client.SvnError += mainForm.Client_SvnError;
                Uri workCopyUri = new Uri(selfupdateRepo);
                SvnInfoEventArgs infoLocal;
                SvnInfoEventArgs infoRemote;
                long localRev = 0;
                long remoteRev = 0;
                if (workCopyUri != null)
                {
                    localRev = client.GetInfo(Directory.GetCurrentDirectory(), out infoLocal) ? infoLocal.Revision : 0;
                }
                remoteRev = client.GetInfo(workCopyUri, out infoRemote) ? infoRemote.Revision : 0;
                if (localRev == remoteRev) { return true; } else { return false; }
            }
        }

        public void svnSelfCheckout()
        {
            ProcessStartInfo ProcessInfo = new ProcessStartInfo(Directory.GetCurrentDirectory() + "updatelauncher.bat");
            Process Process = Process.Start(ProcessInfo);
        }
    }
}

