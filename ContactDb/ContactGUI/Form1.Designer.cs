namespace ContactGUI
{
    partial class Form1
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
            this.btnAddContact = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.rbContactType = new System.Windows.Forms.RadioButton();
            this.rbFirstLast = new System.Windows.Forms.RadioButton();
            this.rbLastName = new System.Windows.Forms.RadioButton();
            this.rbFirstName = new System.Windows.Forms.RadioButton();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cBoxType = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tBoxLastName = new System.Windows.Forms.TextBox();
            this.tBoxFirstName = new System.Windows.Forms.TextBox();
            this.btnDetails = new System.Windows.Forms.Button();
            this.dgContacts = new System.Windows.Forms.DataGridView();
            this.lblMatches = new System.Windows.Forms.Label();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddContact
            // 
            this.btnAddContact.Location = new System.Drawing.Point(549, 345);
            this.btnAddContact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(75, 23);
            this.btnAddContact.TabIndex = 79;
            this.btnAddContact.Text = "Add Contact";
            this.btnAddContact.UseVisualStyleBackColor = true;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(11, 431);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(90, 50);
            this.btnReset.TabIndex = 78;
            this.btnReset.Text = "Refresh / Reset Filter";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // rbContactType
            // 
            this.rbContactType.AutoSize = true;
            this.rbContactType.Location = new System.Drawing.Point(11, 403);
            this.rbContactType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbContactType.Name = "rbContactType";
            this.rbContactType.Size = new System.Drawing.Size(89, 17);
            this.rbContactType.TabIndex = 76;
            this.rbContactType.TabStop = true;
            this.rbContactType.Text = "Contact Type";
            this.rbContactType.UseVisualStyleBackColor = true;
            this.rbContactType.Click += new System.EventHandler(this.rbContactType_Click);
            // 
            // rbFirstLast
            // 
            this.rbFirstLast.AutoSize = true;
            this.rbFirstLast.Location = new System.Drawing.Point(217, 351);
            this.rbFirstLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbFirstLast.Name = "rbFirstLast";
            this.rbFirstLast.Size = new System.Drawing.Size(100, 17);
            this.rbFirstLast.TabIndex = 75;
            this.rbFirstLast.TabStop = true;
            this.rbFirstLast.Text = "First/Last Name";
            this.rbFirstLast.UseVisualStyleBackColor = true;
            this.rbFirstLast.Click += new System.EventHandler(this.rbFirstLast_Click);
            // 
            // rbLastName
            // 
            this.rbLastName.AutoSize = true;
            this.rbLastName.Location = new System.Drawing.Point(11, 377);
            this.rbLastName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbLastName.Name = "rbLastName";
            this.rbLastName.Size = new System.Drawing.Size(76, 17);
            this.rbLastName.TabIndex = 74;
            this.rbLastName.TabStop = true;
            this.rbLastName.Text = "Last Name";
            this.rbLastName.UseVisualStyleBackColor = true;
            this.rbLastName.Click += new System.EventHandler(this.rbLastName_Click);
            // 
            // rbFirstName
            // 
            this.rbFirstName.AutoSize = true;
            this.rbFirstName.Location = new System.Drawing.Point(11, 350);
            this.rbFirstName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbFirstName.Name = "rbFirstName";
            this.rbFirstName.Size = new System.Drawing.Size(75, 17);
            this.rbFirstName.TabIndex = 73;
            this.rbFirstName.TabStop = true;
            this.rbFirstName.Text = "First Name";
            this.rbFirstName.UseVisualStyleBackColor = true;
            this.rbFirstName.Click += new System.EventHandler(this.rbFirstName_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(10, 316);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 72;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cBoxType
            // 
            this.cBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxType.FormattingEnabled = true;
            this.cBoxType.Items.AddRange(new object[] {
            "Personal",
            "Business"});
            this.cBoxType.Location = new System.Drawing.Point(112, 404);
            this.cBoxType.Name = "cBoxType";
            this.cBoxType.Size = new System.Drawing.Size(100, 21);
            this.cBoxType.TabIndex = 70;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(112, 431);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 50);
            this.btnSearch.TabIndex = 69;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tBoxLastName
            // 
            this.tBoxLastName.Location = new System.Drawing.Point(112, 376);
            this.tBoxLastName.Name = "tBoxLastName";
            this.tBoxLastName.Size = new System.Drawing.Size(100, 20);
            this.tBoxLastName.TabIndex = 68;
            this.tBoxLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBoxes_KeyPress);
            // 
            // tBoxFirstName
            // 
            this.tBoxFirstName.Location = new System.Drawing.Point(112, 350);
            this.tBoxFirstName.Name = "tBoxFirstName";
            this.tBoxFirstName.Size = new System.Drawing.Size(100, 20);
            this.tBoxFirstName.TabIndex = 67;
            this.tBoxFirstName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameBoxes_KeyPress);
            // 
            // btnDetails
            // 
            this.btnDetails.Location = new System.Drawing.Point(549, 317);
            this.btnDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(75, 23);
            this.btnDetails.TabIndex = 66;
            this.btnDetails.Text = "Details";
            this.btnDetails.UseVisualStyleBackColor = true;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // dgContacts
            // 
            this.dgContacts.AllowUserToAddRows = false;
            this.dgContacts.AllowUserToDeleteRows = false;
            this.dgContacts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContacts.Location = new System.Drawing.Point(10, 26);
            this.dgContacts.Name = "dgContacts";
            this.dgContacts.ReadOnly = true;
            this.dgContacts.RowTemplate.Height = 24;
            this.dgContacts.Size = new System.Drawing.Size(614, 284);
            this.dgContacts.TabIndex = 80;
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(110, 321);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(99, 13);
            this.lblMatches.TabIndex = 85;
            this.lblMatches.Text = "Matching Contacts:";
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(549, 430);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 50);
            this.btnSelectAll.TabIndex = 87;
            this.btnSelectAll.Text = "Search All Contacts";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(636, 24);
            this.menuStrip1.TabIndex = 88;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(636, 488);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.lblMatches);
            this.Controls.Add(this.dgContacts);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.rbContactType);
            this.Controls.Add(this.rbFirstLast);
            this.Controls.Add(this.rbLastName);
            this.Controls.Add(this.rbFirstName);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cBoxType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tBoxLastName);
            this.Controls.Add(this.tBoxFirstName);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Contact Manager";
            ((System.ComponentModel.ISupportInitialize)(this.dgContacts)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton rbContactType;
        private System.Windows.Forms.RadioButton rbFirstLast;
        private System.Windows.Forms.RadioButton rbLastName;
        private System.Windows.Forms.RadioButton rbFirstName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cBoxType;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tBoxLastName;
        private System.Windows.Forms.TextBox tBoxFirstName;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.DataGridView dgContacts;
        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

