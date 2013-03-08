using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContactListDll;

namespace ContactGUI
{
    public partial class DeleteForm : Form
    {
        private int _key;

        public DeleteForm(int keyP)
        {
            InitializeComponent();
            this._key = keyP;
            lblConfirm.Text = "Delete " + ContactManager.Contacts[_key].FirstName + ' ' + ContactManager.Contacts[_key].LastName + '?';
        }
        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYes_Click(object sender, EventArgs e)
        {
            ContactManager.DeleteContact(_key);
            ContactManager.Contacts.Remove(_key);
            this.Close();
        }
        /// <summary>
        /// Cancels the deletion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
    }
}
