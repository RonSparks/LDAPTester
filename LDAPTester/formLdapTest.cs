using System;
using System.Windows.Forms;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security;

namespace LDAPTester
{
    public partial class formLdapTest : Form
    {

        private const string LDAP_QUALIFIER = @"LDAP://";
        private const string LDAPS_QUALIFIER = @"LDAPS://";
        private const string SECURE_PORT = "636";
        private const string UNSECURE_PORT = "389";

        public formLdapTest()
        {
            InitializeComponent();
        }

        private void formLdapTest_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        //added to hopefully ignore certiicate errors on the dev ldap instance for SSL
        public static X509Certificate ClientCertFinder(LdapConnection connection,
                                                byte[][] trustedCAs)
        {
            return null;
        }


        private void ConnectViaLDAPS()
        {
            try
            {

                txtTestOutput.Text = "";
                txtDetail.Text = "";

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = @txtHost.Text;
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;

                Cursor.Current = Cursors.WaitCursor;

                txtTestOutput.Text += DateTime.Now.ToString() + " Connecting to host";

                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(host, port);
                LdapConnection ldapConnection = new LdapConnection(ldi);

                ldapConnection.SessionOptions.QueryClientCertificate = new QueryClientCertificateCallback(ClientCertFinder);
                ldapConnection.SessionOptions.VerifyServerCertificate += (conn, cert) => { return true; };
                //ldapConnection.SessionOptions.VerifyServerCertificate = new VerifyServerCertificateCallback((con, cer) => true);
                ldapConnection.SessionOptions.SecureSocketLayer = true;
                ldapConnection.AuthType = AuthType.Negotiate;

                txtTestOutput.Text += " - Success! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + " Authenticating user";

                ldapConnection.SessionOptions.ProtocolVersion = 3;
                NetworkCredential nc = new NetworkCredential(baseDn, password);
                ldapConnection.Bind(nc);

                txtDetail.Text = "SSL for encryption is enabled\nSSL information:" + "Cipher strength: " + ldapConnection.SessionOptions.SslInformation.CipherStrength.ToString() + Environment.NewLine;
                txtDetail.Text += "Exchange strength: " + ldapConnection.SessionOptions.SslInformation.ExchangeStrength.ToString() + Environment.NewLine;
                txtDetail.Text += "Protocol: " + ldapConnection.SessionOptions.SslInformation.Protocol.ToString() + Environment.NewLine;
                txtDetail.Text += "Hash Strength: " + ldapConnection.SessionOptions.SslInformation.HashStrength.ToString() + Environment.NewLine;
                txtDetail.Text += "Algorithm: " + ldapConnection.SessionOptions.SslInformation.AlgorithmIdentifier.ToString() + Environment.NewLine;

                txtTestOutput.Text += " - Success! \r\n\r\n";

                ldapConnection.Dispose();
                Cursor.Current = Cursors.Default;
            }
            catch (LdapException ldex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnable to login:\r\n\t" + ldex.Message;
                txtDetail.Text += ldex.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnexpected exception occured:\r\n\t" + ex.GetType() + ":" + ex.Message;
                txtDetail.Text += ex.ToString();
            }
        }

        private void ConnectViaLDAP()
        {
            try
            {

                txtTestOutput.Text = "";
                txtDetail.Text = "";

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = @txtHost.Text;
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;
                string UserCn = txtUserCn.Text;
                bool startTLS = chkStartTLS.Checked ? true : false;

                string fullyQualifiedUser = "cn=" + UserCn + "," + baseDn;
         
                Cursor.Current = Cursors.WaitCursor;

                var password1 = password.ToCharArray();
                var secureString = new SecureString();

                foreach (var character in password1) secureString.AppendChar(character);

                var baseOfSearch = baseDn;
                var pageSize = 1000;

                txtTestOutput.Text += "Connecting to Server as " + UserCn + (startTLS ? " using StartTLS" : "") +  " to " + host + "...." + Environment.NewLine;
                var openLDAPHelper = new LDAPHelper(baseDn, host, port, AuthType.Basic, fullyQualifiedUser, secureString, startTLS, pageSize);
                txtTestOutput.Text += "Connection Successful!" + Environment.NewLine + Environment.NewLine;

                txtTestOutput.Text += "Searching in " + baseOfSearch + "..." + Environment.NewLine;
                var searchFilter = "uid=*";
                var attributesToLoad = new[] { "uid", "givenName", "sn" };
                var pagedSearchResults = openLDAPHelper.PagedSearch(searchFilter, attributesToLoad);

                foreach (var searchResultEntryCollection in pagedSearchResults)
                    foreach (SearchResultEntry searchResultEntry in searchResultEntryCollection)
                       txtDetail.Text += searchResultEntry.Attributes["uid"][0] + " " + searchResultEntry.Attributes["givenName"][0] + " " + searchResultEntry.Attributes["sn"][0] + Environment.NewLine;

                txtTestOutput.Text += "Search Complete.  Results below. " + Environment.NewLine;

                Cursor.Current = Cursors.Default;
            }
            catch (LdapException ldex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnable to login:\r\n\t" + ldex.Message;
                txtDetail.Text += ldex.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnexpected exception occured:\r\n\t" + ex.GetType() + ":" + ex.Message;
                txtDetail.Text += ex.ToString();
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {

            if (chkStartTLS.Checked)
            {
                ConnectViaLDAP();
            }
            else if (checkBox1.Checked)
            {
                ConnectViaLDAPS();
            }
            else
            {
                ConnectViaLDAP();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //wanna not only verify user credentials, but also get/retreive the uer name from AD server.
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtTestOutput.Text = "";
                txtDetail.Text = "";

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = checkBox1.Checked ? LDAPS_QUALIFIER : LDAP_QUALIFIER +  @txtHost.Text + (port > 0 ? ":" + port : "");
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;

                txtTestOutput.Text += DateTime.Now.ToString() + " Connecting to host";
                DirectoryEntry myLdapConnection = createDirectoryEntry(host, baseDn, password);

                if (checkBox1.Checked) myLdapConnection.AuthenticationType = AuthenticationTypes.Secure;

                DirectorySearcher search = new DirectorySearcher(myLdapConnection)
                {
                    Filter = "(&" +
                        "(objectClass=user)" +
                        "(cn=t*)" +
                    ")"
                };

                txtTestOutput.Text += " - Success! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + " Authenticating user";

                string[] requiredProperties = new string[] { "cn"};

                foreach (String property in requiredProperties)
                    search.PropertiesToLoad.Add(property);

                SearchResult result = search.FindOne();
                txtTestOutput.Text += " - Success! \r\n\r\n";

                if (result != null)
                {
                    txtTestOutput.Text += DateTime.Now.ToString() + " Getting Uer Info...";
                    foreach (String property in requiredProperties)
                        foreach (Object myCollection in result.Properties[property])
                            txtTestOutput.Text += String.Format("{0,-20} : {1}", property, myCollection.ToString());

                    txtTestOutput.Text += "Done getting uer info. \r\n\r\n";
                }
                else
                {
                    txtTestOutput.Text += "No User Info Found! \r\n\r\n";
                }

                Cursor.Current = Cursors.Default;
            }

            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnexpected exception occured:\r\n\t" + ex.GetType() + ":" + ex.Message;
                txtDetail.Text += ex.ToString();
            }
        }

        private  DirectoryEntry createDirectoryEntry(string host, string userName, string password)
        {
            // create and return new LDAP connection with desired settings  

            DirectoryEntry ldapConnection = new DirectoryEntry(host)
            {
                Username =userName,
                Password = password,
                AuthenticationType = checkBox1.Checked ? AuthenticationTypes.Secure : AuthenticationTypes.None
            };
            return ldapConnection;
        }

        private void ResetForm()
        {
            txtHost.Text = "ldap.forumsys.com";
            txtBaseDn.Text = "uid=euclid,dc=example,dc=com";
            txtUserCn.Text = "euclid";
            txtPortNum.Text = UNSECURE_PORT;
            txtUserPassword.Text = "password";
            txtTestOutput.Text = "";
            txtDetail.Text = "";
            checkBox1.Checked = false;
        }

        private void btnTestCreds1_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnTestCreds2_Click(object sender, EventArgs e)
        {
            txtHost.Text = "52.23.194.20";
            txtBaseDn.Text = "ou=users MAC,ou=users,ou=design center,ou=harpers ferry center,ou=hq,dc=nps,dc=doi,dc=net";
            txtUserCn.Text = "thpatterson";
            txtPortNum.Text = UNSECURE_PORT;
            txtUserPassword.Text = "H00ah2018~!";
            txtTestOutput.Text = "";
            txtDetail.Text = "";
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPortNum.Text = (checkBox1.Checked) ? SECURE_PORT : UNSECURE_PORT;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtBaseDn_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtDetail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTestOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void chkStartTLS_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
