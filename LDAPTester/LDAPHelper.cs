using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Net;
using System.Security;

namespace LDAPTester
{
    public class LDAPHelper
    {
        public readonly LdapConnection ldapConnection;
        private readonly string searchBaseDN;
        private readonly int pageSize;

        public LDAPHelper (LDAPConnectionInfo Info)
        {
            var ldapDirectoryIdentifier = new LdapDirectoryIdentifier(Info.HostName, Info.PortNumber, true, false);
            var qualifiedUserName = Info.UserNameInNode + "=" + Info.UserName + "," + Info.BindDn;
            var networkCredential = new NetworkCredential(qualifiedUserName, Info.Password);

            ldapConnection = new LdapConnection(ldapDirectoryIdentifier, networkCredential)
            {
                AuthType = Info.AuthenticationType
            };

            ldapConnection.SessionOptions.ProtocolVersion = 3;
            if (Info.VerifyServerCertificate) ldapConnection.SessionOptions.VerifyServerCertificate += (conn, cert) => { return true; };  
            if (Info.ConnectionType == LDAPConnectionInfo.ConnType.StartTLS) ldapConnection.SessionOptions.StartTransportLayerSecurity(null);

            ldapConnection.Bind();
            
            this.searchBaseDN = Info.BindDn;
            this.pageSize = Info.PageSize;
        }

        public IEnumerable<SearchResultEntryCollection> GetUserInfo(string searchFilter, string[] attributesToLoad)
        {
            var results = new List<SearchResultEntryCollection>();
            var searchRequest = new SearchRequest(searchBaseDN,searchFilter,SearchScope.Subtree,attributesToLoad);
            var searchResponse = (SearchResponse)ldapConnection.SendRequest(searchRequest);
            yield return searchResponse.Entries;
        }
    }
}
