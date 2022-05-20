namespace Libertas
{
    partial class LibertasConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LibertasConfig));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.ConfigList = new System.Windows.Forms.ListBox();
            this.settingComment = new System.Windows.Forms.Label();
            this.bool_Combo = new System.Windows.Forms.ComboBox();
            this.Bool_Label = new System.Windows.Forms.Label();
            this.ButtonDetect = new System.Windows.Forms.Button();
            this.ButtonBrowse = new System.Windows.Forms.Button();
            this.button_cleanup = new System.Windows.Forms.Button();
            this.button_redownload = new System.Windows.Forms.Button();
            this.button_reinstall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(410, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(8, 8);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Libertas.Properties.Resources.exit_menu_1;
            this.pictureBox2.Location = new System.Drawing.Point(0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(418, 64);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.pictureBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::Libertas.Properties.Resources.button_close_over_1;
            this.btnClose.Location = new System.Drawing.Point(388, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(25, 25);
            this.btnClose.TabIndex = 7;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(99, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(239, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            // 
            // ConfigList
            // 
            this.ConfigList.BackColor = System.Drawing.Color.White;
            this.ConfigList.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConfigList.FormattingEnabled = true;
            this.ConfigList.Location = new System.Drawing.Point(12, 73);
            this.ConfigList.Name = "ConfigList";
            this.ConfigList.Size = new System.Drawing.Size(172, 251);
            this.ConfigList.TabIndex = 9;
            this.ConfigList.SelectedIndexChanged += new System.EventHandler(this.ConfigList_SelectedIndexChanged);
            // 
            // settingComment
            // 
            this.settingComment.Location = new System.Drawing.Point(190, 200);
            this.settingComment.Name = "settingComment";
            this.settingComment.Size = new System.Drawing.Size(223, 124);
            this.settingComment.TabIndex = 10;
            this.settingComment.Text = "label1";
            this.settingComment.Click += new System.EventHandler(this.label1_Click);
            // 
            // bool_Combo
            // 
            this.bool_Combo.FormattingEnabled = true;
            this.bool_Combo.Location = new System.Drawing.Point(248, 176);
            this.bool_Combo.Name = "bool_Combo";
            this.bool_Combo.Size = new System.Drawing.Size(165, 21);
            this.bool_Combo.TabIndex = 11;
            this.bool_Combo.SelectedIndexChanged += new System.EventHandler(this.bool_Combo_SelectedIndexChanged);
            this.bool_Combo.TextChanged += new System.EventHandler(this.bool_Combo_TextChanged);
            this.bool_Combo.Leave += new System.EventHandler(this.bool_Combo_Leave);
            // 
            // Bool_Label
            // 
            this.Bool_Label.AutoSize = true;
            this.Bool_Label.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Bool_Label.Location = new System.Drawing.Point(190, 175);
            this.Bool_Label.Name = "Bool_Label";
            this.Bool_Label.Size = new System.Drawing.Size(52, 22);
            this.Bool_Label.TabIndex = 12;
            this.Bool_Label.Text = "Value:";
            this.Bool_Label.Click += new System.EventHandler(this.Bool_Label_Click);
            // 
            // ButtonDetect
            // 
            this.ButtonDetect.Location = new System.Drawing.Point(324, 118);
            this.ButtonDetect.Name = "ButtonDetect";
            this.ButtonDetect.Size = new System.Drawing.Size(89, 23);
            this.ButtonDetect.TabIndex = 13;
            this.ButtonDetect.Text = "Autodetect";
            this.ButtonDetect.UseVisualStyleBackColor = true;
            this.ButtonDetect.Click += new System.EventHandler(this.button1_Click);
            // 
            // ButtonBrowse
            // 
            this.ButtonBrowse.Location = new System.Drawing.Point(324, 147);
            this.ButtonBrowse.Name = "ButtonBrowse";
            this.ButtonBrowse.Size = new System.Drawing.Size(89, 23);
            this.ButtonBrowse.TabIndex = 14;
            this.ButtonBrowse.Text = "Browse";
            this.ButtonBrowse.UseVisualStyleBackColor = true;
            this.ButtonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // button_cleanup
            // 
            this.button_cleanup.Location = new System.Drawing.Point(190, 73);
            this.button_cleanup.Name = "button_cleanup";
            this.button_cleanup.Size = new System.Drawing.Size(135, 23);
            this.button_cleanup.TabIndex = 15;
            this.button_cleanup.Text = "SVN Cleanup";
            this.button_cleanup.UseVisualStyleBackColor = true;
            this.button_cleanup.Visible = false;
            this.button_cleanup.Click += new System.EventHandler(this.button_cleanup_Click);
            // 
            // button_redownload
            // 
            this.button_redownload.Location = new System.Drawing.Point(190, 102);
            this.button_redownload.Name = "button_redownload";
            this.button_redownload.Size = new System.Drawing.Size(135, 23);
            this.button_redownload.TabIndex = 16;
            this.button_redownload.Text = "Redownload mod";
            this.button_redownload.UseVisualStyleBackColor = true;
            this.button_redownload.Visible = false;
            this.button_redownload.Click += new System.EventHandler(this.button_redownload_Click);
            // 
            // button_reinstall
            // 
            this.button_reinstall.Location = new System.Drawing.Point(190, 131);
            this.button_reinstall.Name = "button_reinstall";
            this.button_reinstall.Size = new System.Drawing.Size(135, 39);
            this.button_reinstall.TabIndex = 17;
            this.button_reinstall.Text = "(!!!) Delete mod (!!!)";
            this.button_reinstall.UseVisualStyleBackColor = true;
            this.button_reinstall.Visible = false;
            this.button_reinstall.Click += new System.EventHandler(this.button_reinstall_Click);
            // 
            // LibertasConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Libertas.Properties.Resources.exit_menu_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(425, 336);
            this.Controls.Add(this.button_reinstall);
            this.Controls.Add(this.button_redownload);
            this.Controls.Add(this.button_cleanup);
            this.Controls.Add(this.ButtonBrowse);
            this.Controls.Add(this.ButtonDetect);
            this.Controls.Add(this.Bool_Label);
            this.Controls.Add(this.bool_Combo);
            this.Controls.Add(this.settingComment);
            this.Controls.Add(this.ConfigList);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LibertasConfig";
            this.Text = "Configure Launcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ListBox ConfigList;
        private System.Windows.Forms.Label settingComment;
        private System.Windows.Forms.ComboBox bool_Combo;
        private System.Windows.Forms.Label Bool_Label;
        private System.Windows.Forms.Button ButtonDetect;
        private System.Windows.Forms.Button ButtonBrowse;
        private System.Windows.Forms.Button button_cleanup;
        private System.Windows.Forms.Button button_redownload;
        private System.Windows.Forms.Button button_reinstall;
    }
}