using System;
class Date
{
    private short day;
    private short month;
    private short year;
    public Date()
    {
        day = 1;
        month = 1;
        year = 1;
    }
    public void Nhap()
    {
        Console.Write("Nhap ngay: ");
        day = short.Parse(Console.ReadLine());
        Console.Write("Nhap thang: ");
        month = short.Parse(Console.ReadLine());
        Console.Write("Nhap nam: ");
        year = short.Parse(Console.ReadLine());
    }
    public bool IsValid()
    {
        if (year <= 0)
        {
            Console.WriteLine("Nam khong hop le");
            return false;
        }
        else
        {
            if (month < 1 || month > 12)
            {
                Console.WriteLine("Thang khong hop le");
                return false;
            }
            else
            {
                switch (month)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        {
                            if (day > 31 || day < 1)
                            {
                                Console.WriteLine("Ngay khong hop le");
                                return false;
                            }
                            break;
                        }
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        {
                            if (day > 30 || day < 1)
                            {
                                Console.WriteLine("Ngay khong hop le");
                                return false;
                            }
                            break;
                        }
                    default:
                        {
                            if (CheckLeapYear(year))
                            {
                                if (day > 29 || day < 1)
                                {
                                    Console.WriteLine("Ngay khong hop le");
                                    return false;
                                }
                            }
                            else
                                if (day > 28 || day < 1)
                                {
                                    Console.WriteLine("Ngay khong hop le");
                                return false;
                                }
                            break;
                        }
                }
            }
        }
        return true;
    }
    public bool CheckLeapYear(short year)
    {
        if (year % 4 == 0)
            if (year % 100 == 0)
                if (year % 400 == 0)
                    return true;
                else
                    return false;
            else
                return true;
        else
            return false;
    }
}
class Program
{
    public static void Main()
    {
        Date d = new Date();
        d.Nhap();
        if (d.IsValid())
            Console.WriteLine("Hop le");
        else
            Console.WriteLine("=>Khong hop le");
    }
}