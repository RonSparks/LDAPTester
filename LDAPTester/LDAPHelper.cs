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

        public enum ConnectionType
        {
            LDAP,
            LDAPS,
            StartTLS
        }

        public LDAPHelper( string searchBaseDN, string hostName, int portNumber, AuthType authType, string connectionAccountName, SecureString connectionAccountPassword, ConnectionType connectionType, int pageSize)
        {

            var ldapDirectoryIdentifier = new LdapDirectoryIdentifier(hostName, portNumber, true, false);
            var networkCredential = new NetworkCredential(connectionAccountName, connectionAccountPassword);

            ldapConnection = new LdapConnection(ldapDirectoryIdentifier, networkCredential)
            {
                AuthType = authType
            };

            ldapConnection.SessionOptions.ProtocolVersion = 3;
            ldapConnection.SessionOptions.VerifyServerCertificate += (conn, cert) => { return true; };  //for development only
            if (connectionType == ConnectionType.StartTLS) ldapConnection.SessionOptions.StartTransportLayerSecurity(null);

            ldapConnection.Bind();

            this.searchBaseDN = searchBaseDN;
            this.pageSize = pageSize;
        }

        public IEnumerable<SearchResultEntryCollection> PagedSearch(string searchFilter, string[] attributesToLoad)
        {

            var pagedResults = new List<SearchResultEntryCollection>();

            var searchRequest = new SearchRequest(searchBaseDN,searchFilter,SearchScope.Subtree,attributesToLoad);
            var searchOptions = new SearchOptionsControl(SearchOption.DomainScope);
            searchRequest.Controls.Add(searchOptions);

            var pageResultRequestControl = new PageResultRequestControl(pageSize);
            searchRequest.Controls.Add(pageResultRequestControl);

            while (true)
            {
                var searchResponse = (SearchResponse)ldapConnection.SendRequest(searchRequest);
                var pageResponse = (PageResultResponseControl)searchResponse.Controls[0];

                yield return searchResponse.Entries;
                if (pageResponse.Cookie.Length == 0)
                    break;

                pageResultRequestControl.Cookie = pageResponse.Cookie;
            }


        }
    }
}
