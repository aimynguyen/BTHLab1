using System;
class Program
{
    static bool IsPrime(int n)
    {
        if(n<2)
            return false;
        for(int i=2; i <= Math.Sqrt(n); i++)
        {
            if(n%i==0)
                return false;
        }
        return true;
    }

    public static int SumPrime(int n)
    {
        int sum = 0;
        for(int i=0; i<n; i++)
        {
            if (IsPrime(i))
            {
                sum += i;
            }
        }
        return sum;
    }

    public static void Main()
    {
        int n;
        Console.Write("Nhap vao so nguyen n: ");
        while (!int.TryParse(Console.ReadLine(), out n))
        {
            Console.Write("Gia tri khong hop le, vui long nhap lai n: ");
        }

        while (n < 0)
        {
            Console.Write(n + " la so am, vui long nhap lai n: ");
  
            n = int.Parse(Console.ReadLine());
        }

        if (SumPrime(n) > 0)
            Console.WriteLine("Tong can tim la: " + SumPrime(n));
        else 
            Console.WriteLine("Khong co so nguyen to nao nho hon " + n);
    }
}