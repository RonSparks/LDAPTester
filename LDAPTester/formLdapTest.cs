using System;
using System.Windows.Forms;
using System.DirectoryServices.Protocols;
using System.Security;
using System.Configuration;

namespace LDAPTester
{
    public partial class formLdapTest : Form
    {
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

        private void ConnectViaLDAP()
        {
            try
            {

                txtTestOutput.Text = "";
                txtDetail.Text = "";

                LDAPConnectionInfo info = new LDAPConnectionInfo
                {
                    PortNumber = Convert.ToInt32(txtPortNum.Text),
                    BindDn = txtBaseDn.Text,
                    HostName = @txtHost.Text,
                    UserName = txtUserCn.Text,
                    ConnectionType = chkStartTLS.Checked ? LDAPConnectionInfo.ConnType.StartTLS : LDAPConnectionInfo.ConnType.LDAPS,
                    UserNameInNode = txtIdentifier.Text,
                    Password = SecureTheString(txtUserPassword.Text),
                    PageSize = 1000,
                    AuthenticationType = AuthType.Basic,
                    //info.VerifiyDevCertificate = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("verifyDevLDAPCertificate"));
                    VerifyServerCertificate = chkCertificate.Checked
                };

                Cursor.Current = Cursors.WaitCursor;

                txtTestOutput.Text += "Connecting to Server as " + info.UserName + (info.ConnectionType == LDAPConnectionInfo.ConnType.StartTLS ? " using StartTLS" : " using LDAPS") + " to " + info.HostName + "...." + Environment.NewLine;
                var openLDAPHelper = new LDAPHelper(info);
                txtTestOutput.Text += Environment.NewLine + "Connection Successful!" + Environment.NewLine + Environment.NewLine;

                txtTestOutput.Text += "--------------------------" + Environment.NewLine;
                txtTestOutput.Text += "SSL information:" + Environment.NewLine + "Cipher strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.CipherStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Exchange strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.ExchangeStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Protocol: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.Protocol.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Hash Strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.HashStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Algorithm: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.AlgorithmIdentifier.ToString() + Environment.NewLine;
                txtTestOutput.Text += "--------------------------" + Environment.NewLine;

                txtTestOutput.Text += "Searching in " + info.BindDn + " for " + txtAttributesToLoad.Text + "..." + Environment.NewLine;

                //Look up user information from LDAP for display on the web page, like "Welcome Tom Patterson"
                var searchFilter = info.UserNameInNode + "=" + info.UserName;
                var attributesToLoad = txtAttributesToLoad.Text.Split(',');

                var searchResults = openLDAPHelper.GetUserInfo(searchFilter, attributesToLoad);

                foreach (var searchResultEntry in searchResults)
                    foreach (SearchResultEntry searchResult in searchResultEntry)
                    {
                        foreach (var attribute in attributesToLoad)
                        {
                            if (searchResult.Attributes[attribute] != null) txtDetail.Text += searchResult.Attributes[attribute].Name + ": " + searchResult.Attributes[attribute][0].ToString() + Environment.NewLine;
                        }
                        txtDetail.Text += Environment.NewLine;
                    }

                txtTestOutput.Text += Environment.NewLine + "Search Complete.  Results below. " + Environment.NewLine;

                Cursor.Current = Cursors.Default;
            }
            catch (LdapException ldex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n" + "\r\nUnable to login:\r\n\t" + ldex.Message + "\r\n\r\n" + ldex.ToString();
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                txtTestOutput.Text += " - Fail! \r\n\r\n" + "\r\nUnexpected exception occured:\r\n\t" + ex.GetType() + ":" + ex.Message + "\r\n\r\n" + ex.ToString();
            }
        }

        private SecureString SecureTheString(string Input)
        {
            var inputCharArray = Input.ToCharArray();
            var secureString = new SecureString();

            foreach (var character in inputCharArray) secureString.AppendChar(character);

            return secureString;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            ConnectViaLDAP();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtHost.Text = "ldap.nps.carto.hooahdev.com";
            txtBaseDn.Text = "ou=users MAC,ou=users,ou=design center,ou=harpers ferry center,ou=hq,dc=nps,dc=doi,dc=net";
            txtUserCn.Text = "thpatterson";
            txtPortNum.Text = UNSECURE_PORT;
            txtUserPassword.Text = "H00ah2018~!";
            txtTestOutput.Text = "";
            txtDetail.Text = "";
            txtIdentifier.Text = "cn";
            checkBox1.Checked = false;
            txtAttributesToLoad.Text = "uid,givenName,sn";
            checkBox1.Checked = true;
            chkCertificate.Checked = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPortNum.Text = (checkBox1.Checked) ? SECURE_PORT : UNSECURE_PORT;
            chkStartTLS.Checked = (checkBox1.Checked) ? false : true;
        }

        private void chkStartTLS_CheckedChanged(object sender, EventArgs e)
        {
            txtPortNum.Text = (!chkStartTLS.Checked) ? SECURE_PORT : UNSECURE_PORT;
            checkBox1.Checked = (chkStartTLS.Checked) ? false : true;
        }


    }
}
