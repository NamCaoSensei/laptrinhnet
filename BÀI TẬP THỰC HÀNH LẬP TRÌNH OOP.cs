//II.PHẦN BÀI TẬP THỰC HÀNH LẬP TRÌNH OOP
//Đề bài: Xây dựng Hệ thống Quản lý Phương tiện Giao thông cho Công ty Logistics
//AutoSpeed áp dụng đầy đủ 4 trụ cột OOP và các tính năng Modern C#.
//1. Yêu cầu Cấu trúc Lớp (Class Structure)
//A. Abstract Class PhuongTien (Lớp cha trừu tượng)
//• Private
//Fields: _maPT(string), _tenHang(string), _namSanXuat(int), _giaGoc(decimal).
//• Properties(Validation Encapsulation):
//o MaPT: Không được để trống (Nối khoảng trắng), mặc định "PT000".
//o TenHang: Không được để trống.
//o NamSanXuat: Bắt buộc ≥ 1900 và ≤ Năm hiện tại. Nếu vi phạm → throw
//new ArgumentException(...).
//o GiaGoc: Bắt buộc > 0.
//• Constructor: Khởi tạo đầy đủ tham số.
//• Abstract Method: public abstract decimal TinhGiaLanBanh();
//• Virtual Method: public virtual string GetInfo() (Trả về chuỗi thông tin cơ bản).
//B. Class OTo kế thừa từ PhuongTien
//• Properties bổ sung: SoChoNgoi(int, > 0), DungTichDongCo(double, > 0).

//• Override TinhGiaLanBanh():
//o Nếu SoChoNgoi ≤ 9 chỗ: Giá lăn bánh = GiaGoc + Thuế Lệ phí trước bạ
//(12% GiaGoc) + Thuế Tiêu thụ đặc biệt (30% GiaGoc).
//o Nếu SoChoNgoi > 9 chỗ: Giá lăn bánh = GiaGoc + Thuế Lệ phí trước bạ
//(10% GiaGoc).

//• Override GetInfo(): Bổ sung thêm thông tin số chỗ ngồi và dung tích động cơ.
//C. Class XeMay kế thừa từ PhuongTien
//• Property bổ sung: DungTichXylanh(int, tính bằng cc).
//• Override TinhGiaLanBanh():
//o Nếu DungTichXylanh < 175 cc: Giá lăn bánh = GiaGoc + Thuế Trước bạ
//(2% GiaGoc).
//o Nếu DungTichXylanh ≥ 175 cc: Giá lăn bánh = GiaGoc + Thuế Trước bạ
//(5% GiaGoc).

//D. Class QuanLyPhuongTien (Quản lý Tập hợp)
//• Quản lý danh sách List<PhuongTien>.
//• Các phương thức:
//1.AddPhuongTien(PhuongTien pt): Thêm phương tiện mới.
//2. DisplayAll(): In ra danh sách toàn bộ phương tiện kèm Giá lăn bánh.
//3. FindMaxGiaLanBanh(): Tìm và trả về phương tiện có Giá lăn bánh cao
//nhất (Đa hình).
//4. SearchByName(string keyword): Tìm danh sách phương tiện theo tên hãng
//(dùng LINQ hoặc foreach).
using System;
using System.Collections.Generic;
using System.Linq;

namespace kiemtra1
{
    public abstract class PhuongTien
    {
        private string _maPT = string.Empty;
        private string _tenHang = string.Empty;
        private int _namSanXuat;
        private decimal _giaGoc;

        public string MaPT
        {
            get => _maPT;
            set => _maPT = string.IsNullOrWhiteSpace(value) ? "PT000" : value;
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống.");
                _tenHang = value;
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                {
                    // Sửa đúng câu chữ theo TC01 trong đề bài
                    throw new ArgumentException("Năm sản xuất không hợp lệ!");
                }
                _namSanXuat = value;
            }
        }

        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0.");
                _giaGoc = value;
            }
        }

        public PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }

        public abstract decimal TinhGiaLanBanh();

        public virtual string GetInfo()
        {
            return $"Mã PT: {MaPT}, Hãng: {TenHang}, Năm SX: {NamSanXuat}, Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }

    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0.");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0.");
                _dungTichDongCo = value;
            }
        }

        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
                return GiaGoc + (GiaGoc * 0.12m) + (GiaGoc * 0.30m);
            return GiaGoc + (GiaGoc * 0.10m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Số chỗ: {SoChoNgoi}, Dung tích động cơ: {DungTichDongCo}L";
        }
    }

    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xy lanh phải lớn hơn 0.");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (DungTichXylanh < 175)
                return GiaGoc + (GiaGoc * 0.02m);
            return GiaGoc + (GiaGoc * 0.05m);
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Dung tích xy lanh: {DungTichXylanh}cc";
        }
    }

    public class QuanLyPhuongTien
    {
        private List<PhuongTien> danhSachPhuongTien = new List<PhuongTien>();

        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt != null)
                danhSachPhuongTien.Add(pt);
        }

        public void DisplayAll()
        {
            foreach (var pt in danhSachPhuongTien)
            {
                Console.WriteLine($"{pt.GetInfo()} | Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        public PhuongTien? FindMaxGiaLanBanh()
        {
            return danhSachPhuongTien.OrderByDescending(pt => pt.TinhGiaLanBanh()).FirstOrDefault();
        }

        public List<PhuongTien> SearchByName(string keyword)
        {
            return danhSachPhuongTien.Where(pt => pt.TenHang.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            QuanLyPhuongTien quanLy = new QuanLyPhuongTien();

            Console.Write("Nhập số lượng phương tiện: ");
            if (!int.TryParse(Console.ReadLine(), out int soluong) || soluong <= 0)
            {
                Console.WriteLine("Số lượng không hợp lệ.");
                return;
            }

            for (int i = 0; i < soluong; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin phương tiện thứ {i + 1} ---");
                Console.Write("Loại phương tiện (1: Ô tô, 2: Xe máy): ");
                string loai = Console.ReadLine() ?? "";

                try
                {
                    if (loai == "1")
                    {
                        Console.Write("Mã PT: ");
                        string maPT = Console.ReadLine() ?? "";
                        Console.Write("Tên hãng: ");
                        string tenHang = Console.ReadLine() ?? "";
                        Console.Write("Năm sản xuất: ");
                        int namSX = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Giá gốc: ");
                        decimal giaGoc = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Số chỗ ngồi: ");
                        int soChoNgoi = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Dung tích động cơ (L): ");
                        double dungTichDongCo = double.Parse(Console.ReadLine() ?? "0");

                        OTo oto = new OTo(maPT, tenHang, namSX, giaGoc, soChoNgoi, dungTichDongCo);
                        quanLy.AddPhuongTien(oto);
                    }
                    else if (loai == "2")
                    {
                        Console.Write("Mã PT: ");
                        string maPT = Console.ReadLine() ?? "";
                        Console.Write("Tên hãng: ");
                        string tenHang = Console.ReadLine() ?? "";
                        Console.Write("Năm sản xuất: ");
                        int namSX = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Giá gốc: ");
                        decimal giaGoc = decimal.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Dung tích xy lanh (cc): ");
                        int dungTichXylanh = int.Parse(Console.ReadLine() ?? "0");

                        XeMay xeMay = new XeMay(maPT, tenHang, namSX, giaGoc, dungTichXylanh);
                        quanLy.AddPhuongTien(xeMay);
                    }
                    else
                    {
                        Console.WriteLine("Loại phương tiện không hợp lệ, vui lòng nhập lại.");
                        i--; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi: {ex.Message} Vui lòng nhập lại phương tiện này.");
                    i--;
                }
            }

            Console.WriteLine("\nDanh sách phương tiện:");
            quanLy.DisplayAll();

            Console.WriteLine("\nPhương tiện có giá lăn bánh cao nhất:");
            var maxGiaLanBanh = quanLy.FindMaxGiaLanBanh();
            if (maxGiaLanBanh != null)
            {
                Console.WriteLine($"{maxGiaLanBanh.GetInfo()} | Giá lăn bánh: {maxGiaLanBanh.TinhGiaLanBanh():N0} VNĐ");
            }
            else
            {
                Console.WriteLine("Không có phương tiện nào.");
            }

            Console.Write("\nNhập tên hãng muốn tìm kiếm: ");
            string keyword = Console.ReadLine() ?? "";
            var ketQuaTimKiem = quanLy.SearchByName(keyword);

            Console.WriteLine($"\nkết quả tìm kiếm hãng '{keyword}': ");
            if (ketQuaTimKiem.Any())
            {
                foreach (var pt in ketQuaTimKiem)
                {
                    Console.WriteLine($"{pt.GetInfo()} | Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy phương tiện nào.");
            }
        }
    }
}
