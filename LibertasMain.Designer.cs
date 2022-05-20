namespace Libertas
{
    partial class LibertasForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibertasForm));
            this.btn_play = new System.Windows.Forms.Button();
            this.changelogBox = new System.Windows.Forms.RichTextBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnAddMod = new System.Windows.Forms.Button();
            this.modsList = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabMOTD = new System.Windows.Forms.TabPage();
            this.tabLogo = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.NewsTab = new System.Windows.Forms.TabPage();
            this.newsBrowser = new System.Windows.Forms.WebBrowser();
            this.tabUpdate = new System.Windows.Forms.TabPage();
            this.downloadTextBox = new System.Windows.Forms.RichTextBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabMOTD.SuspendLayout();
            this.tabLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabControl.SuspendLayout();
            this.NewsTab.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_play.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_play.Location = new System.Drawing.Point(621, 336);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(169, 33);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "PLAY";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // changelogBox
            // 
            this.changelogBox.Location = new System.Drawing.Point(2, 2);
            this.changelogBox.Name = "changelogBox";
            this.changelogBox.ReadOnly = true;
            this.changelogBox.Size = new System.Drawing.Size(589, 251);
            this.changelogBox.TabIndex = 0;
            this.changelogBox.Text = "";
            // 
            // btnConfig
            // 
            this.btnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfig.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnConfig.Location = new System.Drawing.Point(621, 297);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(169, 33);
            this.btnConfig.TabIndex = 2;
            this.btnConfig.Text = "Configure Launcher";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 336);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(603, 33);
            this.progressBar.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Libertas.Properties.Resources.stone_2_1;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(808, 36);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Libertas.Properties.Resources.button_close_over_1;
            this.btnClose.Location = new System.Drawing.Point(765, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddMod
            // 
            this.btnAddMod.Enabled = false;
            this.btnAddMod.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddMod.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddMod.Location = new System.Drawing.Point(621, 258);
            this.btnAddMod.Name = "btnAddMod";
            this.btnAddMod.Size = new System.Drawing.Size(169, 33);
            this.btnAddMod.TabIndex = 7;
            this.btnAddMod.Text = "Add a Mod";
            this.btnAddMod.UseVisualStyleBackColor = true;
            // 
            // modsList
            // 
            this.modsList.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.modsList.FormattingEnabled = true;
            this.modsList.ItemHeight = 22;
            this.modsList.Location = new System.Drawing.Point(621, 66);
            this.modsList.Name = "modsList";
            this.modsList.Size = new System.Drawing.Size(169, 180);
            this.modsList.TabIndex = 8;
            this.modsList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Image = global::Libertas.Properties.Resources.libertas;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(325, 36);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            // 
            // tabMOTD
            // 
            this.tabMOTD.BackColor = System.Drawing.Color.Gray;
            this.tabMOTD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabMOTD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabMOTD.CausesValidation = false;
            this.tabMOTD.Controls.Add(this.changelogBox);
            this.tabMOTD.Location = new System.Drawing.Point(4, 30);
            this.tabMOTD.Name = "tabMOTD";
            this.tabMOTD.Padding = new System.Windows.Forms.Padding(3);
            this.tabMOTD.Size = new System.Drawing.Size(595, 254);
            this.tabMOTD.TabIndex = 1;
            this.tabMOTD.Text = "Changelog";
            // 
            // tabLogo
            // 
            this.tabLogo.CausesValidation = false;
            this.tabLogo.Controls.Add(this.pictureBox3);
            this.tabLogo.Location = new System.Drawing.Point(4, 30);
            this.tabLogo.Name = "tabLogo";
            this.tabLogo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogo.Size = new System.Drawing.Size(595, 254);
            this.tabLogo.TabIndex = 0;
            this.tabLogo.Text = "Title Screen";
            this.tabLogo.UseVisualStyleBackColor = true;
            this.tabLogo.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(595, 254);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabLogo);
            this.tabControl.Controls.Add(this.NewsTab);
            this.tabControl.Controls.Add(this.tabMOTD);
            this.tabControl.Controls.Add(this.tabUpdate);
            this.tabControl.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl.Location = new System.Drawing.Point(12, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(603, 288);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            // 
            // NewsTab
            // 
            this.NewsTab.Controls.Add(this.newsBrowser);
            this.NewsTab.Location = new System.Drawing.Point(4, 30);
            this.NewsTab.Name = "NewsTab";
            this.NewsTab.Padding = new System.Windows.Forms.Padding(3);
            this.NewsTab.Size = new System.Drawing.Size(595, 254);
            this.NewsTab.TabIndex = 3;
            this.NewsTab.Text = "Community";
            this.NewsTab.UseVisualStyleBackColor = true;
            // 
            // newsBrowser
            // 
            this.newsBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsBrowser.IsWebBrowserContextMenuEnabled = false;
            this.newsBrowser.Location = new System.Drawing.Point(3, 3);
            this.newsBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.newsBrowser.Name = "newsBrowser";
            this.newsBrowser.ScriptErrorsSuppressed = true;
            this.newsBrowser.Size = new System.Drawing.Size(589, 248);
            this.newsBrowser.TabIndex = 0;
            // 
            // tabUpdate
            // 
            this.tabUpdate.BackColor = System.Drawing.Color.Gray;
            this.tabUpdate.Controls.Add(this.downloadTextBox);
            this.tabUpdate.Location = new System.Drawing.Point(4, 30);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Padding = new System.Windows.Forms.Padding(3);
            this.tabUpdate.Size = new System.Drawing.Size(595, 254);
            this.tabUpdate.TabIndex = 2;
            this.tabUpdate.Text = "Download Progress";
            // 
            // downloadTextBox
            // 
            this.downloadTextBox.Location = new System.Drawing.Point(2, 3);
            this.downloadTextBox.Name = "downloadTextBox";
            this.downloadTextBox.ReadOnly = true;
            this.downloadTextBox.Size = new System.Drawing.Size(590, 248);
            this.downloadTextBox.TabIndex = 0;
            this.downloadTextBox.Text = "";
            this.downloadTextBox.TextChanged += new System.EventHandler(this.downloadTextBox_TextChanged);
            // 
            // form1BindingSource
            // 
            this.form1BindingSource.DataSource = typeof(Libertas.LibertasForm);
            // 
            // LibertasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Libertas.Properties.Resources.stone_2_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(802, 381);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.modsList);
            this.Controls.Add(this.btnAddMod);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btn_play);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibertasForm";
            this.Text = "Libertas Retribution Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabMOTD.ResumeLayout(false);
            this.tabLogo.ResumeLayout(false);
            this.tabLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.NewsTab.ResumeLayout(false);
            this.tabUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnAddMod;
        private System.Windows.Forms.ListBox modsList;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox changelogBox;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.TabPage tabMOTD;
        private System.Windows.Forms.TabPage tabLogo;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabUpdate;
        private System.Windows.Forms.RichTextBox downloadTextBox;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage NewsTab;
        private System.Windows.Forms.WebBrowser newsBrowser;
    }
}

