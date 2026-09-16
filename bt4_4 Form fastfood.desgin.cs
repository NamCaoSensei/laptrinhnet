namespace _4_4_FORM_ĐẶT_HÀNG_FAST_FOOD
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
            groupBox1 = new GroupBox();
            lstMenu = new ListBox();
            groupBox2 = new GroupBox();
            lstSelected = new ListBox();
            btnAdd = new Button();
            btnRemove = new Button();
            label1 = new Label();
            lblTotal = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lstMenu);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(335, 364);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Danh sách món ăn";
            // 
            // lstMenu
            // 
            lstMenu.FormattingEnabled = true;
            lstMenu.Location = new Point(6, 26);
            lstMenu.Name = "lstMenu";
            lstMenu.Size = new Size(323, 324);
            lstMenu.TabIndex = 0;
            lstMenu.SelectedIndexChanged += lstMenu_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstSelected);
            groupBox2.Location = new Point(464, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(335, 364);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Món đã chọn";
            // 
            // lstSelected
            // 
            lstSelected.FormattingEnabled = true;
            lstSelected.Location = new Point(6, 26);
            lstSelected.Name = "lstSelected";
            lstSelected.Size = new Size(323, 324);
            lstSelected.TabIndex = 0;
            lstSelected.SelectedIndexChanged += lstSelected_SelectedIndexChanged;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(341, 154);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(117, 33);
            btnAdd.TabIndex = 1;
            btnAdd.Text = ">";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(342, 209);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(117, 33);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "<";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 398);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 3;
            label1.Text = "Tổng tiền:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(109, 398);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(52, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "0 VNĐ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTotal);
            Controls.Add(label1);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lstMenu;
        private GroupBox groupBox2;
        private ListBox lstSelected;
        private Button btnAdd;
        private Button btnRemove;
        private Label label1;
        private Label lblTotal;
    }
}

