namespace lab2;

public class CalendarService
{
    private Calendar _calendar = new Calendar();

    public CalendarService(Calendar calendar)
    {
        _calendar = calendar;
    }

    public void RunCalendar()
    {
        Console.WriteLine("Welcome to the Calendar App!");
        Console.WriteLine("To use the app, enter one of the following commands:");
        Console.WriteLine("1 - Check if a year is a leap year");
        Console.WriteLine("2 - Calculate the duration between two dates");
        Console.WriteLine("3 - Get the day of the week for a given date");
        Console.WriteLine("Enter 'exit' to quit the program.");

        var command = "";
        while (command != "exit")
        {
            Console.Write("Enter a command: ");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    CheckLeapYear();
                    break;
                case "2":
                    CalculateDuration();
                    break;
                case "3":
                    GetDayOfWeek();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the program...");
                    break;
                default:
                    Console.WriteLine("Invalid command. Choose a command using numbers. Please try again.");
                    break;
            }
        }
    }

    private void CheckLeapYear()
    {
        Console.Write("Enter a year: ");
        if (int.TryParse(Console.ReadLine(), out var year))
        {
            if (_calendar.IsLeapYear(year))
                Console.WriteLine($"{year} is a leap year.");
            else
                Console.WriteLine($"{year} is not a leap year.");
        }
        else
        {
            Console.WriteLine("Incorrect data entry format. Please enter a valid year.");
        }
    }

    private void CalculateDuration()
    {
        Console.Write("Enter the first date (dd/MM/yyyy): ");
        var date1String = Console.ReadLine();

        Console.Write("Enter the second date (dd/MM/yyyy): ");
        var date2String = Console.ReadLine();

        if (DateTime.TryParseExact(date1String, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                out var date1)
            && DateTime.TryParseExact(date2String, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                out var date2))
        {
            try
            {
                var duration = _calendar.CalculateDuration(date1, date2);
                Console.WriteLine(
                    $"The duration between {date1.ToShortDateString()} and {date2.ToShortDateString()} is {duration} days.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }

    private void GetDayOfWeek()
    {
        Console.Write("Enter a date (dd/MM/yyyy): ");
        var dateString = Console.ReadLine();

        if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,
                out var date))
        {
            Console.WriteLine($"The day of the week for {date.ToShortDateString()} is {_calendar.GetDayOfWeek(date)}.");
        }
        else
        {
            Console.WriteLine("Invalid date format. Please try again.");
        }
    }
}