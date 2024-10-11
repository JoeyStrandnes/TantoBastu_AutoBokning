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
            L_UserName = new Label();
            L_Password = new Label();
            L_TimeToBook = new Label();
            CB_BookingTimes = new ComboBox();
            TB_UserName = new TextBox();
            TB_Password = new TextBox();
            DT_BookingDatePicker = new DateTimePicker();
            L_Date = new Label();
            BT_Book = new Button();
            SuspendLayout();
            // 
            // L_UserName
            // 
            L_UserName.AutoSize = true;
            L_UserName.Location = new Point(72, 100);
            L_UserName.Name = "L_UserName";
            L_UserName.Size = new Size(109, 20);
            L_UserName.TabIndex = 0;
            L_UserName.Text = "Användarnamn";
            // 
            // L_Password
            // 
            L_Password.AutoSize = true;
            L_Password.Location = new Point(100, 136);
            L_Password.Name = "L_Password";
            L_Password.Size = new Size(70, 20);
            L_Password.TabIndex = 1;
            L_Password.Text = "Lösenord";
            // 
            // L_TimeToBook
            // 
            L_TimeToBook.AutoSize = true;
            L_TimeToBook.Location = new Point(100, 199);
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
            CB_BookingTimes.Location = new Point(193, 196);
            CB_BookingTimes.Name = "CB_BookingTimes";
            CB_BookingTimes.Size = new Size(151, 28);
            CB_BookingTimes.TabIndex = 3;
            // 
            // TB_UserName
            // 
            TB_UserName.Location = new Point(193, 97);
            TB_UserName.Name = "TB_UserName";
            TB_UserName.Size = new Size(151, 27);
            TB_UserName.TabIndex = 4;
            // 
            // TB_Password
            // 
            TB_Password.Location = new Point(193, 130);
            TB_Password.Name = "TB_Password";
            TB_Password.Size = new Size(151, 27);
            TB_Password.TabIndex = 5;
            // 
            // DT_BookingDatePicker
            // 
            DT_BookingDatePicker.Location = new Point(193, 163);
            DT_BookingDatePicker.Name = "DT_BookingDatePicker";
            DT_BookingDatePicker.Size = new Size(250, 27);
            DT_BookingDatePicker.TabIndex = 6;
            // 
            // L_Date
            // 
            L_Date.AutoSize = true;
            L_Date.Location = new Point(111, 170);
            L_Date.Name = "L_Date";
            L_Date.Size = new Size(54, 20);
            L_Date.TabIndex = 7;
            L_Date.Text = "Datum";
            // 
            // BT_Book
            // 
            BT_Book.Location = new Point(274, 340);
            BT_Book.Name = "BT_Book";
            BT_Book.Size = new Size(94, 29);
            BT_Book.TabIndex = 8;
            BT_Book.Text = "Book";
            BT_Book.UseVisualStyleBackColor = true;
            BT_Book.Click += BT_Book_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(632, 529);
            Controls.Add(BT_Book);
            Controls.Add(L_Date);
            Controls.Add(DT_BookingDatePicker);
            Controls.Add(TB_Password);
            Controls.Add(TB_UserName);
            Controls.Add(CB_BookingTimes);
            Controls.Add(L_TimeToBook);
            Controls.Add(L_Password);
            Controls.Add(L_UserName);
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
    }
}
