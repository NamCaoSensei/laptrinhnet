using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhap phep toan (+, -, *, /, %): ");
        char op = Convert.ToChar(Console.ReadLine());

        string result = (op, b) switch
        {
            ('+', _) => (a + b).ToString("F2"),
            ('-', _) => (a - b).ToString("F2"),
            ('*', _) => (a * b).ToString("F2"),
            ('/', 0) => "Loi: Khong the chia cho 0!",
            ('/', _) => (a / b).ToString("F2"),
            ('%', 0) => "Loi: Khong the chia cho 0!",
            ('%', _) => (a % b).ToString("F2"),
            _ => "Loi: Phep toan khong hop le!"
        };

        Console.WriteLine(result);
    }
}
