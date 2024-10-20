namespace TantoBastu_AutoBokning
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            SuspendLayout();
            // 
            // L_UserName
            // 
            L_UserName.AutoSize = true;
            L_UserName.Location = new Point(63, 75);
            L_UserName.Name = "L_UserName";
            L_UserName.Size = new Size(89, 15);
            L_UserName.TabIndex = 0;
            L_UserName.Text = "Användarnamn";
            // 
            // L_Password
            // 
            L_Password.AutoSize = true;
            L_Password.Location = new Point(88, 102);
            L_Password.Name = "L_Password";
            L_Password.Size = new Size(56, 15);
            L_Password.TabIndex = 1;
            L_Password.Text = "Lösenord";
            // 
            // L_TimeToBook
            // 
            L_TimeToBook.AutoSize = true;
            L_TimeToBook.Location = new Point(88, 149);
            L_TimeToBook.Name = "L_TimeToBook";
            L_TimeToBook.Size = new Size(70, 15);
            L_TimeToBook.TabIndex = 2;
            L_TimeToBook.Text = "Bokningstid";
            // 
            // CB_BookingTimes
            // 
            CB_BookingTimes.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_BookingTimes.FormattingEnabled = true;
            CB_BookingTimes.Items.AddRange(new object[] { "07:00 - 09:00", "09:00 - 11:00", "11:00 - 13:00", "13:00 - 15:00", "15:00 - 17:00", "17:00 - 19:00", "21:00 - 23:00" });
            CB_BookingTimes.Location = new Point(169, 147);
            CB_BookingTimes.Margin = new Padding(3, 2, 3, 2);
            CB_BookingTimes.Name = "CB_BookingTimes";
            CB_BookingTimes.Size = new Size(133, 23);
            CB_BookingTimes.TabIndex = 3;
            // 
            // TB_UserName
            // 
            TB_UserName.Location = new Point(169, 73);
            TB_UserName.Margin = new Padding(3, 2, 3, 2);
            TB_UserName.Name = "TB_UserName";
            TB_UserName.Size = new Size(133, 23);
            TB_UserName.TabIndex = 4;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(169, 98);
            TB_Password.Margin = new Padding(3, 2, 3, 2);
            TB_Password.Name = "TB_Password";
            TB_Password.Size = new Size(133, 23);
            TB_Password.TabIndex = 5;
            // 
            // DT_BookingDatePicker
            // 
            DT_BookingDatePicker.Location = new Point(169, 122);
            DT_BookingDatePicker.Margin = new Padding(3, 2, 3, 2);
            DT_BookingDatePicker.Name = "DT_BookingDatePicker";
            DT_BookingDatePicker.Size = new Size(219, 23);
            DT_BookingDatePicker.TabIndex = 6;
            // 
            // L_Date
            // 
            L_Date.AutoSize = true;
            L_Date.Location = new Point(97, 128);
            L_Date.Name = "L_Date";
            L_Date.Size = new Size(43, 15);
            L_Date.TabIndex = 7;
            L_Date.Text = "Datum";
            // 
            // BT_Book
            // 
            BT_Book.Location = new Point(169, 230);
            BT_Book.Margin = new Padding(3, 2, 3, 2);
            BT_Book.Name = "BT_Book";
            BT_Book.Size = new Size(148, 85);
            BT_Book.TabIndex = 8;
            BT_Book.Text = "Book";
            BT_Book.UseVisualStyleBackColor = true;
            BT_Book.Click += BT_Book_Click;
            // 
            // Timer_PollingIntervall
            // 
            Timer_PollingIntervall.Interval = 600000;
            Timer_PollingIntervall.Tick += Timer_PollingIntervall_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 397);
            Controls.Add(BT_Book);
            Controls.Add(L_Date);
            Controls.Add(DT_BookingDatePicker);
            Controls.Add(TB_Password);
            Controls.Add(TB_UserName);
            Controls.Add(CB_BookingTimes);
            Controls.Add(L_TimeToBook);
            Controls.Add(L_Password);
            Controls.Add(L_UserName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Tanto Bastu AutoBokare";
            Load += Form1_Load;
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
    }
}
