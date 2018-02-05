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
            this.button1 = new System.Windows.Forms.Button();
            this.btnTestCreds1 = new System.Windows.Forms.Button();
            this.btnTestCreds2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chkStartTLS = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserCn = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAttributesToLoad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(351, 216);
            this.btnTestConnection.Margin = new System.Windows.Forms.Padding(2);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(154, 34);
            this.btnTestConnection.TabIndex = 0;
            this.btnTestConnection.Text = "Test LDAPConnection Bind";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(75, 62);
            this.txtHost.Margin = new System.Windows.Forms.Padding(2);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(346, 20);
            this.txtHost.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host";
            // 
            // txtUserPassword
            // 
            this.txtUserPassword.Location = new System.Drawing.Point(349, 142);
            this.txtUserPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserPassword.Name = "txtUserPassword";
            this.txtUserPassword.PasswordChar = '*';
            this.txtUserPassword.Size = new System.Drawing.Size(156, 20);
            this.txtUserPassword.TabIndex = 14;
            this.txtUserPassword.TextChanged += new System.EventHandler(this.txtUserPassword_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 145);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtBaseDn
            // 
            this.txtBaseDn.Location = new System.Drawing.Point(75, 112);
            this.txtBaseDn.Margin = new System.Windows.Forms.Padding(2);
            this.txtBaseDn.Name = "txtBaseDn";
            this.txtBaseDn.Size = new System.Drawing.Size(430, 20);
            this.txtBaseDn.TabIndex = 10;
            this.txtBaseDn.TextChanged += new System.EventHandler(this.txtBaseDn_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Path";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 265);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Output";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // txtTestOutput
            // 
            this.txtTestOutput.Location = new System.Drawing.Point(77, 284);
            this.txtTestOutput.Margin = new System.Windows.Forms.Padding(2);
            this.txtTestOutput.Multiline = true;
            this.txtTestOutput.Name = "txtTestOutput";
            this.txtTestOutput.Size = new System.Drawing.Size(430, 103);
            this.txtTestOutput.TabIndex = 15;
            this.txtTestOutput.TextChanged += new System.EventHandler(this.txtTestOutput_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 395);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Detail";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDetail
            // 
            this.txtDetail.Location = new System.Drawing.Point(77, 415);
            this.txtDetail.Margin = new System.Windows.Forms.Padding(2);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.Size = new System.Drawing.Size(430, 157);
            this.txtDetail.TabIndex = 17;
            this.txtDetail.TextChanged += new System.EventHandler(this.txtDetail_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Port";
            // 
            // txtPortNum
            // 
            this.txtPortNum.Location = new System.Drawing.Point(453, 62);
            this.txtPortNum.Margin = new System.Windows.Forms.Padding(2);
            this.txtPortNum.Name = "txtPortNum";
            this.txtPortNum.Size = new System.Drawing.Size(52, 20);
            this.txtPortNum.TabIndex = 19;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(77, 216);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(58, 34);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(173, 216);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 34);
            this.button1.TabIndex = 22;
            this.button1.Text = "Test DirectoryEntry + Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTestCreds1
            // 
            this.btnTestCreds1.Location = new System.Drawing.Point(222, 11);
            this.btnTestCreds1.Margin = new System.Windows.Forms.Padding(1);
            this.btnTestCreds1.Name = "btnTestCreds1";
            this.btnTestCreds1.Size = new System.Drawing.Size(72, 21);
            this.btnTestCreds1.TabIndex = 23;
            this.btnTestCreds1.Text = "ForumSys";
            this.btnTestCreds1.UseVisualStyleBackColor = true;
            this.btnTestCreds1.Click += new System.EventHandler(this.btnTestCreds1_Click);
            // 
            // btnTestCreds2
            // 
            this.btnTestCreds2.Location = new System.Drawing.Point(296, 11);
            this.btnTestCreds2.Margin = new System.Windows.Forms.Padding(1);
            this.btnTestCreds2.Name = "btnTestCreds2";
            this.btnTestCreds2.Size = new System.Drawing.Size(103, 21);
            this.btnTestCreds2.TabIndex = 24;
            this.btnTestCreds2.Text = "Dev OpenLDAP";
            this.btnTestCreds2.UseVisualStyleBackColor = true;
            this.btnTestCreds2.Click += new System.EventHandler(this.btnTestCreds2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(74, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Load Testing CredentialsSet:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(147, 84);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(1);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(61, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "LDAPS";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chkStartTLS
            // 
            this.chkStartTLS.AutoSize = true;
            this.chkStartTLS.Location = new System.Drawing.Point(75, 84);
            this.chkStartTLS.Name = "chkStartTLS";
            this.chkStartTLS.Size = new System.Drawing.Size(68, 17);
            this.chkStartTLS.TabIndex = 27;
            this.chkStartTLS.Text = "StartTLS";
            this.chkStartTLS.UseVisualStyleBackColor = true;
            this.chkStartTLS.CheckedChanged += new System.EventHandler(this.chkStartTLS_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "User";
            // 
            // txtUserCn
            // 
            this.txtUserCn.Location = new System.Drawing.Point(158, 141);
            this.txtUserCn.Name = "txtUserCn";
            this.txtUserCn.Size = new System.Drawing.Size(130, 20);
            this.txtUserCn.TabIndex = 29;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(77, 141);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(37, 17);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "cn";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(113, 141);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(39, 17);
            this.radioButton2.TabIndex = 31;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "uid";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(174, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Load Attributes (comma separated):";
            // 
            // txtAttributesToLoad
            // 
            this.txtAttributesToLoad.Location = new System.Drawing.Point(221, 175);
            this.txtAttributesToLoad.Name = "txtAttributesToLoad";
            this.txtAttributesToLoad.Size = new System.Drawing.Size(286, 20);
            this.txtAttributesToLoad.TabIndex = 33;
            // 
            // formLdapTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 656);
            this.Controls.Add(this.txtAttributesToLoad);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.txtUserCn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkStartTLS);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnTestCreds2);
            this.Controls.Add(this.btnTestCreds1);
            this.Controls.Add(this.button1);
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formLdapTest";
            this.Text = "formLdapTest";
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTestCreds1;
        private System.Windows.Forms.Button btnTestCreds2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox chkStartTLS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUserCn;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAttributesToLoad;
    }
}