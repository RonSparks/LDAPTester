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

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = @txtHost.Text;
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;

                Cursor.Current = Cursors.WaitCursor;

                txtTestOutput.Text += DateTime.Now.ToString() + " Connecting to host";
                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(host, port);
                System.DirectoryServices.Protocols.LdapConnection ldapConnection = new System.DirectoryServices.Protocols.LdapConnection(ldi);

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
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text +=  " - Fail! \r\n\r\n";
                txtTestOutput.Text += DateTime.Now.ToString() + "\r\nUnexpected exception occured:\r\n\t" + e.GetType() + ":" + ex.Message;
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
    }
}
