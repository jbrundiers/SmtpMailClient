using SmtpMailClient.Properties;
//------------------------------------------------------------------------------------------------
//
//	SmtpMailClient
//
//	Copyright (C) 2017 Soft-Toolware. All Rights Reserved
//
//	The software is a free software.
//	It is distributed under the Code Project Open License (CPOL 1.02)
//	agreement. The full text of the CPOL is given in:
//	https://www.codeproject.com/info/cpol10.aspx
//	
//	The main points of CPOL 1.02 subject to the terms of the License are:
//
//	Source Code and Executable Files can be used in commercial applications;
//	Source Code and Executable Files can be redistributed; and
//	Source Code can be modified to create derivative works.
//	No claim of suitability, guarantee, or any warranty whatsoever is
//	provided. The software is provided "as-is".
//	
//
//------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using MRUList;


namespace SmtpMailClient
{
   
    public partial class SmtpMailClient : Form
    {
        /// <summary>
        /// Required global variables.
        /// </summary>
        ArrayList Attachments;
        ImageList AttachmentImageList;
        ArrayList AttachmentFileNames;

        public MRUList.MRUList receiverMRUList;
 
        long  lMailSize;

       

        /// <summary>
        /// ---
        /// </summary>
        public SmtpMailClient()
        {
            InitializeComponent();
                        
            this.Attachments = new ArrayList();
            this.AttachmentFileNames = new ArrayList();
            this.AttachmentImageList = new ImageList();

            this.receiverMRUList = new MRUList.MRUList(Application.ProductName + "_rcv" ); //MLHIDE
            this.receiverMRUList.loadFromStorage();

            listViewAttachments.SmallImageList = AttachmentImageList;
            // add event handler for Drag and Drop
            listViewAttachments.DragDrop +=new DragEventHandler(listViewAttachments_DragDrop);
            listViewAttachments.DragEnter += new DragEventHandler(listViewAttachments_DragEnter);

            lMailSize = 0;

            // Check for commandline arguments
            String[] arguments = Environment.GetCommandLineArgs();

            if ( arguments.Length > 1)
            {
                // make sure that the use can see the form
                
                this.TopMost = true;
                this.Focus();
                this.BringToFront();

                // Expect only filepathes as arguments
                for (int i = 1; i < arguments.Length; i++)
                {
                    listViewAttachments_AddItem(arguments[i]);
                }
            }
        }
    
        /// <summary>
        /// aboutToolStripMenuItem_Click
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instantiate window
            AboutBox dlg = new AboutBox();

            // Show window modally
            // NOTE: Returns only when window is closed
            dlg.ShowDialog();
        }

        /// <summary>
        /// optionsToolStripMenuItem_Click
        /// </summary>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instantiate window
            dlgOptions dlg = new dlgOptions();

            // Show window modally
            // NOTE: Returns only when window is closed
            dlg.ShowDialog();
        }
        
        /// <summary>
        /// exitToolStripMenuItem_Click
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receiverMRUList.saveToStorage();
            Application.Exit();
        }


      
        /// <summary>
        /// btnSendMail_Click
        /// </summary>
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (this.cbReceiver.Text.Length > 0 && ! this.cbReceiver.Text.Equals(""))
            {
                if ( ! this.EmailAddressValidation(this.cbReceiver.Text))
                {
                    MessageBox.Show(this, Resources.RES_ID_ReceiverFormat, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, Resources.RES_ID_NoReceiverAddr, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                return;
            }

            // If mail address is OK update and save the MRU
            receiverMRUList.Update(this.cbReceiver.Text);
            receiverMRUList.saveToStorage();
            // and update the coTo combobox
            UpdateToCombobox();
            
            this.ProgressLabel.Text = Resources.RES_ID_SendingMail;
            this.statusStrip.Refresh();
                  
            try
            {
                // MailMessage is used to represent the e-mail being sent
                // using statement ensures that Dispose is called even if an 
                // exception occurs while you are calling methods on the object.
                using ( MailMessage message = new MailMessage() )
                {
                    message.From = new MailAddress(Properties.Settings.Default.FromUser);

                    // loop through all receivers
                    // correct syntax has been checked before
                    string[] singleAddress = this.cbReceiver.Text.Split(',');
                    for (int i = 0; i < singleAddress.GetLength(0); i++)
                        message.To.Add(singleAddress[i]);
                    
                    message.Subject = this.tbSubject.Text;

                    message.Body = tbMailMessage.Text;
                    
                    // loop through all attachments
                    foreach (string filename in Attachments)
                    {
                        Attachment fileData = new Attachment(filename, MediaTypeNames.Application.Octet);
                    
                        // Add time stamp information for the file.
                        ContentDisposition disposition = fileData.ContentDisposition;
                        disposition.CreationDate = System.IO.File.GetCreationTime(filename);
                        disposition.ModificationDate = System.IO.File.GetLastWriteTime(filename);
                        disposition.ReadDate = System.IO.File.GetLastAccessTime(filename);

                        // Add the file attachment to this e-mail message.
                        message.Attachments.Add(fileData);
                    }

                    // SmtpClient is used to send the e-mail
                    SmtpClient mailClient = new SmtpClient(Properties.Settings.Default.SmtpServer, Convert.ToInt32(Properties.Settings.Default.SmtpPort));

                    // UseDefaultCredentials tells the mail client to use the Windows credentials of the account (i.e. user account) 
                    // being used to run the application
                    mailClient.UseDefaultCredentials = true;

                    // the time-out value in milliseconds. The default value is 100,000 (100 seconds). 
                    // mailClient.Timeout = 10000;
                    
                    // Send delivers the message to the mail server
                    mailClient.Send(message);

                } // end using


                MessageBox.Show(this, Resources.RES_ID_MailSent, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE

                // if called via commandline close application
                if (  Environment.GetCommandLineArgs().Length > 1 )
                {
                    Application.Exit();
                }
                
            }

            catch (FormatException ex)
            {
                MessageBox.Show(this, ex.Message, "Format Exeption", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(this, ex.Message, "Smtp Exeption", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
            }

            UpdateStatusStrip();
        }
        
        /// <summary>
        /// btnClearMail_Click
        /// </summary>
        private void btnClearMail_Click(object sender, EventArgs e)
        {
            this.cbReceiver.Text = "";
           
            this.tbSubject.Text = "";
            this.tbMailMessage.Text = "";

            // Clear the listbox
            listViewAttachments.Items.Clear();
            // Clear the attachment list
            Attachments.Clear();

            lMailSize = 0;
        }

        #region Attachment handling
        /// <summary>
        /// AttachmentToolStrip_ItemClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttachmentToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Tag == null)
                return;
            else if(e.ClickedItem.Tag.ToString() == "Add")            //MLHIDE
            {
                OpenFileDialog dialog = new OpenFileDialog();


                // !! todo: Check for too much (size) attachments !!
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    listViewAttachments_AddItem(dialog.FileName);
                }
            }
            else if (e.ClickedItem.Tag.ToString() == "Delete")        //MLHIDE
            {
                // is an entry selected ?
                if (this.listViewAttachments.SelectedItems.Count > 0)
                {
                    lMailSize -= (new FileInfo(this.listViewAttachments.SelectedItems[0].Tag.ToString()).Length)/1000;

                    // remove complete path from the attachments list. Find it via "Tag"
                    this.Attachments.Remove(this.listViewAttachments.SelectedItems[0].Tag.ToString());
                    
                    // remove listbox entry
                    this.listViewAttachments.SelectedItems[0].Remove();

                    UpdateStatusStrip(); 
                    
                }
            }
        }

        /// <summary>
        /// listViewAttachments_SelectedIndexChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAttachments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewAttachments.SelectedItems.Count > 0)
            {
                // enable Remove icon
                this.AttachmentToolStrip.Items[1].Enabled = true;
            }
            else
            {
                // disable Remove icon
                this.AttachmentToolStrip.Items[1].Enabled = false;
            }
        }

        /// <summary>
        /// listViewAttachments_Drop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAttachments_DragDrop(object sender, DragEventArgs e)
        {
            string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            
            foreach ( string file in filenames)
            {
                listViewAttachments_AddItem(file);
            }
        }

        /// <summary>
        /// listViewAttachments_DragEnter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewAttachments_DragEnter(object sender, DragEventArgs e)
        {
            // ensure that the data being dragged is of an acceptable type (in this case, Files). 
            // The code then sets the effect that will happen when the drop occurs to a value in 
            // the DragDropEffects enumeration.
            if (e.Data.GetDataPresent(DataFormats.FileDrop ))
            {
                string[] filenames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                e.Effect = DragDropEffects.Copy;

                // Check if any of the pathes is a directory only
                foreach ( string file in filenames)
                {
                    if ((File.GetAttributes(file) & FileAttributes.Directory) == FileAttributes.Directory)
                        e.Effect = DragDropEffects.None;
                }
            }
            else
                e.Effect = DragDropEffects.None;
        }

        /// <summary>
        /// listViewAttachments_AddItem()
        /// </summary>
        /// <param name="filepath"></param>
        private void listViewAttachments_AddItem( string filepath )
        {
            FileInfo finfo ;

            try
            {
                finfo = new FileInfo(filepath);

                if (lMailSize + (finfo.Length / 1000) > Convert.ToInt32(Properties.Settings.Default.MaxMailSize))
                {

                    MessageBox.Show(this, Resources.RES_ID_MailTooBig, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Error); //MLHIDE
                    return;

                }
                else
                {
                    // Find the icon for the file and add it to the image list
                    // if filepath is an UNC path ExtractAssociatedIcon() will throw an exception
                    // so we have to prevent this
                    if (filepath.StartsWith("\\\\"))                  //MLHIDE
                    {
                        MessageBox.Show(this, Resources.RES_ID_UNCpathNot, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Error); //MLHIDE
                        return;
                    }
                    Icon iconForFile = Icon.ExtractAssociatedIcon(filepath);
                    AttachmentImageList.Images.Add(Path.GetExtension(filepath), iconForFile);

                    // create a new listview item
                    ListViewItem item = new ListViewItem();

                    // add the filename and filesize to the listbox
                    item.Text = finfo.Name + " (" + ((double)(finfo.Length / 1000)).ToString("f0") + " KB)"; //MLHIDE

                    // increase mailsize
                    lMailSize += (finfo.Length / 1000);

                    // assign the right icon
                    item.ImageKey = Path.GetExtension(filepath);
                    item.Tag = filepath;

                    // add complete path to the attachments list
                    this.Attachments.Add(filepath);

                    // add the new item to the listview 
                    listViewAttachments.Items.Add(item);

                    UpdateStatusStrip();
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(this, "Exeption:" + e.Message , "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Error); //MLHIDE
            }

            
            
        }
        #endregion 

        #region Util functions

        /// <summary>
        /// UpdateStatusStrip
        /// </summary>
        /// 
        void UpdateStatusStrip()
        {

            if (lMailSize > Convert.ToInt32(Properties.Settings.Default.MaxMailSize))
                this.ProgressLabel.ForeColor = Color.Red;
            else
                this.ProgressLabel.ForeColor = Color.Black;

            this.ProgressLabel.Text = Resources.RES_ID_Computername + System.Environment.GetEnvironmentVariable("COMPUTERNAME") + Resources.RES_ID_MailSize + lMailSize + " KB"; //MLHIDE
            this.statusStrip.Refresh();

        }


        /// <summary>
        /// EmailAddressValidation()
        /// mail addresses could be separated by "," 
        /// Check every mail address for correct syntax.
        /// </summary>
        /// <param name="recipient"></param>
        /// <returns></returns>
        private bool EmailAddressValidation(string recipient)
        {
            // Mail addresses could be seperated by ","
            string[] splits = recipient.Split(new char[] {','});

            // Check each address
            for (int i = 0; i < splits.Length; i++)
            {
                if (this.EmailValidation(splits[i]))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
       

        /// <summary>
        /// EmailValidation()
        /// Check mail address for correct syntax.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool EmailValidation(string email)
        {
            Regex regx = new Regex(@"([a-zA-Z_0-9.-]+\@[a-zA-Z_0-9.-]+\.\w+)", RegexOptions.IgnoreCase); //MLHIDE
            if (regx.IsMatch(email))
            {
                return true;
            }
            return false;
        }
        #endregion


        /// <summary>
        /// SmtpMailClient_Load()
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SmtpMailClient_Load(object sender, EventArgs e)
        {
            // if no from address is given, create one
            if (Properties.Settings.Default.FromUser.Equals(""))
            {
                string[] fromAddress = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\');

                Properties.Settings.Default.FromUser = fromAddress[1] + "@" + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; //MLHIDE

                Properties.Settings.Default.Save();
            }

            // if no smtp server is given, create one
            if (Properties.Settings.Default.SmtpServer.Equals(""))
            {                                             
                Properties.Settings.Default.SmtpServer = "smtp." + System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName; //MLHIDE

                Properties.Settings.Default.Save();
            }

            // Read saved MRU data into the combobox
            UpdateToCombobox();

            UpdateStatusStrip();            
        }

        /// <summary>
        /// UpdateToCombobox
        /// Update the cbTo combobox with the actual MRU List
        /// </summary>
        /// 
        private void UpdateToCombobox()
        {
            // Refresh receiver combobox
            cbReceiver.Items.Clear();                         // Delete all items
            cbReceiver.ResetText();                           // Clear selected text

            foreach (var Item in receiverMRUList)       // Insert all items from MRUList
                cbReceiver.Items.Add(Item);

            if (cbReceiver.Items.Count != 0 )                 // if the list is not empty
                cbReceiver.SelectedIndex = 0;                 // Fill in selected text
        }
 
        /// <summary>
        /// btnCancel_Click
        /// <remarks> exit application without doing anything </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
        /// <summary>
        /// AddresslistMenuItem_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddresslistMenuItem_Click(object sender, EventArgs e)
        {
            dlgAddresslist dlg = new dlgAddresslist(receiverMRUList);

            // Show window modally
            // NOTE: Returns only when window is closed
            DialogResult dr = dlg.ShowDialog();

            if (dr == DialogResult.OK)
            {
                receiverMRUList.saveToStorage();

                // Refresh listbox
                cbReceiver.DataSource = null;
                cbReceiver.DataSource = receiverMRUList;
            }
        }

  
    }
}