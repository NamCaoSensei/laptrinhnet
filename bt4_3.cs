using System;
using System.Windows.Forms;

namespace bai4_3_form_may_tinh
{
    public partial class Form1 : Form
    {
        // Khai báo biến lưu trữ giá trị và phép toán
        private double resultValue = 0;
        private string operationPerformed = "";
        private bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // 1. Xử lý sự kiện chung cho 10 nút bấm số (0-9) dùng sender
        private void NumberButton_Click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (isOperationPerformed))
                txtDisplay.Clear();

            isOperationPerformed = false;

            // Ép kiểu sender thành Button để lấy Text của nút vừa ấn
            Button btn = (Button)sender;
            txtDisplay.Text = txtDisplay.Text + btn.Text;
        }

        // 2. Xử lý sự kiện cho các nút phép toán (+, -, *, /)
        private void Operator_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (resultValue != 0)
            {
                btnEqual.PerformClick(); // Tự động tính toán nếu nhấn liên tiếp phép toán
                operationPerformed = btn.Text;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = btn.Text;
                resultValue = double.Parse(txtDisplay.Text);
                isOperationPerformed = true;
            }
        }

        // 3. Xử lý sự kiện nút Clear (C)
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            resultValue = 0;
            operationPerformed = "";
        }

        // 4. Xử lý sự kiện nút Bằng (=)
        private void btnEqual_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    txtDisplay.Text = (resultValue + double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (resultValue - double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (resultValue * double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    double secondaryValue = double.Parse(txtDisplay.Text);
                    if (secondaryValue != 0)
                        txtDisplay.Text = (resultValue / secondaryValue).ToString();
                    else
                        txtDisplay.Text = "Lỗi chia cho 0";
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(txtDisplay.Text);
            operationPerformed = "";
        }
    }
}
