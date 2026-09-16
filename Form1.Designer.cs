namespace bai4_2
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
            mtxtPhone = new MaskedTextBox();
            dtpBirthDate = new DateTimePicker();
            cboCourse = new ComboBox();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            chkEnglish = new CheckBox();
            chkIT = new CheckBox();
            txtName = new TextBox();
            btnRegister = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // mtxtPhone
            // 
            mtxtPhone.Location = new Point(168, 74);
            mtxtPhone.Mask = "(000) 000-0000";
            mtxtPhone.Name = "mtxtPhone";
            mtxtPhone.Size = new Size(125, 27);
            mtxtPhone.TabIndex = 0;
            mtxtPhone.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(168, 112);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(250, 27);
            dtpBirthDate.TabIndex = 1;
            dtpBirthDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // cboCourse
            // 
            cboCourse.FormattingEnabled = true;
            cboCourse.Location = new Point(168, 237);
            cboCourse.Name = "cboCourse";
            cboCourse.Size = new Size(151, 28);
            cboCourse.TabIndex = 2;
            cboCourse.SelectedIndexChanged += cboCourse_SelectedIndexChanged;
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(168, 159);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 3;
            rdoMale.TabStop = true;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            rdoMale.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(243, 159);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 4;
            rdoFemale.TabStop = true;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            rdoFemale.CheckedChanged += rdoFemale_CheckedChanged;
            // 
            // chkEnglish
            // 
            chkEnglish.AutoSize = true;
            chkEnglish.Location = new Point(168, 198);
            chkEnglish.Name = "chkEnglish";
            chkEnglish.Size = new Size(98, 24);
            chkEnglish.TabIndex = 5;
            chkEnglish.Text = "Tiếng Anh";
            chkEnglish.UseVisualStyleBackColor = true;
            chkEnglish.CheckedChanged += chkEnglish_CheckedChanged;
            // 
            // chkIT
            // 
            chkIT.AutoSize = true;
            chkIT.Location = new Point(272, 198);
            chkIT.Name = "chkIT";
            chkIT.Size = new Size(82, 24);
            chkIT.TabIndex = 6;
            chkIT.Text = "Tin Học";
            chkIT.UseVisualStyleBackColor = true;
            chkIT.CheckedChanged += chkIT_CheckedChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(168, 31);
            txtName.Name = "txtName";
            txtName.Size = new Size(125, 27);
            txtName.TabIndex = 7;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(224, 338);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(235, 47);
            btnRegister.TabIndex = 8;
            btnRegister.Text = "Đăng Ký";
            btnRegister.UseVisualStyleBackColor = true;
            btnRegister.Click += btnRegister_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 34);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 9;
            label1.Text = "Họ Và Tên";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 77);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 10;
            label2.Text = "Số Điện Thoại";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(86, 117);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 11;
            label3.Text = "Ngày Sinh";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(94, 161);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 12;
            label4.Text = "Giới Tính";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 240);
            label5.Name = "label5";
            label5.Size = new Size(148, 20);
            label5.TabIndex = 13;
            label5.Text = "Danh Sách Khóa Học";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(91, 202);
            label6.Name = "label6";
            label6.Size = new Size(70, 20);
            label6.TabIndex = 14;
            label6.Text = "Môn Học";
            label6.Click += label6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(694, 397);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRegister);
            Controls.Add(txtName);
            Controls.Add(chkIT);
            Controls.Add(chkEnglish);
            Controls.Add(rdoFemale);
            Controls.Add(rdoMale);
            Controls.Add(cboCourse);
            Controls.Add(dtpBirthDate);
            Controls.Add(mtxtPhone);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaskedTextBox mtxtPhone;
        private DateTimePicker dtpBirthDate;
        private ComboBox cboCourse;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private CheckBox chkEnglish;
        private CheckBox chkIT;
        private TextBox txtName;
        private Button btnRegister;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}
