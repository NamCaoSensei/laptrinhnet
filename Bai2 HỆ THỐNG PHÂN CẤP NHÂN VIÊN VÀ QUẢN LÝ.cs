using System;
using System.Text;

public class BankAccount
{
    private const decimal MinimumBalance = 50_000m;
    private static long _nextAccountNumber = 1_000_000_001;
    private decimal _balance;
    private string _accountHolder = string.Empty;

    public long AccountNumber { get; init; }

    public string AccountHolder
    {
        get => _accountHolder;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Tên chủ tài khoản không được để trống.", nameof(value));

            _accountHolder = value;
        }
    }

    public decimal Balance => _balance;

    public BankAccount(string accountHolder, decimal initialBalance)
    {
        if (initialBalance < MinimumBalance)
            throw new ArgumentException("Số dư ban đầu phải từ 50.000 VNĐ.", nameof(initialBalance));

        AccountNumber = _nextAccountNumber++;
        AccountHolder = accountHolder;
        _balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Số tiền nạp phải lớn hơn 0.", nameof(amount));

        _balance += amount;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Số tiền rút phải lớn hơn 0.", nameof(amount));

        if (_balance - amount < MinimumBalance)
            return false;

        _balance -= amount;
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Số tài khoản: {AccountNumber}");
        Console.WriteLine($"Chủ tài khoản: {AccountHolder}");
        Console.WriteLine($"Số dư: {Balance:N0} VNĐ");
        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        BankAccount account1 = new("Nguyễn Văn An", 100_000m);
        BankAccount account2 = new("Trần Thị Bình", 500_000m);

        Console.WriteLine("KIỂM TRA BẮT LỖI KHỞI TẠO");
        try
        {
            _ = new BankAccount("Tài khoản lỗi", 40_000m);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Lỗi khởi tạo: {ex.Message}\n");
        }

        Console.WriteLine("KIỂM TRA GIAO DỊCH");
        account1.Deposit(50_000m);
        Console.WriteLine($"Rút 80.000 VNĐ: {account1.Withdraw(80_000m)}");
        Console.WriteLine($"Rút vượt hạn mức: {account1.Withdraw(30_000m)}\n"); 

        Console.WriteLine("THÔNG TIN TÀI KHOẢN");
        account1.DisplayInfo();
        account2.DisplayInfo();
    }
}
