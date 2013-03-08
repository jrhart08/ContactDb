using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactDll
{
    public class BusinessContact : Contact
    {
        private string _companyName, _jobTitle, _workPhone, _extension, _fax;

        public BusinessContact()
            : base()
        {
            _companyName = "";
            _jobTitle = "";
            _workPhone = "";
            _extension = "";
            _fax = "";
            this._contactType = 2;
        }

        public BusinessContact(string companyNameP, string jobTitleP, string lastNameP, string firstNameP, string courtesyTitleP, string address1P, string address2P, int stateKeyP, string cityP, string countryP, string zipP, string workPhoneP, string extensionP, string faxP, string emailP, string noteP)
            : base(lastNameP, firstNameP, courtesyTitleP, address1P, address2P, stateKeyP, cityP, countryP, zipP, emailP, noteP)
        {
            this._companyName = companyNameP;
            this._jobTitle = jobTitleP;
            this._workPhone = workPhoneP;
            this._extension = extensionP;
            this._fax = faxP;
            this._contactType = 2;
        }

        #region Accessors
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
        public string JobTitle
        {
            get { return _jobTitle; }
            set { _jobTitle = value; }
        }
        public string WorkPhone
        {
            get { return _workPhone; }
            set { _workPhone = value; }
        }
        public string Extension
        {
            get { return _extension; }
            set{_extension = value;}
        }
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        #endregion
    }
}
