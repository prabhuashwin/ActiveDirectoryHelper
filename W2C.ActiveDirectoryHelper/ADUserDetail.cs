using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2C.ActiveDirectoryHelper
{
    /// <summary>
    /// Class ADUserDetail.
    /// </summary>
    public class ADUserDetail
    {

        /// <summary>
        /// The _first name
        /// </summary>
        private String _firstName;

        /// <summary>
        /// The _middle name
        /// </summary>
        private String _middleName;

        /// <summary>
        /// The _last name
        /// </summary>
        private String _lastName;

        /// <summary>
        /// The _login name
        /// </summary>
        private String _loginName;

        /// <summary>
        /// The _login name with domain
        /// </summary>
        private String _loginNameWithDomain;

        /// <summary>
        /// The _street address
        /// </summary>
        private String _streetAddress;

        /// <summary>
        /// The _city
        /// </summary>
        private String _city;

        /// <summary>
        /// The _state
        /// </summary>
        private String _state;

        /// <summary>
        /// The _postal code
        /// </summary>
        private String _postalCode;

        /// <summary>
        /// The _country
        /// </summary>
        private String _country;

        /// <summary>
        /// The _home phone
        /// </summary>
        private String _homePhone;

        /// <summary>
        /// The _extension
        /// </summary>
        private String _extension;

        /// <summary>
        /// The _mobile
        /// </summary>
        private String _mobile;

        /// <summary>
        /// The _fax
        /// </summary>
        private String _fax;

        /// <summary>
        /// The _email address
        /// </summary>
        private String _emailAddress;

        /// <summary>
        /// The _title
        /// </summary>
        private String _title;

        /// <summary>
        /// The _company
        /// </summary>
        private String _company;

        /// <summary>
        /// The _manager
        /// </summary>
        private String _manager;

        /// <summary>
        /// The _manager name
        /// </summary>
        private String _managerName;

        /// <summary>
        /// The _department
        /// </summary>
        private String _department;

        /// <summary>
        /// The _member of
        /// </summary>
        private String _memberOf;

        /// <summary>
        /// Gets the department.
        /// </summary>
        /// <value>The department.</value>
        public String Department
        {

            get { return _department; }

        }



        /// <summary>
        /// Gets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public String FirstName
        {

            get { return _firstName; }

        }



        /// <summary>
        /// Gets the name of the middle.
        /// </summary>
        /// <value>The name of the middle.</value>
        public String MiddleName
        {

            get { return _middleName; }

        }



        /// <summary>
        /// Gets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public String LastName
        {

            get { return _lastName; }

        }



        /// <summary>
        /// Gets the name of the login.
        /// </summary>
        /// <value>The name of the login.</value>
        public String LoginName
        {

            get { return _loginName; }

        }



        /// <summary>
        /// Gets the login name with domain.
        /// </summary>
        /// <value>The login name with domain.</value>
        public String LoginNameWithDomain
        {

            get { return _loginNameWithDomain; }

        }



        /// <summary>
        /// Gets the street address.
        /// </summary>
        /// <value>The street address.</value>
        public String StreetAddress
        {

            get { return _streetAddress; }

        }



        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <value>The city.</value>
        public String City
        {

            get { return _city; }

        }



        /// <summary>
        /// Gets the state.
        /// </summary>
        /// <value>The state.</value>
        public String State
        {

            get { return _state; }

        }



        /// <summary>
        /// Gets the postal code.
        /// </summary>
        /// <value>The postal code.</value>
        public String PostalCode
        {

            get { return _postalCode; }

        }



        /// <summary>
        /// Gets the country.
        /// </summary>
        /// <value>The country.</value>
        public String Country
        {

            get { return _country; }

        }



        /// <summary>
        /// Gets the home phone.
        /// </summary>
        /// <value>The home phone.</value>
        public String HomePhone
        {

            get { return _homePhone; }

        }



        /// <summary>
        /// Gets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public String Extension
        {

            get { return _extension; }

        }



        /// <summary>
        /// Gets the mobile.
        /// </summary>
        /// <value>The mobile.</value>
        public String Mobile
        {

            get { return _mobile; }

        }



        /// <summary>
        /// Gets the fax.
        /// </summary>
        /// <value>The fax.</value>
        public String Fax
        {

            get { return _fax; }

        }



        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <value>The email address.</value>
        public String EmailAddress
        {

            get { return _emailAddress; }

        }



        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public String Title
        {

            get { return _title; }

        }



        /// <summary>
        /// Gets the company.
        /// </summary>
        /// <value>The company.</value>
        public String Company
        {

            get { return _company; }

        }




        /// <summary>
        /// Gets the manager.
        /// </summary>
        /// <value>The manager.</value>
        public ADUserDetail Manager
        {

            get
            {

                if (!String.IsNullOrEmpty(_managerName))
                {

                    ActiveDirectoryHelper ad = new ActiveDirectoryHelper();

                    return ad.GetUserByFullName(_managerName);

                }

                return null;

            }

        }


        /// <summary>
        /// Gets the name of the manager.
        /// </summary>
        /// <value>The name of the manager.</value>
        public String ManagerName
        {
            get { return _managerName; }
        }

        /// <summary>
        /// Gets the member of.
        /// </summary>
        /// <value>The member of.</value>
        public String MemberOf
        {
            get { return _memberOf; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ADUserDetail"/> class.
        /// </summary>
        /// <param name="directoryUser">The directory user.</param>
        private ADUserDetail(DirectoryEntry directoryUser)
        {



            String domainAddress;

            String domainName;

            _firstName = GetProperty(directoryUser, ADProperties.FIRSTNAME);

            _middleName = GetProperty(directoryUser, ADProperties.MIDDLENAME);

            _lastName = GetProperty(directoryUser, ADProperties.LASTNAME);

            _loginName = GetProperty(directoryUser, ADProperties.LOGINNAME);

            String userPrincipalName = GetProperty(directoryUser, ADProperties.USERPRINCIPALNAME);

            if (!string.IsNullOrEmpty(userPrincipalName))
            {

                domainAddress = userPrincipalName.Split('@')[1];

            }

            else
            {

                domainAddress = String.Empty;

            }



            if (!string.IsNullOrEmpty(domainAddress))
            {

                domainName = domainAddress.Split('.').First();

            }

            else
            {

                domainName = String.Empty;

            }

            _loginNameWithDomain = String.Format(@"{0}\{1}", domainName, _loginName);

            _streetAddress = GetProperty(directoryUser, ADProperties.STREETADDRESS);

            _city = GetProperty(directoryUser, ADProperties.CITY);

            _state = GetProperty(directoryUser, ADProperties.STATE);

            _postalCode = GetProperty(directoryUser, ADProperties.POSTALCODE);

            _country = GetProperty(directoryUser, ADProperties.COUNTRY);

            _company = GetProperty(directoryUser, ADProperties.COMPANY);

            _department = GetProperty(directoryUser, ADProperties.DEPARTMENT);

            _homePhone = GetProperty(directoryUser, ADProperties.HOMEPHONE);

            _extension = GetProperty(directoryUser, ADProperties.EXTENSION);

            _mobile = GetProperty(directoryUser, ADProperties.MOBILE);

            _fax = GetProperty(directoryUser, ADProperties.FAX);

            _emailAddress = GetProperty(directoryUser, ADProperties.EMAILADDRESS);

            _title = GetProperty(directoryUser, ADProperties.TITLE);

            _manager = GetProperty(directoryUser, ADProperties.MANAGER);

            if (!String.IsNullOrEmpty(_manager))
            {

                String[] managerArray = _manager.Split(',');

                _managerName = managerArray[0].Replace("CN=", "");

            }

            _memberOf = GetProperty(directoryUser, ADProperties.MEMBEROF);

        }





        /// <summary>
        /// Gets the property.
        /// </summary>
        /// <param name="userDetail">The user detail.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>String.</returns>
        private static String GetProperty(DirectoryEntry userDetail, String propertyName)
        {

            if (userDetail.Properties.Contains(propertyName))
            {

                return userDetail.Properties[propertyName][0].ToString();

            }

            else
            {

                return string.Empty;

            }

        }



        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="directoryUser">The directory user.</param>
        /// <returns>ADUserDetail.</returns>
        public static ADUserDetail GetUser(DirectoryEntry directoryUser)
        {

            return new ADUserDetail(directoryUser);

        }

    }
}
