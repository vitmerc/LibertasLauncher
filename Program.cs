using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Libertas
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LibertasForm());
            }
            catch (Exception e)
            {
                string logpathname = Path.Combine(Directory.GetCurrentDirectory(), "logfile.txt");
                if (File.Exists(logpathname))
                {
                    try
                    {
                        File.Delete(logpathname);
                    }
                    catch (Exception)
                    {
                    }
                }
                try
                {
                    File.WriteAllText(logpathname, e.Source + " " + e.Message + " " + e.StackTrace);
                }
                catch (Exception)
                {
                }
                throw e;
            }
        }
    }
}
