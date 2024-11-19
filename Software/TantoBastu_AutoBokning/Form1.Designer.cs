namespace TantoBastu_AutoBokning
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            L_UserName = new Label();
            L_Password = new Label();
            L_TimeToBook = new Label();
            CB_BookingTimes = new ComboBox();
            TB_UserName = new TextBox();
            TB_Password = new TextBox();
            DT_BookingDatePicker = new DateTimePicker();
            L_Date = new Label();
            BT_Book = new Button();
            Timer_PollingIntervall = new System.Windows.Forms.Timer(components);
            BT_EmailSettings = new Button();
            CB_HostSession = new CheckBox();
            L_AdditionalBooking = new Label();
            NUM_AdditionalBooking = new NumericUpDown();
            CB_RetryBooking = new CheckBox();
            GB_Settings = new GroupBox();
            TB_Console = new TextBox();
            ((System.ComponentModel.ISupportInitialize)NUM_AdditionalBooking).BeginInit();
            GB_Settings.SuspendLayout();
            SuspendLayout();
            // 
            // L_UserName
            // 
            L_UserName.AutoSize = true;
            L_UserName.Location = new Point(37, 41);
            L_UserName.Name = "L_UserName";
            L_UserName.Size = new Size(109, 20);
            L_UserName.TabIndex = 0;
            L_UserName.Text = "Användarnamn";
            // 
            // L_Password
            // 
            L_Password.AutoSize = true;
            L_Password.Location = new Point(76, 75);
            L_Password.Name = "L_Password";
            L_Password.Size = new Size(70, 20);
            L_Password.TabIndex = 1;
            L_Password.Text = "Lösenord";
            // 
            // L_TimeToBook
            // 
            L_TimeToBook.AutoSize = true;
            L_TimeToBook.Location = new Point(59, 140);
            L_TimeToBook.Name = "L_TimeToBook";
            L_TimeToBook.Size = new Size(87, 20);
            L_TimeToBook.TabIndex = 2;
            L_TimeToBook.Text = "Bokningstid";
            // 
            // CB_BookingTimes
            // 
            CB_BookingTimes.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_BookingTimes.FormattingEnabled = true;
            CB_BookingTimes.Items.AddRange(new object[] { "07:00 - 09:00", "09:00 - 11:00", "11:00 - 13:00", "13:00 - 15:00", "15:00 - 17:00", "17:00 - 19:00", "21:00 - 23:00" });
            CB_BookingTimes.Location = new Point(158, 137);
            CB_BookingTimes.Name = "CB_BookingTimes";
            CB_BookingTimes.Size = new Size(151, 28);
            CB_BookingTimes.TabIndex = 3;
            // 
            // TB_UserName
            // 
            TB_UserName.Location = new Point(158, 38);
            TB_UserName.Name = "TB_UserName";
            TB_UserName.Size = new Size(151, 27);
            TB_UserName.TabIndex = 4;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(158, 72);
            TB_Password.Name = "TB_Password";
            TB_Password.Size = new Size(151, 27);
            TB_Password.TabIndex = 5;
            // 
            // DT_BookingDatePicker
            // 
            DT_BookingDatePicker.Location = new Point(158, 104);
            DT_BookingDatePicker.Name = "DT_BookingDatePicker";
            DT_BookingDatePicker.Size = new Size(250, 27);
            DT_BookingDatePicker.TabIndex = 6;
            // 
            // L_Date
            // 
            L_Date.AutoSize = true;
            L_Date.Location = new Point(92, 109);
            L_Date.Name = "L_Date";
            L_Date.Size = new Size(54, 20);
            L_Date.TabIndex = 7;
            L_Date.Text = "Datum";
            // 
            // BT_Book
            // 
            BT_Book.Location = new Point(12, 334);
            BT_Book.Name = "BT_Book";
            BT_Book.Size = new Size(453, 113);
            BT_Book.TabIndex = 8;
            BT_Book.Text = "Boka";
            BT_Book.UseVisualStyleBackColor = true;
            BT_Book.Click += BT_Book_Click;
            // 
            // Timer_PollingIntervall
            // 
            Timer_PollingIntervall.Interval = 600000;
            Timer_PollingIntervall.Tick += Timer_PollingIntervall_Tick;
            // 
            // BT_EmailSettings
            // 
            BT_EmailSettings.Location = new Point(157, 264);
            BT_EmailSettings.Name = "BT_EmailSettings";
            BT_EmailSettings.Size = new Size(151, 34);
            BT_EmailSettings.TabIndex = 9;
            BT_EmailSettings.Text = "Email Settings";
            BT_EmailSettings.UseVisualStyleBackColor = true;
            BT_EmailSettings.Click += BT_EmailSettings_Click;
            // 
            // CB_HostSession
            // 
            CB_HostSession.AutoSize = true;
            CB_HostSession.Location = new Point(158, 204);
            CB_HostSession.Name = "CB_HostSession";
            CB_HostSession.Size = new Size(69, 24);
            CB_HostSession.TabIndex = 10;
            CB_HostSession.Text = "Värda";
            CB_HostSession.UseVisualStyleBackColor = true;
            // 
            // L_AdditionalBooking
            // 
            L_AdditionalBooking.AutoSize = true;
            L_AdditionalBooking.Location = new Point(10, 173);
            L_AdditionalBooking.Name = "L_AdditionalBooking";
            L_AdditionalBooking.Size = new Size(136, 20);
            L_AdditionalBooking.TabIndex = 11;
            L_AdditionalBooking.Text = "Ytterligare bokning";
            // 
            // NUM_AdditionalBooking
            // 
            NUM_AdditionalBooking.Location = new Point(158, 171);
            NUM_AdditionalBooking.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NUM_AdditionalBooking.Name = "NUM_AdditionalBooking";
            NUM_AdditionalBooking.Size = new Size(150, 27);
            NUM_AdditionalBooking.TabIndex = 12;
            // 
            // CB_RetryBooking
            // 
            CB_RetryBooking.AutoSize = true;
            CB_RetryBooking.Location = new Point(158, 234);
            CB_RetryBooking.Name = "CB_RetryBooking";
            CB_RetryBooking.Size = new Size(124, 24);
            CB_RetryBooking.TabIndex = 13;
            CB_RetryBooking.Text = "Auto-omboka";
            CB_RetryBooking.UseVisualStyleBackColor = true;
            // 
            // GB_Settings
            // 
            GB_Settings.Controls.Add(TB_UserName);
            GB_Settings.Controls.Add(BT_EmailSettings);
            GB_Settings.Controls.Add(CB_RetryBooking);
            GB_Settings.Controls.Add(L_UserName);
            GB_Settings.Controls.Add(NUM_AdditionalBooking);
            GB_Settings.Controls.Add(L_Password);
            GB_Settings.Controls.Add(L_AdditionalBooking);
            GB_Settings.Controls.Add(L_TimeToBook);
            GB_Settings.Controls.Add(CB_HostSession);
            GB_Settings.Controls.Add(CB_BookingTimes);
            GB_Settings.Controls.Add(TB_Password);
            GB_Settings.Controls.Add(DT_BookingDatePicker);
            GB_Settings.Controls.Add(L_Date);
            GB_Settings.Location = new Point(12, 12);
            GB_Settings.Name = "GB_Settings";
            GB_Settings.Size = new Size(453, 316);
            GB_Settings.TabIndex = 14;
            GB_Settings.TabStop = false;
            GB_Settings.Text = "Inställningar";
            // 
            // TB_Console
            // 
            TB_Console.Location = new Point(471, 24);
            TB_Console.Multiline = true;
            TB_Console.Name = "TB_Console";
            TB_Console.ReadOnly = true;
            TB_Console.Size = new Size(286, 423);
            TB_Console.TabIndex = 15;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 457);
            Controls.Add(TB_Console);
            Controls.Add(GB_Settings);
            Controls.Add(BT_Book);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "Tanto Bastu AutoBokare";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)NUM_AdditionalBooking).EndInit();
            GB_Settings.ResumeLayout(false);
            GB_Settings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label L_UserName;
        private Label L_Password;
        private Label L_TimeToBook;
        private ComboBox CB_BookingTimes;
        private TextBox TB_UserName;
        private TextBox TB_Password;
        private DateTimePicker DT_BookingDatePicker;
        private Label L_Date;
        private Button BT_Book;
        private System.Windows.Forms.Timer Timer_PollingIntervall;
        private Button BT_EmailSettings;
        private CheckBox CB_HostSession;
        private Label L_AdditionalBooking;
        private NumericUpDown NUM_AdditionalBooking;
        private CheckBox CB_RetryBooking;
        private GroupBox GB_Settings;
        private TextBox TB_Console;
    }
}
