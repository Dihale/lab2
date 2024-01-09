namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            var calendar = new Calendar();
            var calendarService = new CalendarService(calendar);

            calendarService.RunCalendar();
        }
    }
}