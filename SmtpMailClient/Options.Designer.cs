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
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            resources.ApplyResources(this.listBoxCultures, "listBoxCultures");
            this.listBoxCultures.DisplayMember = "NativeName";
            this.listBoxCultures.FormattingEnabled = true;
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
            // dlgOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelMaxMailSize);
            this.Controls.Add(this.labelCultures);
            this.Controls.Add(this.listBoxCultures);
            this.Controls.Add(this.cbMAPIRegister);
            this.Controls.Add(this.tbMaxMailSize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tbSmtpPort);
            this.Controls.Add(this.tbSmtpServer);
            this.Controls.Add(this.labelSmtpPort);
            this.Controls.Add(this.labelSmtpServer);
            this.Controls.Add(this.labelSenderAddress);
            this.Controls.Add(this.tbSenderAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgOptions";
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
    }
}