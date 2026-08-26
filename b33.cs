using System;
class Program
{
    static bool kt_shh(int n)
    {
        int sum = 0;
        for (int i = 1; i < n; i++)
        {
            if (n % i == 0)
            {
                sum += i;
            }
        }
        return sum == n;
    }

    static bool kt_snt(int n)
    {
        if (n < 2)
        {
            return false;
        }
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    static void Fibonacci(int n)
    {
        int a = 0, b = 1, c;
        Console.WriteLine("Day Fibonacci: ");
        for (int i = 0; i < n; i++)
        {
            Console.Write(a + " ");
            c = a + b;
            a = b;
            b = c;
        }
    }

    static void Main()
    {
        Console.WriteLine("nhap so nguyen n: ");
        int n = Convert.ToInt16(Console.ReadLine());

        if (kt_shh(n))
        {
            Console.Write($"{n} la so hoan hao");
        }
        else
        {
            Console.WriteLine($"{n} khong phai so hoan hao");
        }

        if (kt_snt(n))
        {
            Console.WriteLine($"{n} la so nguyen to");

        }
        else
        {
            Console.WriteLine($"{n} khong phai so nguyen to");
        }

        Fibonacci(n);
    }
}
