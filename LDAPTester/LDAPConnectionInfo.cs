using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LDAPTester
{
    public class LDAPConnectionInfo
    {
        public enum ConnType
        {
            LDAP,
            LDAPS,
            StartTLS
        }

        public ConnType ConnectionType { get; set; }
        public string HostName { get; set; }
        public string BindDn { get; set; }
        public int PortNumber { get; set; }
        public AuthType AuthenticationType { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }
        public int PageSize { get; set; }
        public string UserNameInNode { get; set; }
        public bool VerifyServerCertificate { get; set; }
    }
}
