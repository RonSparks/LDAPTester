using System;
using System.Windows.Forms;
using System.DirectoryServices.Protocols;
using System.Security;

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

                int port = Convert.ToInt32(txtPortNum.Text);
                string host = @txtHost.Text;
                string baseDn = txtBaseDn.Text;
                string password = txtUserPassword.Text;
                string UserCn = txtUserCn.Text;
                bool startTLS = chkStartTLS.Checked ? true : false;
                bool useCN = radioButton1.Checked;

                LDAPHelper.ConnectionType connectionType = chkStartTLS.Checked ? LDAPHelper.ConnectionType.StartTLS : LDAPHelper.ConnectionType.LDAPS;
                string fullyQualifiedUser = (useCN ? "cn=" : "uid=") + UserCn + "," + baseDn;

                Cursor.Current = Cursors.WaitCursor;

                var password1 = password.ToCharArray();
                var secureString = new SecureString();

                foreach (var character in password1) secureString.AppendChar(character);

                var baseOfSearch = baseDn;
                var pageSize = 1000;

                txtTestOutput.Text += "Connecting to Server as " + UserCn + (startTLS ? " using StartTLS" : "LDAPS") +  " to " + host + "...." + Environment.NewLine;
                var openLDAPHelper = new LDAPHelper(baseDn, host, port, AuthType.Basic, fullyQualifiedUser, secureString, connectionType, pageSize);
                txtTestOutput.Text += Environment.NewLine + "Connection Successful!" + Environment.NewLine + Environment.NewLine;

                txtTestOutput.Text += "--------------------------" + Environment.NewLine;
                txtTestOutput.Text += "SSL information:" + Environment.NewLine + "Cipher strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.CipherStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Exchange strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.ExchangeStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Protocol: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.Protocol.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Hash Strength: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.HashStrength.ToString() + Environment.NewLine;
                txtTestOutput.Text += "Algorithm: " + openLDAPHelper.ldapConnection.SessionOptions.SslInformation.AlgorithmIdentifier.ToString() + Environment.NewLine;
                txtTestOutput.Text += "--------------------------" + Environment.NewLine;

                txtTestOutput.Text += "Searching in " + baseOfSearch + " for " + txtAttributesToLoad.Text + "..." + Environment.NewLine;
                var searchFilter = "uid=*";
                var attributesToLoad =  txtAttributesToLoad.Text.Split(',');
                var pagedSearchResults = openLDAPHelper.PagedSearch(searchFilter, attributesToLoad);

                foreach (var searchResultEntryCollection in pagedSearchResults)
                    foreach (SearchResultEntry searchResultEntry in searchResultEntryCollection)
                    {
                        foreach (var attribute in attributesToLoad)
                        {
                            if (searchResultEntry.Attributes[attribute] != null) txtDetail.Text += searchResultEntry.Attributes[attribute].Name + ": " + searchResultEntry.Attributes[attribute][0].ToString() + Environment.NewLine;
                        }
                        txtDetail.Text += Environment.NewLine;
                    }

                txtTestOutput.Text += Environment.NewLine + "Search Complete.  Results below. " + Environment.NewLine;

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
            checkBox1.Checked = false;
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            txtAttributesToLoad.Text = "uid,givenName,sn";
            checkBox1.Checked = true;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtPortNum.Text = (checkBox1.Checked) ? SECURE_PORT : UNSECURE_PORT;
            chkStartTLS.Checked = (checkBox1.Checked) ? false : true;
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
            txtPortNum.Text = (!chkStartTLS.Checked) ? SECURE_PORT : UNSECURE_PORT;
            checkBox1.Checked = (chkStartTLS.Checked) ? false : true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton1.Checked = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }
    }
}
