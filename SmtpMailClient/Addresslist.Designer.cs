namespace SmtpMailClient
{
    partial class dlgAddresslist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAddresslist));
            this.lbAddresses = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbAddresses
            // 
            this.lbAddresses.FormattingEnabled = true;
            resources.ApplyResources(this.lbAddresses, "lbAddresses");
            this.lbAddresses.Name = "lbAddresses";
            this.lbAddresses.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbAddresses.SelectedValueChanged += new System.EventHandler(this.lbAddresses_SelectedValueChanged);
            this.lbAddresses.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbAddresses_KeyDown);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancle, "btnCancle");
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // dlgAddresslist
            // 
            this.AcceptButton = this.btnCancle;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancle;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbAddresses);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgAddresslist";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbAddresses;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnDelete;

    }
}