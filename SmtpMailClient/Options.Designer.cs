namespace SmtpMailClient
{
    partial class dlgOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgOptions));
            this.tbSmtpPort = new System.Windows.Forms.TextBox();
            this.tbSmtpServer = new System.Windows.Forms.TextBox();
            this.labelSmtpPort = new System.Windows.Forms.Label();
            this.labelSmtpServer = new System.Windows.Forms.Label();
            this.labelSenderAddress = new System.Windows.Forms.Label();
            this.tbSenderAddress = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbMaxMailSize = new System.Windows.Forms.TextBox();
            this.cbMAPIRegister = new System.Windows.Forms.CheckBox();
            this.listBoxCultures = new System.Windows.Forms.ListBox();
            this.labelCultures = new System.Windows.Forms.Label();
            this.labelMaxMailSize = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbUserPassword = new System.Windows.Forms.TextBox();
            this.labelSmtpUsername = new System.Windows.Forms.Label();
            this.labelSmtpPassword = new System.Windows.Forms.Label();
            this.cbShowPassword = new System.Windows.Forms.CheckBox();
            this.gbSmtpSettings = new System.Windows.Forms.GroupBox();
            this.cbHTMLMailbody = new System.Windows.Forms.CheckBox();
            this.gbMailSettings = new System.Windows.Forms.GroupBox();
            this.gbSmtpSettings.SuspendLayout();
            this.gbMailSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSmtpPort
            // 
            resources.ApplyResources(this.tbSmtpPort, "tbSmtpPort");
            this.tbSmtpPort.Name = "tbSmtpPort";
            this.tbSmtpPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSmtpPort_KeyPress);
            // 
            // tbSmtpServer
            // 
            resources.ApplyResources(this.tbSmtpServer, "tbSmtpServer");
            this.tbSmtpServer.Name = "tbSmtpServer";
            // 
            // labelSmtpPort
            // 
            resources.ApplyResources(this.labelSmtpPort, "labelSmtpPort");
            this.labelSmtpPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSmtpPort.Name = "labelSmtpPort";
            // 
            // labelSmtpServer
            // 
            resources.ApplyResources(this.labelSmtpServer, "labelSmtpServer");
            this.labelSmtpServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSmtpServer.Name = "labelSmtpServer";
            // 
            // labelSenderAddress
            // 
            resources.ApplyResources(this.labelSenderAddress, "labelSenderAddress");
            this.labelSenderAddress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSenderAddress.Name = "labelSenderAddress";
            // 
            // tbSenderAddress
            // 
            resources.ApplyResources(this.tbSenderAddress, "tbSenderAddress");
            this.tbSenderAddress.Name = "tbSenderAddress";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tbMaxMailSize
            // 
            resources.ApplyResources(this.tbMaxMailSize, "tbMaxMailSize");
            this.tbMaxMailSize.Name = "tbMaxMailSize";
            this.tbMaxMailSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaxMailSize_KeyPress);
            // 
            // cbMAPIRegister
            // 
            resources.ApplyResources(this.cbMAPIRegister, "cbMAPIRegister");
            this.cbMAPIRegister.Name = "cbMAPIRegister";
            this.cbMAPIRegister.UseVisualStyleBackColor = true;
            // 
            // listBoxCultures
            // 
            this.listBoxCultures.DisplayMember = "NativeName";
            this.listBoxCultures.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxCultures, "listBoxCultures");
            this.listBoxCultures.Name = "listBoxCultures";
            // 
            // labelCultures
            // 
            resources.ApplyResources(this.labelCultures, "labelCultures");
            this.labelCultures.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelCultures.Name = "labelCultures";
            // 
            // labelMaxMailSize
            // 
            resources.ApplyResources(this.labelMaxMailSize, "labelMaxMailSize");
            this.labelMaxMailSize.Name = "labelMaxMailSize";
            // 
            // tbUserName
            // 
            resources.ApplyResources(this.tbUserName, "tbUserName");
            this.tbUserName.Name = "tbUserName";
            // 
            // tbUserPassword
            // 
            resources.ApplyResources(this.tbUserPassword, "tbUserPassword");
            this.tbUserPassword.Name = "tbUserPassword";
            this.tbUserPassword.UseSystemPasswordChar = true;
            // 
            // labelSmtpUsername
            // 
            resources.ApplyResources(this.labelSmtpUsername, "labelSmtpUsername");
            this.labelSmtpUsername.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSmtpUsername.Name = "labelSmtpUsername";
            // 
            // labelSmtpPassword
            // 
            resources.ApplyResources(this.labelSmtpPassword, "labelSmtpPassword");
            this.labelSmtpPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSmtpPassword.Name = "labelSmtpPassword";
            // 
            // cbShowPassword
            // 
            resources.ApplyResources(this.cbShowPassword, "cbShowPassword");
            this.cbShowPassword.Name = "cbShowPassword";
            this.cbShowPassword.UseVisualStyleBackColor = true;
            this.cbShowPassword.CheckedChanged += new System.EventHandler(this.cbShowPassword_CheckedChanged);
            // 
            // gbSmtpSettings
            // 
            this.gbSmtpSettings.Controls.Add(this.cbShowPassword);
            this.gbSmtpSettings.Controls.Add(this.tbSenderAddress);
            this.gbSmtpSettings.Controls.Add(this.labelSmtpPassword);
            this.gbSmtpSettings.Controls.Add(this.labelSenderAddress);
            this.gbSmtpSettings.Controls.Add(this.labelSmtpUsername);
            this.gbSmtpSettings.Controls.Add(this.labelSmtpServer);
            this.gbSmtpSettings.Controls.Add(this.tbUserPassword);
            this.gbSmtpSettings.Controls.Add(this.labelSmtpPort);
            this.gbSmtpSettings.Controls.Add(this.tbUserName);
            this.gbSmtpSettings.Controls.Add(this.tbSmtpServer);
            this.gbSmtpSettings.Controls.Add(this.tbSmtpPort);
            resources.ApplyResources(this.gbSmtpSettings, "gbSmtpSettings");
            this.gbSmtpSettings.Name = "gbSmtpSettings";
            this.gbSmtpSettings.TabStop = false;
            // 
            // cbHTMLMailbody
            // 
            resources.ApplyResources(this.cbHTMLMailbody, "cbHTMLMailbody");
            this.cbHTMLMailbody.Name = "cbHTMLMailbody";
            this.cbHTMLMailbody.UseVisualStyleBackColor = true;
            // 
            // gbMailSettings
            // 
            this.gbMailSettings.Controls.Add(this.tbMaxMailSize);
            this.gbMailSettings.Controls.Add(this.cbHTMLMailbody);
            this.gbMailSettings.Controls.Add(this.labelMaxMailSize);
            this.gbMailSettings.Controls.Add(this.cbMAPIRegister);
            resources.ApplyResources(this.gbMailSettings, "gbMailSettings");
            this.gbMailSettings.Name = "gbMailSettings";
            this.gbMailSettings.TabStop = false;
            // 
            // dlgOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbMailSettings);
            this.Controls.Add(this.gbSmtpSettings);
            this.Controls.Add(this.labelCultures);
            this.Controls.Add(this.listBoxCultures);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgOptions";
            this.gbSmtpSettings.ResumeLayout(false);
            this.gbSmtpSettings.PerformLayout();
            this.gbMailSettings.ResumeLayout(false);
            this.gbMailSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSmtpPort;
        private System.Windows.Forms.TextBox tbSmtpServer;
        private System.Windows.Forms.Label labelSmtpPort;
        private System.Windows.Forms.Label labelSmtpServer;
        private System.Windows.Forms.Label labelSenderAddress;
        private System.Windows.Forms.TextBox tbSenderAddress;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbMaxMailSize;
        private System.Windows.Forms.CheckBox cbMAPIRegister;
        private System.Windows.Forms.ListBox listBoxCultures;
        private System.Windows.Forms.Label labelCultures;
        private System.Windows.Forms.Label labelMaxMailSize;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbUserPassword;
        private System.Windows.Forms.Label labelSmtpUsername;
        private System.Windows.Forms.Label labelSmtpPassword;
        private System.Windows.Forms.CheckBox cbShowPassword;
        private System.Windows.Forms.GroupBox gbSmtpSettings;
        private System.Windows.Forms.CheckBox cbHTMLMailbody;
        private System.Windows.Forms.GroupBox gbMailSettings;
    }
}