using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ứng_dụng_Quản_lý_Danh_mục_Thiết_bị_Công_nghệ
{
    public partial class Form1 : Form
    {
        // 1. Tạo Class Dữ liệu
        public class Category
        {
            public string CategoryId { get; set; }
            public string CategoryName { get; set; }
        }

        public class Product
        {
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string CategoryId { get; set; }
            public string CategoryName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Quantity { get; set; }
            public string ImagePath { get; set; }
        }

        // 2. Khai báo BindingSource và Danh sách trung gian
        private BindingList<Product> _productList;
        private BindingSource _bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox Danh mục
            List<Category> categories = new List<Category>
            {
                new Category { CategoryId = "C01", CategoryName = "Điện thoại" },
                new Category { CategoryId = "C02", CategoryName = "Laptop" },
                new Category { CategoryId = "C03", CategoryName = "Phụ kiện" }
            };
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";

            // Khởi tạo danh sách và Binding
            _productList = new BindingList<Product>();
            _bindingSource = new BindingSource { DataSource = _productList };
            dgvProducts.DataSource = _bindingSource;

            SetupDataGridView();
            UpdateStatus();

            // Gắn sự kiện phụ
            dgvProducts.CellClick += DgvProducts_CellClick;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }

        private void SetupDataGridView()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductId", HeaderText = "Mã SP", Width = 80 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "ProductName", HeaderText = "Tên SP", Width = 150 });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CategoryName", HeaderText = "Danh mục", Width = 100 });

            var colPrice = new DataGridViewTextBoxColumn { DataPropertyName = "UnitPrice", HeaderText = "Đơn giá", Width = 120 };
            colPrice.DefaultCellStyle.Format = "N0";
            dgvProducts.Columns.Add(colPrice);

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Quantity", HeaderText = "Số lượng", Width = 80 });
        }

        private void UpdateStatus()
        {
            lblStatus.Text = $"Tổng số sản phẩm: {_productList.Count}";
        }

        // --- CÁC HÀM SỰ KIỆN MÀ DESIGNER ĐANG BÁO THIẾU ---

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png";
            ofd.Title = "Chọn ảnh sản phẩm";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAvatar.ImageLocation = ofd.FileName;
            }
        }

        private bool ValidateData()
        {
            errorProvider1.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProvider1.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price <= 0)
            {
                errorProvider1.SetError(txtUnitPrice, "Đơn giá phải là số và lớn hơn 0!");
                isValid = false;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                errorProvider1.SetError(txtQuantity, "Số lượng phải là số nguyên và lớn hơn hoặc bằng 0!");
                isValid = false;
            }

            return isValid;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateData()) return;

            var newProduct = new Product
            {
                ProductId = txtProductId.Text,
                ProductName = txtProductName.Text,
                CategoryId = cboCategory.SelectedValue.ToString(),
                CategoryName = cboCategory.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                ImagePath = picAvatar.ImageLocation
            };

            _productList.Add(newProduct);
            UpdateStatus();
            ClearInputs();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null || !ValidateData()) return;

            int index = dgvProducts.CurrentRow.Index;
            var product = _productList[index];

            product.ProductId = txtProductId.Text;
            product.ProductName = txtProductName.Text;
            product.CategoryId = cboCategory.SelectedValue.ToString();
            product.CategoryName = cboCategory.Text;
            product.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            product.Quantity = int.Parse(txtQuantity.Text);
            product.ImagePath = picAvatar.ImageLocation;

            _bindingSource.ResetBindings(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;

            DialogResult dr = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa",
                                              MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int index = dgvProducts.CurrentRow.Index;
                _productList.RemoveAt(index);
                UpdateStatus();
                ClearInputs();
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV File|*.csv";
            sfd.Title = "Xuất danh sách sản phẩm";
            sfd.FileName = "DanhSachSanPham.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        sw.WriteLine("Mã SP,Tên SP,Danh mục,Đơn giá,Số lượng");

                        foreach (DataGridViewRow row in dgvProducts.Rows)
                        {
                            string id = row.Cells[0].Value?.ToString();
                            string name = row.Cells[1].Value?.ToString();
                            string category = row.Cells[2].Value?.ToString();
                            string price = row.Cells[3].Value?.ToString();
                            string qty = row.Cells[4].Value?.ToString();

                            sw.WriteLine($"{id},{name},{category},{price},{qty}");
                        }
                    }
                    MessageBox.Show("Xuất file CSV thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- CÁC HÀM PHỤ TRỢ ---

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var product = _bindingSource.Current as Product;
                if (product != null)
                {
                    txtProductId.Text = product.ProductId;
                    txtProductName.Text = product.ProductName;
                    txtUnitPrice.Text = product.UnitPrice.ToString();
                    txtQuantity.Text = product.Quantity.ToString();
                    cboCategory.SelectedValue = product.CategoryId;
                    picAvatar.ImageLocation = product.ImagePath;
                }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                _bindingSource.DataSource = _productList;
            }
            else
            {
                var filteredList = new BindingList<Product>(_productList.Where(p => p.ProductName.ToLower().Contains(keyword)).ToList());
                _bindingSource.DataSource = filteredList;
            }
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            picAvatar.ImageLocation = null;
            txtProductId.Focus();
        }
    }
}
