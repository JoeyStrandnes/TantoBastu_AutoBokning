namespace TantoBastu_AutoBokning
{
    partial class EmailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailForm));
            L_SMTP_Server = new Label();
            TB_SMTP_Server = new TextBox();
            TB_SMTP_Port = new TextBox();
            L_SMTP_Port = new Label();
            GB_EmailServerSettings = new GroupBox();
            TB_ServerEmailPassword = new TextBox();
            L_EmailPassword = new Label();
            TB_ServerEmailAddress = new TextBox();
            L_EmailAddress = new Label();
            TB_ClientAddress = new TextBox();
            L_ClientAddress = new Label();
            BT_TestEmail = new Button();
            CB_SendEmail = new CheckBox();
            GB_EmailServerSettings.SuspendLayout();
            SuspendLayout();
            // 
            // L_SMTP_Server
            // 
            L_SMTP_Server.AutoSize = true;
            L_SMTP_Server.Location = new Point(6, 41);
            L_SMTP_Server.Name = "L_SMTP_Server";
            L_SMTP_Server.Size = new Size(91, 20);
            L_SMTP_Server.TabIndex = 0;
            L_SMTP_Server.Text = "SMTP Server";
            // 
            // TB_SMTP_Server
            // 
            TB_SMTP_Server.Location = new Point(131, 38);
            TB_SMTP_Server.Name = "TB_SMTP_Server";
            TB_SMTP_Server.Size = new Size(213, 27);
            TB_SMTP_Server.TabIndex = 1;
            // 
            // TB_SMTP_Port
            // 
            TB_SMTP_Port.Location = new Point(131, 71);
            TB_SMTP_Port.Name = "TB_SMTP_Port";
            TB_SMTP_Port.Size = new Size(213, 27);
            TB_SMTP_Port.TabIndex = 3;
            // 
            // L_SMTP_Port
            // 
            L_SMTP_Port.AutoSize = true;
            L_SMTP_Port.Location = new Point(6, 74);
            L_SMTP_Port.Name = "L_SMTP_Port";
            L_SMTP_Port.Size = new Size(76, 20);
            L_SMTP_Port.TabIndex = 2;
            L_SMTP_Port.Text = "SMTP Port";
            // 
            // GB_EmailServerSettings
            // 
            GB_EmailServerSettings.Controls.Add(TB_ServerEmailPassword);
            GB_EmailServerSettings.Controls.Add(L_EmailPassword);
            GB_EmailServerSettings.Controls.Add(TB_ServerEmailAddress);
            GB_EmailServerSettings.Controls.Add(L_EmailAddress);
            GB_EmailServerSettings.Controls.Add(L_SMTP_Server);
            GB_EmailServerSettings.Controls.Add(TB_SMTP_Port);
            GB_EmailServerSettings.Controls.Add(TB_SMTP_Server);
            GB_EmailServerSettings.Controls.Add(L_SMTP_Port);
            GB_EmailServerSettings.Location = new Point(12, 12);
            GB_EmailServerSettings.Name = "GB_EmailServerSettings";
            GB_EmailServerSettings.Size = new Size(367, 191);
            GB_EmailServerSettings.TabIndex = 4;
            GB_EmailServerSettings.TabStop = false;
            GB_EmailServerSettings.Text = "Mail Server Settings";
            // 
            // TB_ServerEmailPassword
            // 
            TB_ServerEmailPassword.Location = new Point(131, 137);
            TB_ServerEmailPassword.Name = "TB_ServerEmailPassword";
            TB_ServerEmailPassword.Size = new Size(213, 27);
            TB_ServerEmailPassword.TabIndex = 7;
            TB_ServerEmailPassword.UseSystemPasswordChar = true;
            // 
            // L_EmailPassword
            // 
            L_EmailPassword.AutoSize = true;
            L_EmailPassword.Location = new Point(6, 140);
            L_EmailPassword.Name = "L_EmailPassword";
            L_EmailPassword.Size = new Size(113, 20);
            L_EmailPassword.TabIndex = 6;
            L_EmailPassword.Text = "Email password";
            // 
            // TB_ServerEmailAddress
            // 
            TB_ServerEmailAddress.Location = new Point(131, 104);
            TB_ServerEmailAddress.Name = "TB_ServerEmailAddress";
            TB_ServerEmailAddress.Size = new Size(213, 27);
            TB_ServerEmailAddress.TabIndex = 5;
            // 
            // L_EmailAddress
            // 
            L_EmailAddress.AutoSize = true;
            L_EmailAddress.Location = new Point(6, 107);
            L_EmailAddress.Name = "L_EmailAddress";
            L_EmailAddress.Size = new Size(101, 20);
            L_EmailAddress.TabIndex = 4;
            L_EmailAddress.Text = "Email address";
            // 
            // TB_ClientAddress
            // 
            TB_ClientAddress.Location = new Point(143, 219);
            TB_ClientAddress.Name = "TB_ClientAddress";
            TB_ClientAddress.Size = new Size(213, 27);
            TB_ClientAddress.TabIndex = 9;
            // 
            // L_ClientAddress
            // 
            L_ClientAddress.AutoSize = true;
            L_ClientAddress.Location = new Point(18, 222);
            L_ClientAddress.Name = "L_ClientAddress";
            L_ClientAddress.Size = new Size(101, 20);
            L_ClientAddress.TabIndex = 8;
            L_ClientAddress.Text = "Email address";
            // 
            // BT_TestEmail
            // 
            BT_TestEmail.Location = new Point(12, 310);
            BT_TestEmail.Name = "BT_TestEmail";
            BT_TestEmail.Size = new Size(359, 55);
            BT_TestEmail.TabIndex = 10;
            BT_TestEmail.Text = "Test email";
            BT_TestEmail.UseVisualStyleBackColor = true;
            BT_TestEmail.Click += BT_TestEmail_Click;
            // 
            // CB_SendEmail
            // 
            CB_SendEmail.AutoSize = true;
            CB_SendEmail.Location = new Point(143, 262);
            CB_SendEmail.Name = "CB_SendEmail";
            CB_SendEmail.Size = new Size(187, 24);
            CB_SendEmail.TabIndex = 11;
            CB_SendEmail.Text = "Skicka mail vid bokning";
            CB_SendEmail.UseVisualStyleBackColor = true;
            // 
            // EmailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 382);
            Controls.Add(CB_SendEmail);
            Controls.Add(BT_TestEmail);
            Controls.Add(TB_ClientAddress);
            Controls.Add(L_ClientAddress);
            Controls.Add(GB_EmailServerSettings);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "EmailForm";
            Text = "EmailSettings";
            FormClosing += EmailForm_FormClosing;
            Load += EmailForm_Load;
            GB_EmailServerSettings.ResumeLayout(false);
            GB_EmailServerSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_SMTP_Server;
        private TextBox TB_SMTP_Server;
        private TextBox TB_SMTP_Port;
        private Label L_SMTP_Port;
        private GroupBox GB_EmailServerSettings;
        private TextBox TB_ServerEmailAddress;
        private Label L_EmailAddress;
        private TextBox TB_ServerEmailPassword;
        private Label L_EmailPassword;
        private TextBox TB_ClientAddress;
        private Label L_ClientAddress;
        private Button BT_TestEmail;
        private CheckBox CB_SendEmail;
    }
}