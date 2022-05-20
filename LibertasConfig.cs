using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libertas.Properties;
using System.Configuration;
using System.Reflection;
using Microsoft.Win32;
using System.IO;

namespace Libertas
{
    public partial class LibertasConfig : Form
    {

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private LibertasForm mainForm;

        private void showConfDescription(Label lbl, string name)
        {
            switch (name)
            {
                case "LaunchURL":
                    lbl.Text = "Launch the URL specified in the mod config, along with your game.For example, it could be a Steam Group chatroom";
                    break;
                case "GameDirectory":
                    lbl.Text = "Your Dawn of War II - Retribution directory";
                    break;
                case "LBModDirectory":
                    lbl.Text = "The directory into which your .lbmod files will go";
                    break;
                case "UpdateAuto":
                    lbl.Text = "Automatically update the mod when the launcher starts. If set to False, the mod will update only when you click Play";
                    break;
                case "Troubleshooting":
                    lbl.Text = "Various options for fixing various unexpected bugs. It is adviced you use those only if you really know what you are doing.";
                    break;
                default:
                    lbl.Text = "No description";
                    break;
                }
        }

        private void setByName(string name, string value)
        {
            switch (name)
            {
                case "LaunchURL":
                    Settings.Default.LaunchURL = Convert.ToBoolean(value);
                    break;
                case "GameDirectory":
                    Settings.Default.GameDirectory = value;
                    break;
                case "UpdateAuto":
                    Settings.Default.UpdateAuto = Convert.ToBoolean(value) ;
                    break;
                default:
                    break;
            }
        }


        private string getByName(string name)
        {
            switch (name)
            {
                case "LaunchURL":
                    return Settings.Default.LaunchURL.ToString();
                case "GameDirectory":
                    return Settings.Default.GameDirectory;
                case "UpdateAuto":
                    return Settings.Default.UpdateAuto.ToString();
                case "DefaultMod":
                    return Settings.Default.DefaultMod;
                default:
                    return "Settings not found by name";
            }
        }

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

        public LibertasConfig(LibertasForm prnt)
        {
            InitializeComponent();
            mainForm = prnt;
        }

        public void PositionForm()
        {
            Point loc = mainForm.Location;
            Size siz = mainForm.Size;
            Point math = new Point(loc.X + ((siz.Width - this.Width) / 2), loc.Y + ((siz.Height - this.Height) / 2));
            this.Location = math;
        }

        public void buildConfigList()
        {
            foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
            {
                if (!currentProperty.IsReadOnly && currentProperty.Name != "DefaultMod")
                {
                    ConfigList.Items.Add(currentProperty.Name);
                }
            }

            ConfigList.Items.Add("Troubleshooting");

            Properties.Settings.Default.Save();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ((LibertasConfig)this).Close();
        }

        private SettingsProperty getSetByName(string name)
        {

            SettingsProperty param = (SettingsProperty)Settings.Default.Properties[name];
            return param;
        }
        

        private void revealControls(string listName)
        {
            if (listName == "Troubleshooting")
            {
                bool_Combo.Hide();
                Bool_Label.Hide();
                if (mainForm.curModName == "DOW2Retribution")
                {
                    button_cleanup.Show();
                    button_redownload.Show();
                    //button_reinstall.Show();
                    showConfDescription(settingComment, listName);
                }
            }
            else
            {
                bool_Combo.Show();
                Bool_Label.Show();
                button_cleanup.Hide();
                button_redownload.Hide();
                button_reinstall.Hide();
                SettingsProperty param = getSetByName(listName);
                showConfDescription(settingComment, listName);
                switch (param.PropertyType.Name)
                {
                    case ("Boolean"):
                        bool_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
                        bool_Combo.Items.Clear();
                        bool_Combo.Items.Add("True");
                        bool_Combo.Items.Add("False");
                        bool_Combo.Text = getByName(listName);
                        break;
                    case ("String"):
                        bool_Combo.DropDownStyle = ComboBoxStyle.Simple;
                        bool_Combo.Items.Clear();
                        bool_Combo.Items.Add(param.DefaultValue.ToString());
                        bool_Combo.Text = getByName(listName);
                        break;
                    default:
                        break;
                }
                if (listName == "GameDirectory")
                {
                    ButtonDetect.Show();
                    ButtonBrowse.Show();
                }
                else { ButtonDetect.Hide(); ButtonBrowse.Hide(); }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PositionForm();
            buildConfigList();
            ConfigList.SelectedItem = ConfigList.Items[0] ;
            if (ConfigList.SelectedItem.ToString() == "GameDirectory")
            {

            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ConfigList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = ConfigList;
            revealControls(list.SelectedItem.ToString());
            setByName(list.SelectedItem.ToString(), bool_Combo.Text);
        }

        private void Bool_Label_Click(object sender, EventArgs e)
        {

        }

        private void bool_Combo_Leave(object sender, EventArgs e)
        {
            var list = ConfigList;
            setByName(list.SelectedItem.ToString(), bool_Combo.Text);
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void bool_Combo_SelectedIndexChanged(object sender, EventArgs e)
        {

            var list = ConfigList;
            setByName(list.SelectedItem.ToString(), bool_Combo.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool_Combo.Text = registryDetect();
            var list = ConfigList;
            setByName(list.SelectedItem.ToString(), bool_Combo.Text);

        }

        public string registryDetect()
        {
            string autopath = Path.Combine(new string[] { Registry.GetValue("HKEY_CURRENT_USER\\Software\\Valve\\Steam", "SteamPath", null).ToString().Replace('/', '\\'), "steamapps", "common", "Dawn of War II - Retribution" });
            if (!File.Exists(Path.Combine(autopath, "DOW2.exe")))
            {
                DialogResult box = MessageBox.Show("Cannot autodetect the file. This could be because your game is not installed in your main Steam directory. Autodetect currently does not support other steam Libraries. Do you want to set up your directory manually right now?",
                "Autodetect failed",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Error // for Warning  
                                       //MessageBoxIcon.Error // for Error 
                                       //MessageBoxIcon.Information  // for Information
                                       //MessageBoxIcon.Question // for Question
                                       );
                if (box.ToString() == "Yes")
                {

                    using (FolderBrowserDialog browse = new FolderBrowserDialog())
                    {
                        browse.ShowNewFolderButton = false;
                        browse.ShowDialog();
                        autopath = browse.SelectedPath;
                    }
                }
                else { return null; }
            }
            return autopath;
        }

        private void ButtonBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog browse = new FolderBrowserDialog())
            {
                browse.ShowNewFolderButton = false;
                browse.ShowDialog();
                bool_Combo.Text = browse.SelectedPath;
            }
        }

        private void button_cleanup_Click(object sender, EventArgs e)
        {
            mainForm.SVN.svnCleanup(new Uri(mainForm.MODURL), mainForm.MODDIR);
            DialogResult box = MessageBox.Show("Cleanup finished",
            "Troubleshooting",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information // for Warning  
                                 //MessageBoxIcon.Error // for Error 
                                 //MessageBoxIcon.Information  // for Information
                                 //MessageBoxIcon.Question // for Question
                                   );
        }

        private void button_reinstall_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(mainForm.MODDIR))
            {

            }
            else
            {
                DialogResult box = MessageBox.Show("Unable to delete mod, folder "+Environment.NewLine+mainForm.MODDIR+Environment.NewLine+"Not found",
               "Troubleshooting",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error // for Warning  
                                          //MessageBoxIcon.Error // for Error 
                                          //MessageBoxIcon.Information  // for Information
                                          //MessageBoxIcon.Question // for Question
                                      );
            }
        }

        private void button_redownload_Click(object sender, EventArgs e)
        {
            DialogResult box = MessageBox.Show("This will delete all the files in the mod directory,but leave the mod in your game directory untouched." +
                Environment.NewLine +
                "The following folder will be deleted: " +
                Environment.NewLine + mainForm.MODDIR +
                Environment.NewLine + "Are you sure you want to continue?",
            "Troubleshooting",
            MessageBoxButtons.OKCancel,
            MessageBoxIcon.Warning // for Warning  
                                       //MessageBoxIcon.Error // for Error 
                                       //MessageBoxIcon.Information  // for Information
                                       //MessageBoxIcon.Question // for Question
                                   );

            if (box.ToString() == "OK")
            {
                try
                {
                    Directory.Delete(mainForm.MODDIR, true);

                    DialogResult box2 = MessageBox.Show("Folder " + mainForm.MODDIR + " has been deleted",
                    "Troubleshooting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information // for Warning  
                                               //MessageBoxIcon.Error // for Error 
                                               //MessageBoxIcon.Information  // for Information
                                               //MessageBoxIcon.Question // for Question
                                           );
                }
                catch (Exception exc)
                {

                    DialogResult box2 = MessageBox.Show("Folder " + mainForm.MODDIR + " has been deleted, but there was an error in progress. Error was:"+Environment.NewLine+exc.Message,
                    "Troubleshooting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information // for Warning  
                                               //MessageBoxIcon.Error // for Error 
                                               //MessageBoxIcon.Information  // for Information
                                               //MessageBoxIcon.Question // for Question
                                           );
                }
            }

        }

        private void bool_Combo_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
