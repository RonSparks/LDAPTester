namespace LDAPTester
{
    partial class formLdapTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBaseDn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTestOutput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortNum = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkStartTLS = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserCn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAttributesToLoad = new System.Windows.Forms.TextBox();
            this.txtIdentifier = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkCertificate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(430, 191);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(205, 42);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(65, 14);
            this.txtHost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(460, 22);
            this.txtHost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(430, 113);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(207, 22);
            this.txtUserPassword.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(356, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password";
            // 
            // txtBaseDn
            // 
            this.txtBaseDn.Location = new System.Drawing.Point(65, 76);
            this.txtBaseDn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBaseDn.Name = "txtBaseDn";
            this.txtBaseDn.Size = new System.Drawing.Size(572, 22);
            this.txtBaseDn.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Path";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(65, 264);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "Output";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtTestOutput
            // 
            this.txtTestOutput.Location = new System.Drawing.Point(68, 288);
            this.txtTestOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTestOutput.Multiline = true;
            this.txtTestOutput.Name = "txtTestOutput";
            this.txtTestOutput.Size = new System.Drawing.Size(572, 260);
            this.txtTestOutput.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 566);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search Results";
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(68, 591);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(572, 83);
            this.txtDetail.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(528, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Port";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(569, 14);
            this.txtPortNum.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(68, 22);
            this.txtPortNum.TabIndex = 2;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(65, 191);
            this.btnReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(77, 42);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(161, 41);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 21);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "LDAPS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkStartTLS
            // 
            this.chkStartTLS.AutoSize = true;
            this.chkStartTLS.Location = new System.Drawing.Point(65, 41);
            this.chkStartTLS.Margin = new System.Windows.Forms.Padding(4);
            this.chkStartTLS.Name = "chkStartTLS";
            this.chkStartTLS.Size = new System.Drawing.Size(86, 21);
            this.chkStartTLS.TabIndex = 3;
            this.chkStartTLS.Text = "StartTLS";
            this.chkStartTLS.UseVisualStyleBackColor = true;
            this.chkStartTLS.CheckedChanged += new System.EventHandler(this.chkStartTLS_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 28;
            this.label5.Text = "User";
            // 
            // txtUserCn
            // 
            this.txtUserCn.Location = new System.Drawing.Point(219, 113);
            this.txtUserCn.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserCn.Name = "txtUserCn";
            this.txtUserCn.Size = new System.Drawing.Size(135, 22);
            this.txtUserCn.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 153);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(235, 17);
            this.label6.TabIndex = 32;
            this.label6.Text = "Load Attributes (comma separated):";
            // 
            // txtAttributesToLoad
            // 
            this.txtAttributesToLoad.Location = new System.Drawing.Point(260, 153);
            this.txtAttributesToLoad.Margin = new System.Windows.Forms.Padding(4);
            this.txtAttributesToLoad.Name = "txtAttributesToLoad";
            this.txtAttributesToLoad.Size = new System.Drawing.Size(380, 22);
            this.txtAttributesToLoad.TabIndex = 9;
            // 
            // txtIdentifier
            // 
            this.txtIdentifier.Location = new System.Drawing.Point(65, 113);
            this.txtIdentifier.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdentifier.Name = "txtIdentifier";
            this.txtIdentifier.Size = new System.Drawing.Size(135, 22);
            this.txtIdentifier.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(201, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "=";
            // 
            // chkCertificate
            // 
            this.chkCertificate.AutoSize = true;
            this.chkCertificate.Location = new System.Drawing.Point(461, 41);
            this.chkCertificate.Name = "chkCertificate";
            this.chkCertificate.Size = new System.Drawing.Size(179, 21);
            this.chkCertificate.TabIndex = 36;
            this.chkCertificate.Text = "Verify Server Certificate";
            this.chkCertificate.UseVisualStyleBackColor = true;
            // 
            // formLdapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 685);
            this.Controls.Add(this.chkCertificate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdentifier);
            this.Controls.Add(this.txtAttributesToLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUserCn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkStartTLS);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTestOutput);
            this.Controls.Add(this.txtUserPassword);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBaseDn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.btnTestConnection);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "formLdapTest";
            this.Text = "Test LDAP Connection";
            this.Load += new System.EventHandler(this.formLdapTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBaseDn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTestOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortNum;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkStartTLS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserCn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAttributesToLoad;
        private System.Windows.Forms.TextBox txtIdentifier;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkCertificate;
    }
}