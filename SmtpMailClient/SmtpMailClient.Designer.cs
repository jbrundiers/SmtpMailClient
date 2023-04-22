namespace SmtpMailClient
{
    partial class SmtpMailClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmtpMailClient));
            this.btnClearMail = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddresslistMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelReceiver = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.labelAttachments = new System.Windows.Forms.Label();
            this.AttachmentToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddAttachment = new System.Windows.Forms.ToolStripButton();
            this.DeleteAttachment = new System.Windows.Forms.ToolStripButton();
            this.labelMailMessage = new System.Windows.Forms.Label();
            this.listViewAttachments = new System.Windows.Forms.ListView();
            this.cbReceiver = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSendMail = new System.Windows.Forms.Button();
            this.htmlEditorMailMessage = new HtmlEditor.HtmlEditorControl();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.AttachmentToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearMail
            // 
            resources.ApplyResources(this.btnClearMail, "btnClearMail");
            this.btnClearMail.Name = "btnClearMail";
            this.btnClearMail.UseVisualStyleBackColor = true;
            this.btnClearMail.Click += new System.EventHandler(this.btnClearMail_Click);
            // 
            // statusStrip
            // 
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressLabel});
            this.statusStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.SizingGrip = false;
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Name = "ProgressLabel";
            resources.ApplyResources(this.ProgressLabel, "ProgressLabel");
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.viewToolStripMenuItem});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddresslistMenuItem,
            this.optionsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // AddresslistMenuItem
            // 
            this.AddresslistMenuItem.Name = "AddresslistMenuItem";
            resources.ApplyResources(this.AddresslistMenuItem, "AddresslistMenuItem");
            this.AddresslistMenuItem.Click += new System.EventHandler(this.AddresslistMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.htmlToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            resources.ApplyResources(this.viewToolStripMenuItem, "viewToolStripMenuItem");
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            resources.ApplyResources(this.textToolStripMenuItem, "textToolStripMenuItem");
            this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
            // 
            // htmlToolStripMenuItem
            // 
            this.htmlToolStripMenuItem.Name = "htmlToolStripMenuItem";
            resources.ApplyResources(this.htmlToolStripMenuItem, "htmlToolStripMenuItem");
            this.htmlToolStripMenuItem.Click += new System.EventHandler(this.htmlToolStripMenuItem_Click);
            // 
            // labelReceiver
            // 
            resources.ApplyResources(this.labelReceiver, "labelReceiver");
            this.labelReceiver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelReceiver.Name = "labelReceiver";
            // 
            // labelSubject
            // 
            resources.ApplyResources(this.labelSubject, "labelSubject");
            this.labelSubject.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelSubject.Name = "labelSubject";
            // 
            // tbSubject
            // 
            resources.ApplyResources(this.tbSubject, "tbSubject");
            this.tbSubject.Name = "tbSubject";
            // 
            // labelAttachments
            // 
            resources.ApplyResources(this.labelAttachments, "labelAttachments");
            this.labelAttachments.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelAttachments.Name = "labelAttachments";
            // 
            // AttachmentToolStrip
            // 
            resources.ApplyResources(this.AttachmentToolStrip, "AttachmentToolStrip");
            this.AttachmentToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.AttachmentToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddAttachment,
            this.DeleteAttachment});
            this.AttachmentToolStrip.Name = "AttachmentToolStrip";
            this.AttachmentToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.AttachmentToolStrip_ItemClicked);
            // 
            // AddAttachment
            // 
            this.AddAttachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddAttachment.Image = global::SmtpMailClient.Properties.Resources.add;
            resources.ApplyResources(this.AddAttachment, "AddAttachment");
            this.AddAttachment.Name = "AddAttachment";
            this.AddAttachment.Tag = "Add";
            // 
            // DeleteAttachment
            // 
            this.DeleteAttachment.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.DeleteAttachment, "DeleteAttachment");
            this.DeleteAttachment.Image = global::SmtpMailClient.Properties.Resources.delete;
            this.DeleteAttachment.Name = "DeleteAttachment";
            this.DeleteAttachment.Tag = "Delete";
            // 
            // labelMailMessage
            // 
            resources.ApplyResources(this.labelMailMessage, "labelMailMessage");
            this.labelMailMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelMailMessage.Name = "labelMailMessage";
            // 
            // listViewAttachments
            // 
            this.listViewAttachments.AllowDrop = true;
            this.listViewAttachments.HideSelection = false;
            resources.ApplyResources(this.listViewAttachments, "listViewAttachments");
            this.listViewAttachments.MultiSelect = false;
            this.listViewAttachments.Name = "listViewAttachments";
            this.listViewAttachments.ShowGroups = false;
            this.listViewAttachments.UseCompatibleStateImageBehavior = false;
            this.listViewAttachments.View = System.Windows.Forms.View.SmallIcon;
            this.listViewAttachments.SelectedIndexChanged += new System.EventHandler(this.listViewAttachments_SelectedIndexChanged);
            // 
            // cbReceiver
            // 
            this.cbReceiver.FormattingEnabled = true;
            resources.ApplyResources(this.cbReceiver, "cbReceiver");
            this.cbReceiver.Name = "cbReceiver";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSendMail
            // 
            this.btnSendMail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSendMail.Image = global::SmtpMailClient.Properties.Resources.email_to_friend_ico;
            resources.ApplyResources(this.btnSendMail, "btnSendMail");
            this.btnSendMail.Name = "btnSendMail";
            this.btnSendMail.UseVisualStyleBackColor = true;
            this.btnSendMail.Click += new System.EventHandler(this.btnSendMail_Click);
            // 
            // htmlEditorMailMessage
            // 
            this.htmlEditorMailMessage.BodyHtml = null;
            this.htmlEditorMailMessage.BodyText = null;
            this.htmlEditorMailMessage.DocumentText = resources.GetString("htmlEditorMailMessage.DocumentText");
            this.htmlEditorMailMessage.Html = null;
            resources.ApplyResources(this.htmlEditorMailMessage, "htmlEditorMailMessage");
            this.htmlEditorMailMessage.Name = "htmlEditorMailMessage";
            // 
            // SmtpMailClient
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.htmlEditorMailMessage);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cbReceiver);
            this.Controls.Add(this.listViewAttachments);
            this.Controls.Add(this.labelMailMessage);
            this.Controls.Add(this.btnSendMail);
            this.Controls.Add(this.btnClearMail);
            this.Controls.Add(this.AttachmentToolStrip);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.labelAttachments);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelReceiver);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "SmtpMailClient";
            this.Load += new System.EventHandler(this.SmtpMailClient_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.AttachmentToolStrip.ResumeLayout(false);
            this.AttachmentToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendMail;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ProgressLabel;
        private System.Windows.Forms.Button btnClearMail;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label labelReceiver;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.Label labelAttachments;
        private System.Windows.Forms.ToolStrip AttachmentToolStrip;
        private System.Windows.Forms.ToolStripButton AddAttachment;
        private System.Windows.Forms.ToolStripButton DeleteAttachment;
        private System.Windows.Forms.Label labelMailMessage;
        private System.Windows.Forms.ListView listViewAttachments;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ComboBox cbReceiver;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolStripMenuItem AddresslistMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem htmlToolStripMenuItem;
        private HtmlEditor.HtmlEditorControl htmlEditorMailMessage;
    }
}

