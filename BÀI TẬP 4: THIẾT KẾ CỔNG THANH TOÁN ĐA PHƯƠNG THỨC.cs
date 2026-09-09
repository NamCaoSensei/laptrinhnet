//BÀI TẬP 4: THIẾT KẾ CỔNG THANH TOÁN ĐA PHƯƠNG THỨC
//* **Khối kiến thức trọng tâm:**Abstract Classes vs Interfaces(3.5), Access Modifiers nội bộ (3.2).
//* **Mục tiêu:**Áp dụng bảng so sánh giữa Abstract Class (mối quan hệ cốt lõi "Is-A") và Interface (năng lực giao tiếp "Can-Do", hỗ trợ đa triển khai).

//### Yêu cầu thiết kế:
//1. **Định nghĩa các Interface**:
//   * `IPayable`: Chứa phương thức `bool ProcessPayment(decimal amount);`.
//   * `IRefundable`: Chứa phương thức `bool ProcessRefund(decimal amount, string reason);`.
//2. * *Lớp trừu tượng `PaymentGateway` (Abstract Class)**:
//   *Các thuộc tính: `TransactionId` (`string`, `init`), `CreationDate` (`DateTime`, `init`), `Status` (`string`, `protected set`).
//   *Constructor `protected PaymentGateway(string transactionId)` khởi tạo mã giao dịch và gán `Status = "Pending"`.
//   * Phương thức trừu tượng: `public abstract void ValidateConnection();`.
//   *Phương thức thông thường: `public virtual void LogTransaction(string message)` ghi nhật ký giao dịch kèm mã `TransactionId`.
//3. **Lớp cụ thể `MomoPayment`**:
//   *Kế thừa từ `PaymentGateway` và triển khai cả 2 interface: `IPayable`, `IRefundable`.
//   * Bổ sung thuộc tính riêng: `PhoneNumber` (`string`).
//   * Ghi đè phương thức `ValidateConnection()`: In thông báo kiểm tra kết nối API MoMo.
//   * Cài đặt `ProcessPayment`: Kiểm tra thông tin hợp lệ, đổi `Status = "Success"`, trả về `true`.
//   * Cài đặt `ProcessRefund`: Ghi nhận lý do hoàn tiền, đổi `Status = "Refunded"`, trả về `true`.
//4. **Kịch bản kiểm thử (`Main`):**
//   *Khởi tạo đối tượng `MomoPayment`.
//   * Ép kiểu đối tượng sang các interface `IPayable` và `IRefundable` để gọi độc lập các hành vi thanh toán và hoàn tiền.

using System;

namespace PaymentSystemSimulation
{
    public interface IPayable
    {
        bool ProcessPayment(decimal amount);
    }

    public interface IRefundable
    {
        bool ProcessRefund(decimal amount, string reason);
    }

    public abstract class PaymentGateway
    {
        public string TransactionId { get; init; }
        public DateTime CreationDate { get; init; }

        public string Status { get; protected set; }

        protected PaymentGateway(string transactionId)
        {
            TransactionId = transactionId;
            CreationDate = DateTime.Now;
            Status = "Pending";
        }

        public abstract void ValidateConnection();

        public virtual void LogTransaction(string message)
        {
            Console.WriteLine($"[Log - {TransactionId}]: {message}");
        }
    }

    public class MomoPayment : PaymentGateway, IPayable, IRefundable
    {
        public string PhoneNumber { get; set; }

        public MomoPayment(string transactionId, string phoneNumber) : base(transactionId)
        {
            PhoneNumber = phoneNumber;
        }

        public override void ValidateConnection()
        {
            Console.WriteLine("Đang kiểm tra kết nối API tới hệ thống MoMo...");
        }

        public bool ProcessPayment(decimal amount)
        {
            ValidateConnection();
            Console.WriteLine($"Đang thanh toán {amount:N0} VNĐ qua SĐT {PhoneNumber}...");

            Status = "Success"; 
            LogTransaction("Thanh toán thành công.");
            return true;
        }

        public bool ProcessRefund(decimal amount, string reason)
        {
            Console.WriteLine($"Đang hoàn {amount:N0} VNĐ. Lý do: {reason}");

            Status = "Refunded";
            LogTransaction("Hoàn tiền thành công.");
            return true;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== KHỞI TẠO GIAO DỊCH ===");
            MomoPayment momo = new MomoPayment("MOMO-12345", "0901234567");

            Console.WriteLine($"Mã GD: {momo.TransactionId}");
            Console.WriteLine($"Ngày tạo: {momo.CreationDate}");
            Console.WriteLine($"Trạng thái ban đầu: {momo.Status}\n");

            Console.WriteLine("=== TIẾN HÀNH THANH TOÁN ===");
            momo.ProcessPayment(500000);
            Console.WriteLine($"Trạng thái sau thanh toán: {momo.Status}\n");

            Console.WriteLine("=== TIẾN HÀNH HOÀN TIỀN ===");
            momo.ProcessRefund(500000, "Sản phẩm bị lỗi");
            Console.WriteLine($"Trạng thái sau hoàn tiền: {momo.Status}");
        }
    }
}
