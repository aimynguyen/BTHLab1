using System;

class Matrix
{
    private int[,] matrix;
    private int n;
    private int m;

    public Matrix()
    {
        this.m = 1;
        this.n = 1;
    }

    public Matrix(int n, int m)
    {
        this.m = m;
        this.n = n;
        matrix = new int[n, m];
        Random random = new Random();

        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < m; j++)
            {
                matrix[i, j] = random.Next(0, 101);
            }
        }
    }

    public void Xuat()
    {
        for (int i = 0; i < n; i++)
        {
            Console.Write("\t");
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j]+" ");
            }
            Console.WriteLine();
        }
    }

    public int FindMin()
    {
        int result = 101;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if(matrix[i, j] < result)
                    result = matrix[i, j];
            }
        }
        return result;
    }

    public int FindMax()
    {
        int result = -1;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i, j] > result)
                    result = matrix[i, j];
            }
        }
        return result;
    }

    public void FindMaxSumRow()
    {
        int sumMax = -1;
        int sum = 0;
        int index= -1;
        for (int i = 0; i < n; i++)
        {
            sum = 0;
            for(int j=0; j < m; j++)
            {
                sum += matrix[i, j];
            }
            if (sumMax < sum)
            {
                sumMax = sum;
                index = i;
            }
        }
        Console.WriteLine($"Dong thu {index+1} co tong lon nhat la {sumMax} ");
    }

    public bool IsPrime(int n)
    {
        if (n < 2)
            return false;
        for(int i=2; i<Math.Sqrt(n); i++)
        {
            if (n % i == 0)
                return false;
        }
        return true;
    }

    public int SumNonPrime()
    {
        int sum = 0;
        for(int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                if (!IsPrime(matrix[i,j]))
                    sum += matrix[i, j];
            }
        }
        return sum;
    }

    public void DeleteRow(int k)
    {
        if(k>n || k<1)
        {
            Console.WriteLine("Khong the xoa dong nay");
            return;
        }
        int[,] newMatrix = new int[n-1, m];
        for(int i=0, x=0; i<n; i++)
        {
            if(i==k-1)
                continue;
            for(int j=0; j<m; j++)
            {
                newMatrix[x, j] = matrix[i, j];
            }
            x++;
        }
        matrix = newMatrix;
        n--;
    }

    public void DeleteColumnContainMax()
    {
        int k = -1;
        for (int i=0; i<n; i++)
        {
            for(int j=0; j<m; j++)
            {
                if(matrix[i,j] == FindMax())
                {
                    k = j;
                    break;
                }
            }
        }
        int[,] newMatrix = new int[n, m-1];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0, y=0; j < m; j++)
            {
                if (j == k)
                    continue;
                newMatrix[i, y] = matrix[i, j];
                y++;
            }
        }
        matrix = newMatrix;
        m--;
    }
}

class Program
{
    public static void Main()
    {
       

        Console.Write("Nhap so dong: ");
        int n=int.Parse(Console.ReadLine());

        Console.Write("Nhap so cot: ");
        int m=int.Parse(Console.ReadLine());

        Matrix matrix = new Matrix(n,m);

        matrix.Xuat();//xuat matrix
        Console.WriteLine($"Phan tu lon nhat {matrix.FindMin()}");//tim pt lon nhat
        Console.WriteLine($"Phan tu nho nhat {matrix.FindMax()}");//tim pt nho nhat
        matrix.FindMaxSumRow();//tim dong co tong lon nhat
        Console.WriteLine($"Tong cac so khong phai nguyen to: {matrix.SumNonPrime()}");//tinh tong so khong phai nguyen to
        //xoa dong k
        Console.Write("Nhap dong can xoa: ");
        int k=int.Parse(Console.ReadLine());
        Console.WriteLine("Ma tran sau khi xoa dong " + k);
        Matrix copyMatrix1 = matrix;
        Matrix copyMatrix2 = matrix;
        copyMatrix1.DeleteRow(k);
        copyMatrix1.Xuat();
        //xoa cot chua pt lon nhat
        copyMatrix2.DeleteColumnContainMax();
        Console.WriteLine("Ma tran sau khi xoa cot chua pt lon nhat: ");
        copyMatrix2.Xuat();

    }
}