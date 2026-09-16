using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _4_4_FORM_ĐẶT_HÀNG_FAST_FOOD
{
    public partial class Form1 : Form
    {
        public class FastFoodItem
        {
            public string Name { get; set; }
            public int Price { get; set; }

            public FastFoodItem(string name, int price)
            {
                Name = name;
                Price = price;
            }

            public override string ToString()
            {
                return $"{Name} - {Price:N0}k";
            }
        }
        
        public Form1()
        {
            InitializeComponent();
            Form1_Load(this, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lstMenu.Items.Add(new FastFoodItem("Hamburger", 50));
            lstMenu.Items.Add(new FastFoodItem("Pizza", 120));
            lstMenu.Items.Add(new FastFoodItem("Gà Rán", 35));
            lstMenu.Items.Add(new FastFoodItem("Pepsi", 15));
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstSelected_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lstMenu.SelectedItem != null)
            {
                lstSelected.Items.Add(lstMenu.SelectedItem);

                CalculateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món ăn từ thực đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstSelected.SelectedItem != null)
            {
                lstSelected.Items.Remove(lstSelected.SelectedItem);

                CalculateTotal();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn món cần xóa khỏi danh sách đã chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalculateTotal()
        {
            int total = 0;

            foreach (FastFoodItem item in lstSelected.Items)
            {
                total += item.Price;
            }

            lblTotal.Text = $"{total * 1000:N0} VNĐ";
        }
    }
}

