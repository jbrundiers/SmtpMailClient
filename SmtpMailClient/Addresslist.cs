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
using MRUList;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SmtpMailClient
{
    public partial class dlgAddresslist : Form
    {
        private MRUList.MRUList _mru;

        public dlgAddresslist(MRUList.MRUList list)
        {
            InitializeComponent();

            _mru = list;

            // Copy each element to the listbox (Datasource does not work)
            foreach (var item in _mru)
            {
                lbAddresses.Items.Add(item);
            }
        }

        private void lbAddresses_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lbAddresses.SelectedItems.Count != 0)
                {
                    while (lbAddresses.SelectedIndex != -1)
                        lbAddresses.Items.RemoveAt(lbAddresses.SelectedIndex);
                }
                // Bypass the control's default handling; 
                // otherwise, remove to pass the event to the default control handler.
                e.Handled = true;
            }
        }

        private void lbAddresses_SelectedValueChanged(object sender, EventArgs e)
        {
            if (lbAddresses.SelectedItems.Count != 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lbAddresses.SelectedItems.Count != 0)
            {
                while (lbAddresses.SelectedIndex != -1)
                    lbAddresses.Items.RemoveAt(lbAddresses.SelectedIndex);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Clear the "old" list
            _mru.Clear();

            // Copy each element from the listbox 
            foreach (string item in lbAddresses.Items)
            {
                _mru.Update(item);
            }
            
            this.Close();
        }
    }
}
