//BÀI TẬP 3: MÔ PHỎNG HỆ THỐNG XỬ LÝ ĐƠN HÀNG VÀ TÍNH ĐA HÌNH
//* **Khối kiến thức trọng tâm:**Đa hình tại thời điểm biên dịch (Compile-time / Method Overloading) & Đa hình tại thời điểm thực thi (Runtime / Method Overriding) (3.4).
//* **Mục tiêu:**Phân biệt rõ cách nạp chồng phương thức (cùng tên, khác chữ ký tham số) và ghi đè phương thức thông qua từ khóa `virtual` / `override`.

//### Yêu cầu thiết kế:
//1. **Cài đặt Method Overloading qua lớp tiện ích `DiscountCalculator`**:
//   * `ApplyDiscount(decimal totalAmount)`: Giảm mặc định 5% cho tổng đơn hàng.
//   * `ApplyDiscount(decimal totalAmount, double percentage)`: Giảm theo phần trăm tùy biến (`percentage` từ 0 đến 100).
//   * `ApplyDiscount(decimal totalAmount, decimal fixedVoucher, decimal minimumOrder)`: Áp dụng mã giảm tiền mặt `fixedVoucher` nếu giá trị đơn `totalAmount >= minimumOrder`.
//2. **Cài đặt Method Overriding qua bài toán Vận chuyển**:
//   ***Lớp cha `DeliveryService`**:
//     *Chứa thuộc tính: `OrderId` (`string`), `DistanceKm` (`double`).
//     * Phương thức: `public virtual decimal CalculateShippingFee()` tính phí vận chuyển cơ bản bằng `DistanceKm * 5000` VNĐ.
//   * **Lớp con `ExpressDelivery` (Giao siêu tốc) kế thừa `DeliveryService`**:
//     *Ghi đè `CalculateShippingFee()`: Phí gấp 1.5 lần mức cơ bản cộng thêm phụ phí hỏa tốc 20.000 VNĐ.
//   * **Lớp con `EcoDelivery` (Giao tiết kiệm) kế thừa `DeliveryService`**:
//     *Ghi đè `CalculateShippingFee()`: Nếu quãng đường `> 10km`, giảm 10 % trên tổng phí vận chuyển cơ bản.
//3. **Kịch bản kiểm thử (`Main`):**
//   *Thử nghiệm gọi cả 3 phiên bản hàm nạp chồng `ApplyDiscount`.
//   * Tạo một danh sách kiểu lớp cha `List<DeliveryService>` chứa các đối tượng cụ thể (`ExpressDelivery`, `EcoDelivery`).
//   * Dùng vòng lặp duyệt qua danh sách và in chi phí vận chuyển để quan sát tính đa hình thực thi (Runtime Polymorphism).

using System;
using System.Collections.Generic;

namespace OrderSystemSimple
{
    public class discountCalculator
    {
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount * 0.95m; // Giảm 5%
        }
        public decimal ApplyDiscount(decimal totalAmount, double percentage)
        {
            if (percentage < 0 || percentage > 100)
                throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
            return totalAmount * (decimal)(1 - percentage / 100);
        }
        public decimal ApplyDiscount(decimal totalAmount, decimal fixedVoucher, decimal minimumOrder)
        {
            if (totalAmount >= minimumOrder)
                return totalAmount - fixedVoucher;
            return totalAmount;
        }
    }

    public class DeliveryService
    {
        public string OrderId { get; set; } = string.Empty;     

        public double DistanceKm { get; set; }
        public virtual decimal CalculateShippingFee()
        {
            return (decimal)(DistanceKm * 5000);
        }
    }

    public class ExpressDelivery : DeliveryService
    {
        public override decimal CalculateShippingFee()
        {
            return base.CalculateShippingFee() * 1.5m + 20000;
        }
    }

    public class EcoDelivery : DeliveryService
    {
        public override decimal CalculateShippingFee()
        {
            decimal baseFee = base.CalculateShippingFee();
            if (DistanceKm > 10)
                return baseFee * 0.9m; // Giảm 10%
            return baseFee;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Kiểm thử Method Overloading
            var discountCalculator = new discountCalculator();
            decimal totalAmount = 100000;
            Console.WriteLine("Giảm mặc định 5%: " + discountCalculator.ApplyDiscount(totalAmount));
            Console.WriteLine("Giảm 10%: " + discountCalculator.ApplyDiscount(totalAmount, 10));
            Console.WriteLine("Giảm 20000 nếu đơn >= 80000: " + discountCalculator.ApplyDiscount(totalAmount, 20000, 80000));
            // Kiểm thử Method Overriding
            List<DeliveryService> deliveries = new List<DeliveryService>
            {
                new ExpressDelivery { OrderId = "EXP001", DistanceKm = 15 },
                new EcoDelivery { OrderId = "ECO001", DistanceKm = 12 },
                new EcoDelivery { OrderId = "ECO002", DistanceKm = 8 }
            };
            foreach (var delivery in deliveries)
            {
                Console.WriteLine($"Order ID: {delivery.OrderId}, Shipping Fee: {delivery.CalculateShippingFee()} VNĐ");
            }
        }
    }
}
