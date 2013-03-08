using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactDll
{
    public class PersonalContact : Contact
    {
        private string _homePhone, _cellPhone, _dateOfBirth;

        public PersonalContact()
            : base()
        {
            _homePhone = "";
            _cellPhone = "";
            _dateOfBirth = "";
            this._contactType = 1;
        }

        public PersonalContact(string lastNameP, string firstNameP,string courtesyTitleP, string address1P, string address2P, int stateKeyP, string cityP, string countryP, string zipP, string homePhoneP, string cellPhoneP, string emailP, string dateOfBirthP, string noteP)
            : base(lastNameP, firstNameP, courtesyTitleP, address1P, address2P, stateKeyP, cityP, countryP, zipP, emailP, noteP)
        {
            this._homePhone = homePhoneP;
            this._cellPhone = cellPhoneP;
            this._dateOfBirth = dateOfBirthP;
            this._contactType = 1;
        }

        #region Accessors
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }
        public string CellPhone
        {
            get { return _cellPhone; }
            set { _cellPhone = value; }
        }
        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        #endregion
    }
}
