using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ContactDll;

namespace ContactListDll
{
    public static class ContactManager
    {
        //Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\bin\Debug\ContactManager.mdf;Integrated Security=True;Connect Timeout=30
        //Data Source=(LocalDB)\v11.0;AttachDbFilename="F:\Media\Documents\ITSE 1430\ContactDb\ContactListDll\bin\Debug\ContactManager.mdf";Integrated Security=True;Connect Timeout=30
        private const string CONNECT_STRING = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=F:\Media\Documents\ITSE 1430\ContactDb\ContactListDll\bin\Debug\ContactManager.mdf;Integrated Security=True;Connect Timeout=30";

        private static Dictionary<int, Contact> _contacts = new Dictionary<int,Contact>();
        private static SqlConnection _connection = new SqlConnection(CONNECT_STRING);
        private static SqlCommand _command = null;
        private static SqlDataReader _reader = null;

        //Filtering parameters
        private static int _current; 
        private static string _lastName, _firstName;
        
        #region Accessors
        public static Dictionary<int, Contact> Contacts
        {
            get { return _contacts; }
            set { _contacts = value; }
        }
        public static string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public static string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        #endregion

        #region Select Queries
        /// <summary>
        /// Searches with the appropriate Stored Procedure selection.
        /// </summary>
        /// <param name="procedure"></param>
        public static void SearchBy(string procedure)
        {
            _contacts.Clear();
            //Loads the requested Select-type Stored Procedure.
            _command = new SqlCommand(procedure, _connection);
            _command.CommandType = CommandType.StoredProcedure;

            switch (procedure) //Sets up parameters if needed.
            {
                case "SearchByFirstName":
                    _command.Parameters.Add(new SqlParameter("@FirstName", _firstName));
                    break;
                case "SearchByLastName":
                    _command.Parameters.Add(new SqlParameter("@LastName", _lastName));
                    break;
                case"SearchByFirstAndLastName":
                    _command.Parameters.Add(new SqlParameter("@FirstName", _firstName));
                    _command.Parameters.Add(new SqlParameter("@LastName", _lastName));
                    break;
            }
            //Reading the data into the Contact dictionary
            _connection.Open();
            _reader = _command.ExecuteReader();
            while (_reader.Read())
            {
                if (_reader["ContactTypeKey"].ToString() == "1")
                    _contacts.Add(Convert.ToInt32(_reader["ContactKey"]),
                        new PersonalContact(_reader["LastName"].ToString(),
                            _reader["FirstName"].ToString(), _reader["TitleOfCourtesy"].ToString(), _reader["Address_Line_1"].ToString(),
                            _reader["Address_Line_2"].ToString(), Convert.ToInt32(_reader["StateKey"]), _reader["City"].ToString(),
                            _reader["Country"].ToString(), _reader["ZipCode"].ToString(), _reader["HomePhone"].ToString(), _reader["CellPhone"].ToString(),
                            _reader["EMail"].ToString(), _reader["BirthDate"].ToString(), _reader["Note"].ToString()));
                else
                    _contacts.Add(Convert.ToInt32(_reader["ContactKey"]),
                        new BusinessContact(_reader["Company"].ToString(), _reader["Ttile"].ToString(),
                            _reader["LastName"].ToString(), _reader["FirstName"].ToString(), _reader["TitleOfCourtesy"].ToString(),
                            _reader["Address_Line_1"].ToString(), _reader["Address_Line_2"].ToString(), Convert.ToInt32(_reader["StateKey"]),
                            _reader["City"].ToString(), _reader["Country"].ToString(), _reader["ZipCode"].ToString(), _reader["BizPhone"].ToString(),
                            _reader["Extension"].ToString(), _reader["Fax"].ToString(), _reader["EMail"].ToString(), _reader["Note"].ToString()));
            }
            _reader.Close();
            _connection.Close();
        }
        /// <summary>
        /// Retrieves the key for the last row (contact) in the database.
        /// </summary>
        /// <returns></returns>
        public static int GetLastContactKey()
        {
            _command = new SqlCommand("SELECT MAX(ContactKey) AS ContactKey FROM tblContact", _connection); //getting the last ContactKey
            
            _connection.Open();
            _reader = _command.ExecuteReader();
            _reader.Read();
            int index = Convert.ToInt32(_reader[0]);
            _reader.Close();
            _connection.Close();

            return index;
        }
        #endregion

        #region Data-Manipulation Procedures
        /// <summary>
        /// Inserts a new contact into the database.
        /// </summary>
        public static void InsertContact()
        {
            _current = _contacts.Keys.Max();
            _command = new SqlCommand("InsertContact", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            AddParams();

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        /// <summary>
        /// Updates the selected contact.
        /// </summary>
        /// <param name="key"></param>
        public static void UpdateContact(int key)
        {
            _current = key;
            _command = new SqlCommand("UpdateContact", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@ContactKey", _current));
            AddParams();

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        /// <summary>
        /// Deletes the selected contact.
        /// </summary>
        /// <param name="key"></param>
        public static void DeleteContact(int key)
        {
            _current = key;
            _command = new SqlCommand("DelContact", _connection);
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add(new SqlParameter("@ContactKey", _current));

            _connection.Open();
            _command.ExecuteNonQuery();
            _connection.Close();
        }
        /// <summary>
        /// Adds the parameters for Insert/Update methods.
        /// </summary>
        private static void AddParams()
        {
            Contact temp = _contacts[_current];
            _command.Parameters.Add(new SqlParameter("@FirstName", temp.FirstName));
            _command.Parameters.Add(new SqlParameter("@LastName", temp.LastName));
            _command.Parameters.Add(new SqlParameter("@Address_Line_1", temp.AddressLine1));
            _command.Parameters.Add(new SqlParameter("@Address_Line_2", temp.AddressLine2));
            _command.Parameters.Add(new SqlParameter("@City", temp.City));
            _command.Parameters.Add(new SqlParameter("@StateKey", temp.StateKey));
            _command.Parameters.Add(new SqlParameter("@ZipCode", temp.Zip));
            _command.Parameters.Add(new SqlParameter("@Country", temp.Country));
            _command.Parameters.Add(new SqlParameter("@EMail", temp.Email));
            _command.Parameters.Add(new SqlParameter("@ContactKeyType", temp.ContactType));
            _command.Parameters.Add(new SqlParameter("@TitleOfCourtesy", temp.CourtesyTitle));
            _command.Parameters.Add(new SqlParameter("@Note", temp.Note));

            if (temp is PersonalContact)
            {
                PersonalContact tempP = temp as PersonalContact;

                _command.Parameters.Add(new SqlParameter("@BirthDate", tempP.DateOfBirth));
                _command.Parameters.Add(new SqlParameter("@HomePhone", tempP.HomePhone));
                _command.Parameters.Add(new SqlParameter("@CellPhone", tempP.CellPhone));
                //Doesn't return non-necessary data.
                _command.Parameters.Add(new SqlParameter("@Company", ""));
                _command.Parameters.Add(new SqlParameter("@Ttile", ""));
                _command.Parameters.Add(new SqlParameter("@BizPhone", ""));
                _command.Parameters.Add(new SqlParameter("@Fax", ""));
                _command.Parameters.Add(new SqlParameter("@Extension", ""));
            }
            else
            {
                BusinessContact tempB = temp as BusinessContact;

                _command.Parameters.Add(new SqlParameter("@Company", tempB.CompanyName));
                _command.Parameters.Add(new SqlParameter("@Ttile", tempB.JobTitle));
                _command.Parameters.Add(new SqlParameter("@BizPhone", tempB.WorkPhone));
                _command.Parameters.Add(new SqlParameter("@Fax", tempB.Fax));
                _command.Parameters.Add(new SqlParameter("@Extension", tempB.Extension));
                //Doesn't return non-necessary data
                _command.Parameters.Add(new SqlParameter("@BirthDate", ""));
                _command.Parameters.Add(new SqlParameter("@HomePhone", ""));
                _command.Parameters.Add(new SqlParameter("@CellPhone", ""));
            }
        }
        #endregion
    }
}