using System;

class Program  
{
    static void Main()
    {
        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("1. chay bai tap 3.1 calculator");
            Console.WriteLine("2. chay bai tap 3.2 phuong trinh bac 2");
            Console.WriteLine("3. chay bai tap 3.3 so nguyen to & fibonacci");
            Console.WriteLine("0. thoat chuong trinh");
            Console.WriteLine("nhap lua chon cua ban: "); Console.WriteLine("chon chuc nang ban muon: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            Console.Clear(); 

            switch (choice)
            {
                case 1:
                    bt1();
                    break;
                case 2:
                    bt2();
                    break;
                case 3:
                    bt3();
                    break;
                case 0:
                    Console.WriteLine("Da thoat chuong trinh. Tam biệt!");
                    break;
                default:
                    Console.WriteLine("Lua chon khong hop le! Vui long chon tu 0 den 3.");
                    break;
            }

            if (choice != 0)
            {
                Console.WriteLine("\nNhan phim bat ky de quay lai Menu...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }

    static void bt1()
    {
        Console.WriteLine("--- BAI TAP 1: CALCULATOR ---");
        Console.Write("Nhap a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap phep toan (+, -, *, /, %): ");
        char op = Convert.ToChar(Console.ReadLine()!);

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

        Console.WriteLine($"Ket qua: {result}");
    }

    static void bt2()
    {
        Console.WriteLine("--- BAI TAP 2: PHUONG TRINH BAC 2 ---");
        Console.Write("Nhap a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Nhap c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
                Console.WriteLine(c == 0 ? "Phuong trinh vo so nghiem." : "Phuong trinh vo nghiem.");
            else
                Console.WriteLine($"Phuong trinh co 1 nghiem: x = {-c / b:F2}");
        }
        else
        {
            double delta = b * b - 4 * a * c;
            if (delta > 0)
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double x2 = (-b - Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"x1 = {x1:F2}, x2 = {x2:F2}");
            }
            else if (delta == 0)
            {
                Console.WriteLine($"Nghiem kep x = {-b / (2 * a):F2}");
            }
            else
            {
                Console.WriteLine("Vo nghiem.");
            }
        }
    }

    static void bt3()
    {
        Console.WriteLine("--- BAI TAP 3: SO NGUYEN TO, HOAN HAO & FIBONACCI ---");
        Console.Write("Nhap so nguyen duong N: ");
        int n = Convert.ToInt32(Console.ReadLine());

        if (shh(n)) Console.Write($"{n} la So hoan hao! ");
        else Console.Write($"{n} KHONG la So hoan hao! ");

        if (snt(n)) Console.WriteLine($"{n} la So nguyen to.");
        else Console.WriteLine($"{n} KHONG la So nguyen to.");

        Fibonacci(n);
    }

    static bool snt(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
            if (n % i == 0) return false;
        return true;
    }

    static bool shh(int n)
    {
        if (n <= 0) return false;
        int sum = 0;
        for (int i = 1; i < n; i++)
            if (n % i == 0) sum += i;
        return sum == n;
    }

    static void Fibonacci(int n)
    {
        if (n <= 0) return;
        long a = 0, b = 1;
        int count = 0;
        Console.Write($"Day Fibonacci {n} so: ");
        while (count < n)
        {
            Console.Write(count == n - 1 ? $"{a}" : $"{a}, ");
            long temp = a + b;
            a = b;
            b = temp;
            count++;
        }
        Console.WriteLine();
    }
}
