using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace bai4_2
{
    public partial class Form1 : Form
    {
        public class Course
        {
            public string? CourseId { get; set; }
            public string? CourseName { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mtxtPhone.Mask = "(000) 000-0000";
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";

            List<Course> listCourses = new List<Course>
            {
                new Course { CourseId = "CS01", CourseName = "Lập trình C# WinForms" },
                new Course { CourseId = "CS02", CourseName = "Thiết kế Web ASP.NET Core" },
                new Course { CourseId = "CS03", CourseName = "Phân tích Dữ liệu với Python" },
                new Course { CourseId = "CS04", CourseName = "Cơ sở dữ liệu SQL Server" }
            };

            cboCourse.DataSource = listCourses;
            cboCourse.DisplayMember = "CourseName";
            cboCourse.ValueMember = "CourseId";
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string gender = rdoMale.Checked ? "Nam" : (rdoFemale.Checked ? "Nữ" : "Chưa chọn");

            List<string> skills = new List<string>();
            if (chkEnglish.Checked) skills.Add("Tiếng Anh");
            if (chkIT.Checked) skills.Add("Tin học văn phòng");
            string skillText = skills.Count > 0 ? string.Join(", ", skills) : "Không có";

            string info = $"--- THÔNG TIN ĐĂNG KÝ HỌC VIÊN ---\n\n" +
                          $"Họ và tên: {txtName.Text}\n" +
                          $"Ngày sinh: {dtpBirthDate.Value.ToString("dd/MM/yyyy")}\n" +
                          $"Giới tính: {gender}\n" +
                          $"Số điện thoại: {mtxtPhone.Text}\n" +
                          $"Khóa học: {cboCourse.Text} (Mã: {cboCourse.SelectedValue})\n" +
                          $"Kỹ năng bổ trợ: {skillText}";

            MessageBox.Show(info, "Xác nhận Đăng ký", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void cboCourse_SelectedIndexChanged(object sender, EventArgs e) { }
        private void rdoFemale_CheckedChanged(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void chkEnglish_CheckedChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void chkIT_CheckedChanged(object sender, EventArgs e) { }
    }
}