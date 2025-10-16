using System;
using System.Collections.Generic;
class ListOfIntegers
{
    private List<int> numArr;

    public ListOfIntegers()
    {
        this.numArr = new List<int>();
    }

    public int SumOfOdd()
    {
        int sum = 0;
        bool exist = false;
        for (int i = 0; i < numArr.Count; i++)
        {
            if (numArr[i] % 2 == 1)
            {
                sum += numArr[i];
                exist = true;
            }
        }
        return exist?sum:-1;
    }

    public void Add(int x)
    {
        numArr.Add(x);
    }

    bool IsPrime(int num)
    {
        if (num < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    public int CountPrime()
    {
        int sum = 0;
        for (int i = 0; i < numArr.Count; i++)
        {
            if (IsPrime(numArr[i]))
            {
                sum++;
            }
        }
        return sum;
    }

    bool IsPerfectSquare(int num)
    {
        if (num < 0)
            return false;
        int root = (int)Math.Sqrt(num);
        if (root * root == num)
            return true;
        else
            return false;
    }

    public int FindSmallestPerfectSquare()
    {
        int minn = 999;
        bool exist = false;
        for (int i = 0; i < numArr.Count; i++)
        {
            if (IsPerfectSquare(numArr[i]) && numArr[i] < minn)
            {
                minn = numArr[i];
                exist = true;
            }
        }
        return exist?minn:-1;
    }
}

class Program
{
    public static void Main()
    {
        Random random = new Random();
        ListOfIntegers arr = new ListOfIntegers();

        int n;
        Console.Write("Nhap so phan tu trong mang: ");
        string input=Console.ReadLine();

        if ((!int.TryParse(input, out n )|| n <= 0))
        {
            Console.WriteLine("So phan tu khong hop le!");
            return;
        }
        else {
           

            for (int i = 0; i < n; i++)
            {
                int x = random.Next(1, 100);
                arr.Add(x);
                Console.Write(x + " ");
            }

            Console.WriteLine("\nTong phan tu le cua mang: " + arr.SumOfOdd());
            Console.WriteLine("So nguyen to co trong mang: " + arr.CountPrime());
            Console.WriteLine("so chinh phuong nho nhat: " + arr.FindSmallestPerfectSquare());
        }
    }
}