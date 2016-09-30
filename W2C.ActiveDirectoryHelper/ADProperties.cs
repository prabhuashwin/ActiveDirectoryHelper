using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2C.ActiveDirectoryHelper
{
    /// <summary>
    /// Class ADProperties.
    /// </summary>
    public class ADProperties
    {

        /// <summary>
        /// The objectclass
        /// </summary>
        public const String OBJECTCLASS = "objectClass";
        /// <summary>
        /// The containername
        /// </summary>
        public const String CONTAINERNAME = "cn";
        /// <summary>
        /// The lastname
        /// </summary>
        public const String LASTNAME = "sn";
        /// <summary>
        /// The countrynotation
        /// </summary>
        public const String COUNTRYNOTATION = "c";
        /// <summary>
        /// The city
        /// </summary>
        public const String CITY = "l";
        /// <summary>
        /// The state
        /// </summary>
        public const String STATE = "st";
        /// <summary>
        /// The title
        /// </summary>
        public const String TITLE = "title";
        /// <summary>
        /// The postalcode
        /// </summary>
        public const String POSTALCODE = "postalCode";
        /// <summary>
        /// The physicaldeliveryofficename
        /// </summary>
        public const String PHYSICALDELIVERYOFFICENAME = "physicalDeliveryOfficeName";
        /// <summary>
        /// The firstname
        /// </summary>
        public const String FIRSTNAME = "givenName";
        /// <summary>
        /// The middlename
        /// </summary>
        public const String MIDDLENAME = "initials";
        /// <summary>
        /// The distinguishedname
        /// </summary>
        public const String DISTINGUISHEDNAME = "distinguishedName";
        /// <summary>
        /// The instancetype
        /// </summary>
        public const String INSTANCETYPE = "instanceType";
        /// <summary>
        /// The whencreated
        /// </summary>
        public const String WHENCREATED = "whenCreated";
        /// <summary>
        /// The whenchanged
        /// </summary>
        public const String WHENCHANGED = "whenChanged";
        /// <summary>
        /// The displayname
        /// </summary>
        public const String DISPLAYNAME = "displayName";
        /// <summary>
        /// The usncreated
        /// </summary>
        public const String USNCREATED = "uSNCreated";
        /// <summary>
        /// The memberof
        /// </summary>
        public const String MEMBEROF = "memberOf";
        /// <summary>
        /// The usnchanged
        /// </summary>
        public const String USNCHANGED = "uSNChanged";
        /// <summary>
        /// The country
        /// </summary>
        public const String COUNTRY = "co";
        /// <summary>
        /// The department
        /// </summary>
        public const String DEPARTMENT = "department";
        /// <summary>
        /// The company
        /// </summary>
        public const String COMPANY = "company";
        /// <summary>
        /// The proxyaddresses
        /// </summary>
        public const String PROXYADDRESSES = "proxyAddresses";
        /// <summary>
        /// The streetaddress
        /// </summary>
        public const String STREETADDRESS = "streetAddress";
        /// <summary>
        /// The directreports
        /// </summary>
        public const String DIRECTREPORTS = "directReports";
        /// <summary>
        /// The name
        /// </summary>
        public const String NAME = "name";
        /// <summary>
        /// The objectguid
        /// </summary>
        public const String OBJECTGUID = "objectGUID";
        /// <summary>
        /// The useraccountcontrol
        /// </summary>
        public const String USERACCOUNTCONTROL = "userAccountControl";
        /// <summary>
        /// The badpwdcount
        /// </summary>
        public const String BADPWDCOUNT = "badPwdCount";
        /// <summary>
        /// The codepage
        /// </summary>
        public const String CODEPAGE = "codePage";
        /// <summary>
        /// The countrycode
        /// </summary>
        public const String COUNTRYCODE = "countryCode";
        /// <summary>
        /// The badpasswordtime
        /// </summary>
        public const String BADPASSWORDTIME = "badPasswordTime";
        /// <summary>
        /// The lastlogoff
        /// </summary>
        public const String LASTLOGOFF = "lastLogoff";
        /// <summary>
        /// The lastlogon
        /// </summary>
        public const String LASTLOGON = "lastLogon";
        /// <summary>
        /// The pwdlastset
        /// </summary>
        public const String PWDLASTSET = "pwdLastSet";
        /// <summary>
        /// The primarygroupid
        /// </summary>
        public const String PRIMARYGROUPID = "primaryGroupID";
        /// <summary>
        /// The objectsid
        /// </summary>
        public const String OBJECTSID = "objectSid";
        /// <summary>
        /// The admincount
        /// </summary>
        public const String ADMINCOUNT = "adminCount";
        /// <summary>
        /// The accountexpires
        /// </summary>
        public const String ACCOUNTEXPIRES = "accountExpires";
        /// <summary>
        /// The logoncount
        /// </summary>
        public const String LOGONCOUNT = "logonCount";
        /// <summary>
        /// The loginname
        /// </summary>
        public const String LOGINNAME = "sAMAccountName";
        /// <summary>
        /// The samaccounttype
        /// </summary>
        public const String SAMACCOUNTTYPE = "sAMAccountType";
        /// <summary>
        /// The showinaddressbook
        /// </summary>
        public const String SHOWINADDRESSBOOK = "showInAddressBook";
        /// <summary>
        /// The legacyexchangedn
        /// </summary>
        public const String LEGACYEXCHANGEDN = "legacyExchangeDN";
        /// <summary>
        /// The userprincipalname
        /// </summary>
        public const String USERPRINCIPALNAME = "userPrincipalName";
        /// <summary>
        /// The extension
        /// </summary>
        public const String EXTENSION = "ipPhone";
        /// <summary>
        /// The serviceprincipalname
        /// </summary>
        public const String SERVICEPRINCIPALNAME = "servicePrincipalName";
        /// <summary>
        /// The objectcategory
        /// </summary>
        public const String OBJECTCATEGORY = "objectCategory";
        /// <summary>
        /// The dscorepropagationdata
        /// </summary>
        public const String DSCOREPROPAGATIONDATA = "dSCorePropagationData";
        /// <summary>
        /// The lastlogontimestamp
        /// </summary>
        public const String LASTLOGONTIMESTAMP = "lastLogonTimestamp";
        /// <summary>
        /// The emailaddress
        /// </summary>
        public const String EMAILADDRESS = "mail";
        /// <summary>
        /// The manager
        /// </summary>
        public const String MANAGER = "manager";
        /// <summary>
        /// The mobile
        /// </summary>
        public const String MOBILE = "mobile";
        /// <summary>
        /// The pager
        /// </summary>
        public const String PAGER = "pager";
        /// <summary>
        /// The fax
        /// </summary>
        public const String FAX = "facsimileTelephoneNumber";
        /// <summary>
        /// The homephone
        /// </summary>
        public const String HOMEPHONE = "homePhone";
        /// <summary>
        /// The msexchuseraccountcontrol
        /// </summary>
        public const String MSEXCHUSERACCOUNTCONTROL = "msExchUserAccountControl";
        /// <summary>
        /// The mdbusedefaults
        /// </summary>
        public const String MDBUSEDEFAULTS = "mDBUseDefaults";
        /// <summary>
        /// The msexchmailboxsecuritydescriptor
        /// </summary>
        public const String MSEXCHMAILBOXSECURITYDESCRIPTOR = "msExchMailboxSecurityDescriptor";
        /// <summary>
        /// The homemdb
        /// </summary>
        public const String HOMEMDB = "homeMDB";
        /// <summary>
        /// The msexchpoliciesincluded
        /// </summary>
        public const String MSEXCHPOLICIESINCLUDED = "msExchPoliciesIncluded";
        /// <summary>
        /// The homemta
        /// </summary>
        public const String HOMEMTA = "homeMTA";
        /// <summary>
        /// The msexchrecipienttypedetails
        /// </summary>
        public const String MSEXCHRECIPIENTTYPEDETAILS = "msExchRecipientTypeDetails";
        /// <summary>
        /// The mailnickname
        /// </summary>
        public const String MAILNICKNAME = "mailNickname";
        /// <summary>
        /// The msexchhomeservername
        /// </summary>
        public const String MSEXCHHOMESERVERNAME = "msExchHomeServerName";
        /// <summary>
        /// The msexchversion
        /// </summary>
        public const String MSEXCHVERSION = "msExchVersion";
        /// <summary>
        /// The msexchrecipientdisplaytype
        /// </summary>
        public const String MSEXCHRECIPIENTDISPLAYTYPE = "msExchRecipientDisplayType";
        /// <summary>
        /// The msexchmailboxguid
        /// </summary>
        public const String MSEXCHMAILBOXGUID = "msExchMailboxGuid";
        /// <summary>
        /// The ntsecuritydescriptor
        /// </summary>
        public const String NTSECURITYDESCRIPTOR = "nTSecurityDescriptor";
    }
}
