using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactDll
{
    public class Contact
    {
        protected int _stateKey, _contactType;
        protected string _lastName,
                         _firstName,
                         _courtesyTitle,
                         _addressLine1,
                         _addressLine2,
                         _city,
                         _country,
                         _zip,
                         _email,
                         _note;
        
        public Contact()
        {
            _lastName = "";
            _firstName = "";
            _addressLine1 = "";
            _addressLine2 = "";
            _stateKey = 56;
            _city = "";
            _country = "";
            _email = "";
            _note = "";
        }

        public Contact(string lastNameP, string firstNameP, string courtesyTitleP, string address1P, string address2P, int stateKeyP, string cityP, string countryP, string zipP, string emailP, string noteP)
        {
            this._lastName = lastNameP;
            this._firstName = firstNameP;
            this._addressLine1 = address1P;
            this._addressLine2 = address2P;
            this._stateKey = stateKeyP;
            this._city = cityP;
            this._country = countryP;
            this._email = emailP;
            this._note = noteP;
            this._courtesyTitle = courtesyTitleP;
            this._zip = zipP;
        }

        #region Accessors
        public int ContactType
        {
            get { return _contactType; }
            set { _contactType = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string CourtesyTitle
        {
            get { return _courtesyTitle; }
            set { _courtesyTitle = value; }
        }
        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }
        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }
        public int StateKey
        {
            get { return _stateKey; }
            set { _stateKey = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        #endregion
    }
}
