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
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Globalization;

namespace SmtpMailClient
{
    public partial class dlgOptions : Form
    {
        private CultureInfo SelectedCulture;
        private int CultureIndex;

        /// <summary>
        /// 
        /// </summary>
        public dlgOptions()
        {
            InitializeComponent();
            
            tbSenderAddress.Text = Properties.Settings.Default.FromUser;

            tbUserName.Text = Properties.Settings.Default.SmtpUser;
            tbUserPassword.Text = Properties.Settings.Default.SmtpPassword;

            cbConnectionEncryption.Text = Properties.Settings.Default.SmtpEncryption;

            tbSmtpPort.Text = Properties.Settings.Default.SmtpPort;
            tbSmtpServer.Text = Properties.Settings.Default.SmtpServer;
            tbMaxMailSize.Text = Properties.Settings.Default.MaxMailSize;
            cbMAPIRegister.Checked = Properties.Settings.Default.MAPIreg;

            // uses the SupportedCultures array
            UICulture Lng = new UICulture();
            List<String> liste = Lng.SupportedCulture;

            String CultName = Properties.Settings.Default.Culture; // read from properties
            CultureInfo CultInfo = new CultureInfo(CultName);
            SelectedCulture = CultInfo;

            foreach (string IetfTag in liste)
            {
                CultureInfo Cult = new CultureInfo(IetfTag);

                // Note: The property listBoxCultures.DisplayName is set to "NativeName" in order to
                //       show language name in its own language.
                listBoxCultures.Items.Add(Cult);
            }

            listBoxCultures.SelectedItem = SelectedCulture;

            CultureIndex = listBoxCultures.SelectedIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbSmtpServer.Text.Equals(""))
            {
                MessageBox.Show(this, Resources.RES_ID_NoSmtpServer, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                return ;
            }
            else if (tbSmtpPort.Text.Equals(""))
            {
                MessageBox.Show(this, Resources.RES_ID_NoSmtpPort, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                return ;
            }
            else if (tbMaxMailSize.Text.Equals(""))
            {
                MessageBox.Show(this, Resources.RES_ID_NoMaxMailSize, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                return;
            }
            else if (tbSenderAddress.Text.Equals(""))
            {
                MessageBox.Show(this, Resources.RES_ID_NoSenderAddr, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                return ;
            } 
            else if (! this.EmailValidation(this.tbSenderAddress.Text))
            {
                MessageBox.Show(this, Resources.RES_ID_SenderFormat, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Error); //MLHIDE
                return;
            }

            if (cbMAPIRegister.Checked == true)
            {
                RegisterMAPIReg();
            }
            else
            {
                DeRegisterMAPIReg();
            }

            Properties.Settings.Default.FromUser = tbSenderAddress.Text;
            Properties.Settings.Default.SmtpUser = tbUserName.Text;
            Properties.Settings.Default.SmtpPassword = tbUserPassword.Text;
            Properties.Settings.Default.SmtpEncryption = cbConnectionEncryption.Text;
            Properties.Settings.Default.SmtpPort = tbSmtpPort.Text;
            Properties.Settings.Default.SmtpServer = tbSmtpServer.Text;
            Properties.Settings.Default.MaxMailSize = tbMaxMailSize.Text;
            Properties.Settings.Default.MAPIreg = cbMAPIRegister.Checked ;

            if (listBoxCultures.SelectedItem != null)
            {
                if (CultureIndex != listBoxCultures.SelectedIndex)
                {
                    SelectedCulture = (CultureInfo)listBoxCultures.SelectedItem;
                    Properties.Settings.Default.Culture = SelectedCulture.Name;
                    
                    MessageBox.Show(this, Resources.RES_ID_CultureChange, "Smtp Mail Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            Properties.Settings.Default.Save();
               
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSmtpPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMaxMailSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }



        #region Registry funktion to register with MAPI and MAPIhooks.dll

        /// <summary>
        /// 
        /// </summary>
        private string strRegistryBaseName = "SmtpMailClient";        //MLHIDE

        /// <summary>
        /// RegisterMAPIReg()
        /// </summary>
        private void RegisterMAPIReg()
        {
            // Create a new Subkey "Clients" under "HKCU\Software\"
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true); //MLHIDE
            key.CreateSubKey("Clients");                              //MLHIDE
            key.Close();
            key.Dispose();

            // Create a new Subkey "Mail" under "HKCU\Software\Clients\"
            RegistryKey key0 = Registry.CurrentUser.OpenSubKey("Software\\Clients", true); //MLHIDE
            key0.CreateSubKey( "Mail");                               //MLHIDE
            key0.Close();
            key0.Dispose();

            RegistryKey key1 = Registry.CurrentUser.OpenSubKey("Software\\Clients\\Mail", true); //MLHIDE
            // Write our new RegKey to the (default) of "HKCU\Software\Clients\Mail"
            // A registry key can contain one value that is not associated with any name. When this unnamed value 
            // is displayed in the registry editor, the string "(Default)" appears instead of a name. 
            // To set this unnamed value, specify either null or the empty string ("") for valueName.
            key1.SetValue("", strRegistryBaseName);
            // Create a new Subkey under "HKCU\Software\Clients\Mail"
            key1.CreateSubKey(strRegistryBaseName);
            key1.Close();
            key1.Dispose();

            // Open the new created SubKey and write 2 values "(default)" and "DLLPath"
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Software\\Clients\\Mail\\" + strRegistryBaseName, true); //MLHIDE
            // Write the default value
            key2.SetValue("", strRegistryBaseName);

            // Set the DLLPath to our MAPI
            string Path2MapiDLL = Application.StartupPath + "\\" + "mapiHooks.dll"; //MLHIDE
            key2.SetValue("DLLPath", Path2MapiDLL, RegistryValueKind.String); //MLHIDE

            // Set the EXEPath to this
            key2.SetValue("EXEPath", Application.ExecutablePath, RegistryValueKind.String); //MLHIDE

            key2.Close();
            key2.Dispose();

        }

        /// <summary>
        /// 
        /// </summary>
        private void DeRegisterMAPIReg()
        {
            // first check if an registry exists
            if (Registry.CurrentUser.GetValue("Software\\Clients\\Mail\\" + strRegistryBaseName) != null)
            {

                try
                {
                    //delete Registry entry SmtpMailClient
                    Registry.CurrentUser.DeleteSubKeyTree("Software\\Clients\\Mail\\" + strRegistryBaseName); //MLHIDE
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // RegKey doesnot exist 
                }

                try
                {
                    // Reset the default entry to blank
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Clients\\Mail", true); //MLHIDE

                    // A registry key can contain one value that is not associated with any name. When this unnamed value 
                    // is displayed in the registry editor, the string "(Default)" appears instead of a name. 
                    // To set this unnamed value, specify either null or the empty string ("") for valueName.
                    key.SetValue("", "");

                    key.Close();
                    key.Dispose();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "Exeption", MessageBoxButtons.OK, MessageBoxIcon.Information); //MLHIDE
                                                                                                                     // RegKey doesnot exist 
                }
            }
        }




        #endregion Registry funktion to register with MAPI and MAPIhooks.dll

       
    }
}
