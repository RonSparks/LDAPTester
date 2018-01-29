using System;
using System.Windows.Forms;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace LDAPTester
{
    public partial class formLdapTest : Form
    {
        public formLdapTest()
        {
            InitializeComponent();
        }

        private void formLdapTest_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm ()
        {
            txtHost.Text = "ldap.forumsys.com";
            txtBaseDn.Text = "uid=euclid,dc=example,dc=com";
            txtPortNum.Text = "389";
            txtUserPassword.Text = "password";
            txtTestOutput.Text = "";
            txtDetail.Text = "";
        }
        private void btnTestConnection_Click(object sender, EventArgs e)
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

                txtTestOutput.Text +=  " - Success! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + " Authenticating user";

                ldapConnection.AuthType = AuthType.Basic;
                ldapConnection.SessionOptions.ProtocolVersion = 3;
                System.Net.NetworkCredential nc = new System.Net.NetworkCredential(baseDn,password); 
                ldapConnection.Bind(nc);

                txtTestOutput.Text +=  " - Success! \r\n\r\n";

                ldapConnection.Dispose();
                Cursor.Current = Cursors.Default;
            }
            catch (LdapException ldex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text +=  " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnable to login:\r\n\t" + ldex.Message;
                txtDetail.Text += ldex.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text +=  " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + ex.Message;
                txtDetail.Text += ex.ToString();
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
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtTestOutput.Text = "";
                txtDetail.Text = "";

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = "LDAP://" +  @txtHost.Text + (port > 0 ? ":" + port : "");
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;

                txtTestOutput.Text += DateTime.Now.ToString() + " Connecting to host";
                DirectoryEntry myLdapConnection = createDirectoryEntry(host, baseDn, password);
                DirectorySearcher search = new DirectorySearcher(myLdapConnection)
                {
                    Filter = baseDn
                };

                txtTestOutput.Text += " - Success! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + " Authenticating user";

                string[] requiredProperties = new string[] { "cn", "mail" };

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
                AuthenticationType = AuthenticationTypes.None
            };
            return ldapConnection;
        }
    }
}
