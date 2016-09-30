using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2C.ActiveDirectoryHelper
{
    /// <summary>
    /// Class ADManager.
    /// </summary>
    public class ADManager
    {
        /// <summary>
        /// The context
        /// </summary>
        PrincipalContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ADManager"/> class.
        /// </summary>
        public ADManager()
        {
            context = new PrincipalContext(ContextType.Machine, "xxx", "xxx", "xxx");
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="ADManager"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="container">The container.</param>
        public ADManager(string domain, string container)
        {

            context = new PrincipalContext(ContextType.Domain, domain, container);

        }



        /// <summary>
        /// Initializes a new instance of the <see cref="ADManager"/> class.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        public ADManager(string domain, string username, string password)
        {

            context = new PrincipalContext(ContextType.Domain, username, password);

        }



        /// <summary>
        /// Adds the user to group.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddUserToGroup(string userName, string groupName)
        {

            bool done = false;

            GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);

            if (group == null)
            {

                group = new GroupPrincipal(context, groupName);

            }

            UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);

            if (user != null & group != null)
            {

                group.Members.Add(user);

                group.Save();

                done = (user.IsMemberOf(group));

            }

            return done;

        }





        /// <summary>
        /// Removes the user from group.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool RemoveUserFromGroup(string userName, string groupName)
        {

            bool done = false;

            UserPrincipal user = UserPrincipal.FindByIdentity(context, userName);

            GroupPrincipal group = GroupPrincipal.FindByIdentity(context, groupName);

            if (user != null & group != null)
            {

                group.Members.Remove(user);

                group.Save();

                done = !(user.IsMemberOf(group));

            }

            return done;

        }

    }
}
