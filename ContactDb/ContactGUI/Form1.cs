using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContactDll;
using ContactListDll;


namespace ContactGUI
{
    public partial class Form1 : Form
    {
        //Stored Procedure names (Select type)
        private const string ALL_CONTACTS = "GetAllContacts";
        private const string BUSINESS_CONTACTS = "GetAllBusinessContacts";
        private const string PERSONAL_CONTACTS = "GetAllPersonalContacts";
        private const string FIRST_NAME = "SearchByFirstName";
        private const string LAST_NAME = "SearchByLastName";
        private const string FIRST_LAST_NAME = "SearchByFirstAndLastName";
        
        /// <summary>
        /// First form shown in the program.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            //Adding DataGrid columns-------------------------------Setting width of columns
            this.dgContacts.Columns.Add("Key", "Key");              this.dgContacts.Columns[0].Width = 50;
            this.dgContacts.Columns.Add("LastName", "Last Name");   this.dgContacts.Columns[1].Width = 125;
            this.dgContacts.Columns.Add("FirstName", "First Name"); this.dgContacts.Columns[2].Width = 125;
            this.dgContacts.Columns.Add("Type", "Type");            this.dgContacts.Columns[3].Width = 50;
            this.dgContacts.Columns.Add("EMail", "Email Address");  this.dgContacts.Columns[4].Width = 200;

            tBoxFirstName.Enabled = false;
            tBoxLastName.Enabled = false;
            cBoxType.Enabled = false;
        }

        #region Data Manipulation
        /// <summary>
        /// Opens up a detailed window for the contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetails_Click(object sender, EventArgs e)
        {
            DataGridViewCell currentCell = dgContacts.CurrentCell;
            try
            {
                int contactKey = int.Parse(dgContacts[0, currentCell.OwningRow.Index].Value.ToString()); //retrieves Key cell in the (column, row) coordinates.
                DetailedForm details = new DetailedForm(contactKey);
                details.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("No contact is selected.");
            }
        }
        /// <summary>
        /// Deletes the selected contact (opens up a confirmation window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewCell currentCell = dgContacts.CurrentCell;
            if (currentCell != null)
            {
                int selectedKey = int.Parse(dgContacts[0, currentCell.OwningRow.Index].Value.ToString()); //retrieves Key cell in the (column, row) coordinates.
                DeleteForm delete = new DeleteForm(selectedKey);
                delete.Show();
            }
            else
                MessageBox.Show("No contact is selected.");
        }
        /// <summary>
        /// Adds a new contact (default Personal) to the database, then opens a detailed window to enter data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddContact_Click(object sender, EventArgs e)
        {
            DetailedForm detailedForm = new DetailedForm();
            detailedForm.Show();
        }
        #endregion

        #region Filtering
        /// <summary>
        /// Performs the specified search. Previous Contact collection is cleared.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rbFirstName.Checked)
            {
                ContactManager.FirstName = tBoxFirstName.Text;
                ContactManager.SearchBy(FIRST_NAME);
            }
            else if (rbLastName.Checked)
            {
                ContactManager.LastName = tBoxLastName.Text;
                ContactManager.SearchBy(LAST_NAME);
            }
            else if (rbFirstLast.Checked)
            {
                ContactManager.FirstName = tBoxFirstName.Text;
                ContactManager.LastName = tBoxLastName.Text;
                ContactManager.SearchBy(FIRST_LAST_NAME);
            }
            else if (rbContactType.Checked)
            {
                if (cBoxType.Text == "Personal")
                    ContactManager.SearchBy(PERSONAL_CONTACTS);
                else if (cBoxType.Text == "Business")
                    ContactManager.SearchBy(BUSINESS_CONTACTS);
                else
                {
                    MessageBox.Show("Please select a Contact Type."); return;
                }
            }
            else //No RadioButtons are selected
            {
                MessageBox.Show("Please select a type of query."); return;
            }
            RefreshDataGrid();
        }
        /// <summary>
        /// Selects all the contacts in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            ContactManager.Contacts.Clear();
            ContactManager.SearchBy(ALL_CONTACTS);
            RefreshDataGrid();
        }
        /// <summary>
        /// Resets everything.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ContactManager.Contacts.Clear();
            dgContacts.Rows.Clear();
            tBoxFirstName.Clear();
            tBoxLastName.Clear();
            cBoxType.SelectedIndex = -1;
            lblMatches.Text = "Matching Contacts:";
            rbContactType.Checked = false;  cBoxType.Enabled = false;
            rbFirstLast.Checked = false;    tBoxLastName.Enabled = false;
            rbFirstName.Checked = false;    tBoxFirstName.Enabled = false;
            rbLastName.Checked = false;
        }
        /// <summary>
        /// Refreshes the Data Grid.
        /// </summary>
        private void RefreshDataGrid()
        {
            dgContacts.Rows.Clear();
            for (int t = 0; t < ContactManager.Contacts.Count; t++) //setting up each row
            {
                int key = ContactManager.Contacts.ElementAt(t).Key;
                Contact current = ContactManager.Contacts[key];
                dgContacts.Rows.Add(key, current.LastName, current.FirstName, current.ContactType, current.Email);
            }
            lblMatches.Text = "Matching Contacts: " + ContactManager.Contacts.Count;
            //tBoxFound.Text = ContactManager.Contacts.Count.ToString();
        }
        #endregion

        #region Misc. UI Additions
        /// <summary>
        /// Method shared by both name boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameBoxes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) //Enter Key
                btnSearch_Click(sender, e);
        }
        /// <summary>
        /// First Name radiobutton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFirstName_Click(object sender, EventArgs e)
        {
            tBoxFirstName.Enabled = true;   tBoxFirstName.Focus();
            tBoxLastName.Enabled = false;   tBoxLastName.Clear();
            cBoxType.Enabled = false;       cBoxType.SelectedIndex = -1;
        }
        /// <summary>
        /// Last Name radiobutton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbLastName_Click(object sender, EventArgs e)
        {
            tBoxLastName.Enabled = true;    tBoxLastName.Focus();
            tBoxFirstName.Enabled = false;  tBoxFirstName.Clear();
            cBoxType.Enabled = false;       cBoxType.SelectedIndex = -1;
        }
        /// <summary>
        /// First/Last Name radiobutton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFirstLast_Click(object sender, EventArgs e)
        {
            tBoxFirstName.Enabled = true;   tBoxFirstName.Focus();
            tBoxLastName.Enabled = true;
            cBoxType.Enabled = false;       cBoxType.SelectedIndex = -1;
        }
        /// <summary>
        /// Contact Type radiobutton is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbContactType_Click(object sender, EventArgs e)
        {
            cBoxType.Enabled = true;        cBoxType.Focus();
            tBoxLastName.Enabled = false;   tBoxLastName.Clear();
            tBoxFirstName.Enabled = false;  tBoxFirstName.Clear();
        }
        /// <summary>
        /// Closes the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose(true);
        }
        /// <summary>
        /// Just because I can.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Joseph Hart.");
        }
        #endregion
    }
}
