using System;

class Program
{
    private short day;
    private short month;
    private short year;

    public Program(short d, short m, short y)
    {
        day = d;
        month = m;
        year = y;
    }

    public Program()
    {
        day = 1;
        month = 1;
        year = 1;
    }

    public bool IsLeapYear()
    {
        return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
    }

    public int GetDayOfYear()
    {
        int[] monthDays = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        if (IsLeapYear())
        {
            monthDays[2] = 29;
        }
        int dayOfYear = 0;
        for (int i = 1; i < month; i++)
        {
            dayOfYear += monthDays[i];
        }
        dayOfYear += day;
        return dayOfYear;
    }

    public void DayOfWeek()
    {
        int S=year+(year-1)/4-(year-1)/100+(year-1)/400 + GetDayOfYear();
        int dayOfWeek = S % 7;
        switch(dayOfWeek)
        {
            case 0:
                Console.WriteLine("Thu 7");
                break;
            case 1:
                Console.WriteLine("Chu nhat");
                break;  
            case 2:
                Console.WriteLine("Thu 2");
                break;
            case 3:
                Console.WriteLine("Thu 3");
                break;
            case 4:
                Console.WriteLine("Thu 4");
                break;
            case 5:
                Console.WriteLine("Thu 5");
                break;
            default:
                Console.WriteLine("Thu 6");
                break;
        }
    }

    public void Nhap()
    {

        Console.Write("Nhap nam: ");
        year = short.Parse(Console.ReadLine());
        while (year <= 0)
        {
            Console.WriteLine("Nam khong hop le");
            Console.Write(" Nhap lai nam hop le: ");
            short nyear = short.Parse(Console.ReadLine());
            year = nyear;

        }

        Console.Write("Nhap thang: ");
        month = short.Parse(Console.ReadLine());
        while (month < 1 || month > 12)
        {
            Console.WriteLine("Thang khong hop le");
            Console.Write(" Nhap lai thang hop le: ");
            short nmonth = short.Parse(Console.ReadLine());
            month = nmonth;
        }

        Console.Write("Nhap ngay: ");
        day = short.Parse(Console.ReadLine());
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
                    while (day > 31 || day < 1)
                    {
                        Console.WriteLine("Ngay khong hop le");
                        Console.Write("Nhap lai ngay hop le: ");   
                        short nday = short.Parse(Console.ReadLine());
                        day = nday;
                    }
                    break;
                }
            case 4:
            case 6:
            case 9:
            case 11:
                { 
                    while (day > 30 || day < 1)
                    {
                        Console.WriteLine("Ngay khong hop le");
                        Console.Write("Nhap lai ngay hop le: ");
                        short nday = short.Parse(Console.ReadLine());
                        day = nday;
                    }
                    break;
                }
            default:
                {
                    if (IsLeapYear())
                    {
                        while (day > 29 || day < 1)
                        {
                            Console.WriteLine("Ngay khong hop le");
                            Console.Write("Nhap lai ngay hop le: ");
                            short nday = short.Parse(Console.ReadLine());
                            day = nday;
                        }
                    }
                    else
                        while (day > 28 || day < 0)
                    { 
                        Console.WriteLine("Ngay khong hop le");
                        Console.Write("Nhap lai ngay hop le: ");
                        short nday = short.Parse(Console.ReadLine());
                        day = nday;
                    }
                    break;
                }
        }
    }

    public static void Main()
    {
        Program p = new Program();
        p.Nhap();
        p.DayOfWeek();

    }
}