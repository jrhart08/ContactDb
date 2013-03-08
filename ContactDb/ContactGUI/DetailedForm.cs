using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ContactDll;
using ContactListDll;

namespace ContactGUI
{
    public partial class DetailedForm : Form
    {
        private int _key;
        private bool _isNewContact = false;
        private bool _isAmerican;

        private PrintDocument document = new PrintDocument();

        #region Main UI Components
        /// <summary>
        /// Blank form for newly-added Contact (Default Personal).
        /// </summary>
        public DetailedForm()
        {
            InitializeComponent();
            _key = ContactManager.GetLastContactKey() + 1;
            ContactManager.Contacts[_key] = new PersonalContact();
            this._isNewContact = true;
            this.btnUpdate.Text = "Add";
        }
        /// <summary>
        /// Filled form with the selected Contact's data.
        /// </summary>
        /// <param name="keyP"></param>
        public DetailedForm(int keyP)
        {
            InitializeComponent();
            _key = keyP;
            this.btnUpdate.Text = "Update";
        }
        /// <summary>
        /// Loaded regardless of constructor.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailedForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = "Contact #" + _key + " Info: " + ContactManager.Contacts[_key].FirstName + ' ' + ContactManager.Contacts[_key].LastName;
                this.FillDateSelections();
                this.LoadData();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                this.Dispose(true);
            }
        }
        /// <summary>
        /// Fills the items in the Birthday comboboxes
        /// </summary>
        private void FillDateSelections()
        {
            for (int t = 1; t <= 12; t++) //months (1-12)
                cBoxMonth.Items.Add(t);
            for (int t = 1; t <= 31; t++) //days (1-31)
                cBoxDay.Items.Add(t);
            for (int t = DateTime.Today.Year; t >= 1900; t--) //years (2012-1900)
                cBoxYear.Items.Add(t);
        }
        /// <summary>
        /// Appends the Contact record in the dictionary (first) and database (second).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cBoxContactTypes.SelectedIndex == 0)
                ContactManager.Contacts[_key] = new PersonalContact(tBoxLastName.Text.Trim(),
                    tBoxFirstName.Text.Trim(), tBoxCourtesyTitle.Text.Trim(), tBoxAddress1.Text.Trim(), tBoxAddress2.Text.Trim(), this.GetStateKey(),
                    tBoxCity.Text.Trim(), tBoxCountry.Text.Trim(), tBoxZip.Text.Trim(), tBoxHomePhone.Text.Trim(), tBoxCellPhone.Text.Trim(),
                    tBoxEmail.Text.Trim(), this.GetDate(), tBoxNotes.Text.Trim());
            else
                ContactManager.Contacts[_key] = new BusinessContact(tBoxCompany.Text.Trim(), tBoxJobTitle.Text.Trim(),
                    tBoxLastName.Text.Trim(), tBoxFirstName.Text.Trim(), tBoxCourtesyTitle.Text.Trim(), tBoxAddress1.Text.Trim(), tBoxAddress2.Text.Trim(),
                    this.GetStateKey(), tBoxCity.Text.Trim(), tBoxCountry.Text.Trim(), tBoxZip.Text.Trim(), tBoxWorkPhone.Text.Trim(), tBoxWorkExt.Text.Trim(),
                    tBoxFax.Text.Trim(), tBoxEmail.Text.Trim(), tBoxNotes.Text.Trim());

            if (_isNewContact)
                ContactManager.InsertContact();
            else
                ContactManager.UpdateContact(_key);

            this.Dispose(true);
        }
        #endregion

        /// <summary>
        /// Sets up the data on the page.
        /// </summary>
        private void LoadData()
        {
            Contact temp = ContactManager.Contacts[_key];
            //Universal data
            tBoxAddress1.Text = temp.AddressLine1;          tBoxAddress2.Text = temp.AddressLine2;
            tBoxCity.Text = temp.City;                      tBoxCountry.Text = temp.Country;
            tBoxCourtesyTitle.Text = temp.CourtesyTitle;    tBoxEmail.Text = temp.Email;
            tBoxFirstName.Text = temp.FirstName;            tBoxLastName.Text = temp.LastName;
            tBoxNotes.Text = temp.Note;                     tBoxZip.Text = temp.Zip;
            cBoxContactTypes.SelectedIndex = temp.ContactType - 1;

            if (temp.StateKey == 56)
                cBoxStates.SelectedIndex = -1;
            else if (temp.StateKey == 1)
                cBoxStates.SelectedIndex = temp.StateKey - 1;
            else
                cBoxStates.SelectedIndex = temp.StateKey - 4;
            
            if (temp is PersonalContact)
            {
                //Personal-specific data
                PersonalContact tempP = temp as PersonalContact;

                tBoxCellPhone.Text = tempP.CellPhone;   tBoxHomePhone.Text = tempP.HomePhone;

                string[] dates = tempP.DateOfBirth.Split('/');
                try
                {
                    cBoxMonth.SelectedItem = int.Parse(dates[0]);
                    cBoxDay.SelectedItem = int.Parse(dates[1]);
                    cBoxYear.SelectedItem = int.Parse(dates[2]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Birthday was not inputted in the correct format. Please Re-enter.");
                }
            }
            else
            {
                //Business-specific data
                BusinessContact tempB = temp as BusinessContact;

                tBoxCompany.Text = tempB.CompanyName;   tBoxFax.Text = tempB.Fax;
                tBoxJobTitle.Text = tempB.JobTitle;     tBoxWorkPhone.Text = tempB.WorkPhone;
                tBoxWorkExt.Text = tempB.Extension;
            }
        }

        #region Data Formatting
        /// <summary>
        /// Returns a formatted date from the 3 date comboboxes (or nothing if the input is invalid).
        /// </summary>
        /// <returns></returns>
        private string GetDate()
        {
            int test;
            //if (all boxes have integers)
            if (int.TryParse(cBoxMonth.Text, out test) && int.TryParse(cBoxDay.Text, out test) && int.TryParse(cBoxYear.Text, out test))
                return cBoxMonth.SelectedItem + "/" + cBoxDay.SelectedItem + "/" + cBoxYear.SelectedItem;
            else
                return "";
        }
        /// <summary>
        /// Returns the State Key.
        /// </summary>
        /// <returns></returns>
        private int GetStateKey()
        {
            if (!_isAmerican)
                return 56; //no state (if not in US)
            else if (cBoxStates.SelectedIndex == 0)
                return 1;
            else
                return cBoxStates.SelectedIndex + 4; //keys 2/3/4 aren't in the database.
        }
        #endregion
        
        #region Misc. UI Additions
        /// <summary>
        /// Disables alteration of irrelevant information. Data won't be deleted until the update is confirmed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxContactTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxContactTypes.SelectedIndex == 0)
            {
                //Sets up personal boxes
                tBoxCellPhone.Enabled = true;   cBoxYear.Enabled = true;
                cBoxMonth.Enabled = true;       cBoxDay.Enabled = true;
                tBoxHomePhone.Enabled = true;   tBoxCompany.Enabled = false;
                tBoxFax.Enabled = false;        tBoxJobTitle.Enabled = false;
                tBoxWorkPhone.Enabled = false;  tBoxWorkExt.Enabled = false;
            }
            else
            {
                //Sets up business boxes.
                tBoxCompany.Enabled = true;     tBoxFax.Enabled = true;
                tBoxJobTitle.Enabled = true;    tBoxWorkPhone.Enabled = true;
                tBoxWorkExt.Enabled = true;     cBoxYear.Enabled = false;
                cBoxMonth.Enabled = false;      cBoxDay.Enabled = false;
                tBoxCellPhone.Enabled = false;  tBoxHomePhone.Enabled = false;
            }
        }
        /// <summary>
        /// Omits the state option if not in the USA. Preserves State selection until update is confirmed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tBoxCountry_TextChanged(object sender, EventArgs e)
        {
            switch (tBoxCountry.Text.ToUpper())
            {
                case "US":
                case "USA":
                case "UNITED STATES":
                    cBoxStates.Enabled = true;
                    _isAmerican = true;
                    break;
                default:
                    cBoxStates.Enabled = false;
                    _isAmerican = false;
                    break;
            }
        }
        /// <summary>
        /// Automatically sets the Country to "USA" if a state is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cBoxStates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxStates.SelectedIndex != -1)
                tBoxCountry.Text = "USA";
        }
        /// <summary>
        /// Deletes the current Contact.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isNewContact)
            {
                DeleteForm delete = new DeleteForm(_key);
                delete.Show();
                this.Dispose(true);
            }
            else
                MessageBox.Show("This contact doesn't exist yet.");
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
        #endregion

        #region Printing
        
        private void printToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.PrintPage += new PrintPageEventHandler(PrintImage);
                document.Print();
            } 
        }
        private void printPreviewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview = new PrintPreviewDialog();
            document.PrintPage += new PrintPageEventHandler(PrintImage);
            preview.Document = document;
            preview.ShowDialog();
        }
        private void PrintImage(object sender, PrintPageEventArgs e)
        {
            int x = SystemInformation.WorkingArea.X;
            int y = SystemInformation.WorkingArea.Y;
            int width = this.Width;
            int height = this.Height;

            Rectangle bounds = new Rectangle(x, y, width, height);
            Bitmap image = new Bitmap(width, height);
            this.DrawToBitmap(image, bounds);

            Point p = new Point(100, 100);
            e.Graphics.DrawImage(image, p);
        }
        #endregion
    }
}