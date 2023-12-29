using System;

namespace CalendarApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calendar App!");
            Console.WriteLine("To use the app, enter one of the following commands:");
            Console.WriteLine("1 - Check if a year is a leap year");
            Console.WriteLine("2 - Calculate the duration between two dates");
            Console.WriteLine("3 - Get the day of the week for a given date");
            Console.WriteLine("Enter 'exit' to quit the program.");

            string command = "";
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

        static void CheckLeapYear()
        {
            try
            {
                Console.Write("Enter a year: ");
                int year = Convert.ToInt32(Console.ReadLine());


                if (DateTime.IsLeapYear(year))
                    Console.WriteLine($"{year} is a leap year.");
                else
                    Console.WriteLine($"{year} is not a leap year.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Incorrect data entry format");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void CalculateDuration()
        {
            Console.Write("Enter the first date (dd/mm/yyyy): ");
            string date1String = Console.ReadLine();

            Console.Write("Enter the second date (dd/mm/yyyy): ");
            string date2String = Console.ReadLine();

            DateTime date1;
            DateTime date2;

            if (DateTime.TryParseExact(date1String, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date1)
                && DateTime.TryParseExact(date2String, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date2))
            {
                TimeSpan duration = date2 - date1;
                Console.WriteLine($"The duration between {date1.ToShortDateString()} and {date2.ToShortDateString()} is {duration.TotalDays} days.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }

        static void GetDayOfWeek()
        {
            Console.Write("Enter a date (dd/mm/yyyy): ");
            string dateString = Console.ReadLine();

            DateTime date;

            if (DateTime.TryParseExact(dateString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out date))
            {
                Console.WriteLine($"The day of the week for {date.ToShortDateString()} is {date.DayOfWeek}.");
            }
            else
            {
                Console.WriteLine("Invalid date format. Please try again.");
            }
        }
    }
}