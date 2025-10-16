class Program
{
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

    public short GetDaysInMonth(short month, short year)
    {
        switch (month)
        {
            case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                return 31;
            case 4: case 6: case 9: case 11:
                return 30;
            default:
                if (CheckLeapYear(year))
                    return 29;
                else
                    return 28;
        }
    }

    public static void Main()
    {
        Program p = new Program();
        short month;
        short year;

        Console.Write("Nhap thang: ");
        month = short.Parse(Console.ReadLine());
        while (month < 1 || month > 12)
        {
            Console.Write("Thang khong hop le. ");
            Console.Write("Nhap lai thang hop le: ");
            short nmonth = short.Parse(Console.ReadLine());
            month = nmonth;
        }

            
        Console.Write("Nhap nam: ");
        year = short.Parse(Console.ReadLine());
        while (year < 1)
        {
            Console.Write("Nam khong hop le. ");
            Console.Write("Nhap lai nam hop le: ");
            short nyear = short.Parse(Console.ReadLine());
            year = nyear;
            
        }

        short days = p.GetDaysInMonth(month, year);

        if (days != -1)
            Console.WriteLine("So ngay trong thang " + month + " nam " + year + " la: " + days);
    }
}
