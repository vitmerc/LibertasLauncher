using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpSvn;
using System.IO;
using System.Windows.Threading;
using System.Threading;
using System.Net;


namespace Libertas
{

    public partial class LibertasForm : Form
    {
        private bool dragging = false;
        public SvnProgressEventArgs ev;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Dispatcher UIThread;
        public svnActions SVN;
        public LibertasConfig ConfigWindow;
        public LibertasParser parser;
        public SvnClient client = new SvnClient();
        public bool upToDate = false;
        public Image background;
        public string curModName;
        public string[] validParams = new string[] {
   "ModuleName",
   "Author",
   "Description",
   "CommunityURL",
   "SVN_URL",
   "SVN_Login",
   "SVN_Password",
   "PlayURL",
   "BackgroundImage",
   "LaunchParameters",
   "DiffFileCopy"
  };
        public bool diffMode = false;
        public string[] currentModLines;
        private string _changelog;
        public string changelog
        {
            get
            {
                return _changelog;
            }
            set
            {
                _changelog = value;
            }
        }
        public string MODURL;
        public string MODDIR;

        public void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        public void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                sender = ((PictureBox)sender).FindForm();
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        public void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        public LibertasForm()
        {
            UIThread = Dispatcher.CurrentDispatcher;
            InitializeComponent();
            SVN = new svnActions();
            parser = new LibertasParser();
            SVN.mainForm = this;
            parser.mainForm = this;
            SVN.Init();
            tabControl.TabPages.Remove(tabUpdate);
            try
            {
                if (SVN.checkSelfUpdates() != true)
                {

                    DialogResult box = MessageBox.Show("Updates for the launcher are available. Do you want to update it?",
                    "Updates available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information // for Warning  
                                               //MessageBoxIcon.Error // for Error 
                                               //MessageBoxIcon.Information  // for Information
                                               //MessageBoxIcon.Question // for Question
                                           );
                    if (box.ToString() == "Yes")
                    {
                        System.Diagnostics.Process.Start("https://sourceforge.net/projects/libertaslauncher/files/latest/download?source=files");
                        Environment.Exit(1);
                    }
                }
            }
            catch (Exception e) { Exception e2 = e; }

            if (!File.Exists(Path.Combine(Properties.Settings.Default.GameDirectory, "DOW2.EXE")))
            {

                DialogResult box = MessageBox.Show("The current path for Game Directory is probably invalid, could not find DOW2.EXE in there. Would you like to autodetect it?",
                "Retribution not found",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning // for Warning  
                                       //MessageBoxIcon.Error // for Error 
                                       //MessageBoxIcon.Information  // for Information
                                       //MessageBoxIcon.Question // for Question
                                       );
                if (box.ToString()=="Yes")
                {
                    using (LibertasConfig config = new LibertasConfig(this))
                    {
                            string result = config.registryDetect();
                        if (result != null)
                        {
                            Properties.Settings.Default.GameDirectory = result;
                        }
                        Properties.Settings.Default.Save();
                    }
                }
            }
            
            }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            parser.loadMods();
            if (modsList.Items.Count > 0)
            {
                modsList.Sorted = true;
                if (modsList.Items.Contains(Properties.Settings.Default.DefaultMod))
                {
                    modsList.SelectedItem = 
            Properties.Settings.Default.DefaultMod;
                }
                else
                {
                    modsList.SelectedItem = modsList.Items[0];
                }
            }
            if (isSiteValid(parser.getModParam(curModName, "CommunityURL")) && !tabControl.TabPages.Contains(NewsTab))
            {
                tabControl.TabPages.Add(NewsTab);
                newsBrowser.Url = new Uri(parser.getModParam(curModName, "CommunityURL"));
            }
            else
            {
                tabControl.TabPages.Remove(NewsTab);
            }

        }

        private void checkoutMod(string uri, int revision) { }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
                upToDate = false;
            changelogBox.Text = "Please wait. Loading changelog...";
            curModName = modsList.SelectedItem.ToString();
                Properties.Settings.Default.DefaultMod = modsList.SelectedItem.ToString() ;
            Properties.Settings.Default.Save();
            MODDIR = Path.Combine(new string[] { Directory.GetCurrentDirectory(),"Mods",curModName });
            if (tabControl.TabPages.Contains(tabUpdate))
            {
                tabControl.TabPages.Remove(tabUpdate);
                tabUpdate.Text = "";
            }
            modsList.Enabled = false;
            btn_play.Enabled = false;
            currentModLines = parser.parseLBMod(modsList.SelectedItem.ToString());
            MODURL = parser.getModParam(modsList.SelectedItem.ToString(), "SVN_URL");
            if (isSiteValid(parser.getModParam(curModName,"CommunityURL")))
            {
                if (!tabControl.TabPages.Contains(NewsTab))
                {
                    tabControl.TabPages.Add(NewsTab);
                    newsBrowser.Url = new Uri(parser.getModParam(curModName, "CommunityURL"));
                }
            }
            else
            {
                tabControl.TabPages.Remove(NewsTab);
            }
            //background = parser.Base64ToImage(parser.getModParam(curModName, "BackgroundImage"));
            pictureBox3.ImageLocation = Path.Combine(MODDIR, "background.png");
            if (curModName != "DOW2Retribution"&& !(MODURL==null||MODURL==""))
            {
                if (!tabControl.TabPages.Contains(tabMOTD))
                {
                    tabControl.TabPages.Add(tabMOTD);
                }
                Action act = new Action(onUpdateChangelog);
                Task.Factory.StartNew(act,
    CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
            }
            else
            {
                tabControl.TabPages.Remove(tabMOTD);
                upToDate = true;
                updateButtons();
                btn_play.Enabled = true;
                modsList.Enabled = true;

            }
        }

        public void TaskCompleted()
        {
            setUIText(changelogBox, SVN.log);
            modsList.Enabled = true;
            btn_play.Enabled = true;
            //updateButtons();
            btn_play.Text = "Update";
            if (tabControl.TabPages.Contains(NewsTab)&&tabControl.SelectedTab == tabLogo)
            {

                tabControl.SelectedTab=NewsTab;
            }
            if (Properties.Settings.Default.UpdateAuto)
            {
                Action act = new Action(() =>
                {
                    if (btn_play.Text == "Update")
                    {
                         btn_play_Click(this, null);
                    }
                });
                Dispatcher.CurrentDispatcher.Invoke(act);
            }
        }

        public void setUI(string name,object[] values)
        {
            if (values.Length > 0)
            {
                switch (name)
                {
                    case "modsList":
                        setUIText(this.modsList, values);
                        break;
                    case "changelogBox":
                        setUIText(this.changelogBox, values[0].ToString());
                        break;
                    case "progressBar":
                        if (values[0].GetType().ToString() == "Int32")
                        {
                            setUIText(this.progressBar, (int)values[0]);
                        }
                        else
                        {
                            Console.WriteLine("Trying to set progressBar to something that is not a percent");
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void setUIText(RichTextBox element,string text)
        {
            element.Text = text;
        }

        private void setUIText(TextBox element, string text)
        {
            element.Text = text;
        }

        private void setUIText(ListBox element, object[] items)
        {
            foreach (object item in items)
            {
                element.Items.Add(item);
            }
        }

        private void setUIText(ProgressBar bar, int percent)
        {
            bar.Value = percent;
        }

        private void onUpdateChangelog()
        {
            SVN.updateChangelog(MODURL);
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (btn_play.Text == "Update")
            {
                if (!tabControl.TabPages.Contains(tabUpdate))
                {
                    tabControl.TabPages.Add(tabUpdate);
                }
                tabControl.SelectedTab = tabUpdate;
                downloadTextBox.Text = "Please wait. Your mod is currently being updated or downloaded." + Environment.NewLine + "Do not close this window until the \"Play\" button is available again." + Environment.NewLine;
                modsList.Enabled = false;
                btn_play.Enabled = false;
                progressBar.Style = ProgressBarStyle.Marquee;

                Action act = new Action(updateMod);
                Task.Factory.StartNew(act,
    CancellationToken.None, TaskCreationOptions.PreferFairness, TaskScheduler.Default);
            }
            else
            {
                if (Properties.Settings.Default.LaunchURL)
                {
                    if (!String.IsNullOrEmpty(parser.getModParam(curModName, "PlayURL")))
                        System.Diagnostics.Process.Start(parser.getModParam(curModName,"PlayURL"));
                }
                string aParams = parser.getModParam(curModName, "LaunchParameters");
                string cParams = "-modname "+parser.getModParam(curModName,"ModuleName")+" "+aParams ;
                string filename = Path.Combine(Libertas.Properties.Settings.Default.GameDirectory, "DOW2.exe");
                if (File.Exists(filename))
                {
                    var proc = System.Diagnostics.Process.Start(filename, cParams);
                } else
                {
                    DialogResult box = MessageBox.Show("DOW2.exe not found. Check your target directory in Launcher Configuration",
                    "Cannot start game",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error // for Warning  
                                         //MessageBoxIcon.Error // for Error 
                                         //MessageBoxIcon.Information  // for Information
                                         //MessageBoxIcon.Question // for Question
                                           );
                }
            }
        }

        public void Client_Progress(object sender, SvnProgressEventArgs e)
        {
            SvnProgressEventArgs ev = e;
        //    progressBar.Value = Convert.ToInt32((ev.Progress / ev.TotalProgress) * 100);
            UIThread.Invoke((Action)(() => SVN.mainForm.downloadTextBox.AppendText( " . ")));


        }

        public void writeLogLine(string line)
        {
            UIThread.Invoke((Action)(() => SVN.mainForm.downloadTextBox.AppendText(Environment.NewLine+line)));
        }

        public void Client_Notify(object sender, SvnNotifyEventArgs e)
        {
            UIThread.Invoke((Action)(() => SVN.mainForm.downloadTextBox.Text += Environment.NewLine + e.Action + " // " + e.ContentState));
        }

        public void Client_SvnError(object sender, SvnErrorEventArgs e)
        {
            //UIThread.Invoke(() => SVN.mainForm.downloadTextBox.Text += Environment.NewLine + e.Exception.ToString() + " // " + e.Cancel.ToString());
        }


        //{
        //  progressBar.Value = Convert.ToInt32((ev.Progress / ev.TotalProgress) * 100);
        //};

        private void updateMod()
        {
            updateMod(false);
        }

        private void updateMod(bool diffMode)
        {
            diffMode = true;
            if (parser.getModParam(curModName, "DiffFileCopy")=="false")
            {
                diffMode = false;
            }
            
            if (MODURL!=null && MODURL!="")
            try
            {
                if (!Directory.Exists(MODDIR)) { Directory.CreateDirectory(MODDIR); }
                SVN.updateMod(MODURL,diffMode);
                UIThread.Invoke((Action)modUpdated);
            }
            catch (SharpSvn.SvnException e)
            {
                upToDate = false;
                UIThread.Invoke((Action)(() => {
                    progressBar.Style = ProgressBarStyle.Blocks;
                    modsList.Enabled = true;
                    btn_play.Enabled = true;
                    SVN.mainForm.downloadTextBox.Text += Environment.NewLine + "Unable to update, SVN Error: " + e.Message;
                }));
            }
            catch (Exception e)
            {
                upToDate = false;
                progressBar.Style = ProgressBarStyle.Blocks;
                UIThread.Invoke((Action)(() => {
                    progressBar.Style = ProgressBarStyle.Blocks;
                    modsList.Enabled = true;
                    btn_play.Enabled = true;
                    SVN.mainForm.downloadTextBox.Text += Environment.NewLine + "Unable to update, General Error Source: " + e.Source + ", Message: " + e.Message + e.StackTrace;
                }));
            }
        
        }

        private void updateButtons()
        {
            this.progressBar.Style = ProgressBarStyle.Blocks;
            if (!upToDate) { btn_play.Text = "Update"; }
            else {
                btn_play.Text = "PLAY";
            };
        }

        private void modUpdated()
        {
            btn_play.Enabled = true;
            modsList.Enabled = true;
            downloadTextBox.AppendText(Environment.NewLine + Environment.NewLine +  "Done!");
            updateButtons();
        }

        private bool isSiteValid(string url)
        {
            try
            {

                using (var client = new MyClient())
                {
                    client.HeadOnly = true;
                    // fine, no content downloaded
                    string s1 = null;
                    s1 = client.DownloadString(url);
                    if (s1 != null) return true; else return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void btnConfig_Click(object sender, EventArgs e)
        {
            using (ConfigWindow = new LibertasConfig(this))
            {
                ConfigWindow.ShowDialog();
            }



        }

        private void downloadTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }

    class MyClient : WebClient
    {
        public bool HeadOnly { get; set; }
        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest req = base.GetWebRequest(address);
            if (HeadOnly && req.Method == "GET")
            {
                req.Method = "HEAD";
            }
            return req;
        }
    }

}