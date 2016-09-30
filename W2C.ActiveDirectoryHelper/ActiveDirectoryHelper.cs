using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace W2C.ActiveDirectoryHelper
{
    public class ActiveDirectoryHelper
    {
        /// <summary>
        /// The _directory entry
        /// </summary>
        private DirectoryEntry _directoryEntry = null;
        /// <summary>
        /// Gets the search root.
        /// </summary>
        /// <value>The search root.</value>
        private DirectoryEntry SearchRoot
        {
            get
            {
                if (_directoryEntry == null)
                {

                    _directoryEntry = new DirectoryEntry(LDAPPath, LDAPUser, LDAPPassword, AuthenticationTypes.Secure);

                }

                return _directoryEntry;

            }

        }



        /// <summary>
        /// Gets the LDAP path.
        /// </summary>
        /// <value>The LDAP path.</value>
        private String LDAPPath
        {

            get
            {

                return ConfigurationManager.AppSettings["LDAPPath"];

            }

        }



        /// <summary>
        /// Gets the LDAP user.
        /// </summary>
        /// <value>The LDAP user.</value>
        private String LDAPUser
        {

            get
            {

                return ConfigurationManager.AppSettings["LDAPUser"];

            }

        }



        /// <summary>
        /// Gets the LDAP password.
        /// </summary>
        /// <value>The LDAP password.</value>
        private String LDAPPassword
        {

            get
            {

                return ConfigurationManager.AppSettings["LDAPPassword"];

            }

        }



        /// <summary>
        /// Gets the LDAP domain.
        /// </summary>
        /// <value>The LDAP domain.</value>
        private String LDAPDomain
        {

            get
            {

                return ConfigurationManager.AppSettings["LDAPDomain"];

            }

        }



        /// <summary>
        /// Gets the full name of the user by.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ADUserDetail.</returns>
        internal ADUserDetail GetUserByFullName(String userName)
        {

            try
            {

                _directoryEntry = null;

                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

                directorySearch.Filter = "(&(objectClass=user)(cn=" + userName + "))";

                SearchResult results = directorySearch.FindOne();



                if (results != null)
                {

                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);



                    return ADUserDetail.GetUser(user);

                }

                else
                {

                    return null;

                }

            }

            catch (Exception ex)
            {

                return null;

            }

        }



        /// <summary>
        /// Gets the name of the user by login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>ADUserDetail.</returns>
        public ADUserDetail GetUserByLoginName(String userName)
        {

            try
            {

                _directoryEntry = null;

                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

                directorySearch.Filter = "(&(objectClass=user)(SAMAccountName=" + userName + "))";

                SearchResult results = directorySearch.FindOne();



                if (results != null)
                {

                    DirectoryEntry user = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);

                    return ADUserDetail.GetUser(user);

                }

                return null;

            }

            catch (Exception ex)
            {

                return null;

            }

        }





        /// <summary>
        /// This function will take a DL or Group name and return list of users
        /// </summary>
        /// <param name="groupName">Name of the group.</param>
        /// <returns>List&lt;ADUserDetail&gt;.</returns>

        public List<ADUserDetail> GetUserFromGroup(String groupName)
        {

            List<ADUserDetail> userlist = new List<ADUserDetail>();

            try
            {

                _directoryEntry = null;

                DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

                directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + groupName + "))";

                SearchResult results = directorySearch.FindOne();

                if (results != null)
                {



                    DirectoryEntry deGroup = new DirectoryEntry(results.Path, LDAPUser, LDAPPassword);

                    System.DirectoryServices.PropertyCollection pColl = deGroup.Properties;

                    int count = pColl["member"].Count;





                    for (int i = 0; i < count; i++)
                    {

                        string respath = results.Path;

                        string[] pathnavigate = respath.Split("CN".ToCharArray());

                        respath = pathnavigate[0];

                        string objpath = pColl["member"][i].ToString();

                        string path = respath + objpath;





                        DirectoryEntry user = new DirectoryEntry(path, LDAPUser, LDAPPassword);

                        ADUserDetail userobj = ADUserDetail.GetUser(user);

                        userlist.Add(userobj);

                        user.Close();

                    }

                }

                return userlist;

            }

            catch (Exception ex)
            {

                return userlist;

            }



        }



        #region Get user with First Name



        /// <summary>
        /// Gets the first name of the users by.
        /// </summary>
        /// <param name="fName">Name of the f.</param>
        /// <returns>List&lt;ADUserDetail&gt;.</returns>
        public List<ADUserDetail> GetUsersByFirstName(string fName)
        {



            //UserProfile user;

            List<ADUserDetail> userlist = new List<ADUserDetail>();

            string filter = "";



            _directoryEntry = null;

            DirectorySearcher directorySearch = new DirectorySearcher(SearchRoot);

            directorySearch.Asynchronous = true;

            directorySearch.CacheResults = true;

            filter = string.Format("(givenName={0}*", fName);

            //            filter = "(&(objectClass=user)(objectCategory=person)(givenName="+fName+ "*))";





            directorySearch.Filter = filter;



            SearchResultCollection userCollection = directorySearch.FindAll();

            foreach (SearchResult users in userCollection)
            {

                DirectoryEntry userEntry = new DirectoryEntry(users.Path, LDAPUser, LDAPPassword);

                ADUserDetail userInfo = ADUserDetail.GetUser(userEntry);



                userlist.Add(userInfo);



            }



            directorySearch.Filter = "(&(objectClass=group)(SAMAccountName=" + fName + "*))";

            SearchResultCollection results = directorySearch.FindAll();

            if (results != null)
            {



                foreach (SearchResult r in results)
                {

                    DirectoryEntry deGroup = new DirectoryEntry(r.Path, LDAPUser, LDAPPassword);



                    ADUserDetail agroup = ADUserDetail.GetUser(deGroup);

                    userlist.Add(agroup);

                }



            }

            return userlist;

        }



        #endregion


        #region AddUserToGroup

        /// <summary>
        /// Adds the user to group.
        /// </summary>
        /// <param name="userlogin">The userlogin.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddUserToGroup(string userlogin, string groupName)
        {

            try
            {

                _directoryEntry = null;

                ADManager admanager = new ADManager(LDAPDomain, LDAPUser, LDAPPassword);

                admanager.AddUserToGroup(userlogin, groupName);

                return true;

            }

            catch (Exception ex)
            {

                return false;

            }

        }

        #endregion



        #region RemoveUserToGroup

        /// <summary>
        /// Removes the user to group.
        /// </summary>
        /// <param name="userlogin">The userlogin.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveUserToGroup(string userlogin, string groupName)
        {

            try
            {

                _directoryEntry = null;

                ADManager admanager = new ADManager("xxx", LDAPUser, LDAPPassword);

                admanager.RemoveUserFromGroup(userlogin, groupName);

                return true;

            }

            catch (Exception ex)
            {

                return false;

            }

        }

        #endregion


        /// <summary>
        /// Determines whether the specified user name is authenticated.
        /// </summary>
        /// <param name="UserName">Name of the user.</param>
        /// <param name="Password">The password.</param>
        /// <returns><c>true</c> if the specified user name is authenticated; otherwise, <c>false</c>.</returns>
        public bool IsAuthenticated(string UserName, string Password)
        {
            //Split the userId from the domain name
            UserName = Regex.Replace(UserName, ".*\\\\(.*)", "$1", RegexOptions.None);
            DirectoryEntry entry = new DirectoryEntry(LDAPPath, UserName, Password);
            DirectorySearcher search = new DirectorySearcher(entry);
            SearchResult result = search.FindOne();
            //// To check whether the User exists or not.  
            if (null == result)
                return false;

            return true;
        }


        /// <summary>
        /// Users the email.
        /// </summary>
        /// <param name="uid">The uid.</param>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> userEmail(string uid)
        {
            List<string> emailaddress = new List<string>();

            DirectorySearcher dirSearcher = new DirectorySearcher();
            DirectoryEntry entry = new DirectoryEntry(dirSearcher.SearchRoot.Path);
            dirSearcher.Filter = "(&(objectClass=user)(objectcategory=person)(mail=" + uid + "*))";

            string propName = "mail";

            SearchResultCollection results = dirSearcher.FindAll();

            for (int i = 0; i < results.Count; i++)
            {
                emailaddress.Add(results[i].Properties[propName][0].ToString());
            }
            return emailaddress;
        }
    }
}
