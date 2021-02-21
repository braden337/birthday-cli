using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("\x1b[2J\x1b[H");

            DateTime birthday;

            while (true)
            {
                Console.Write("\x1b[KWhen's your birthday? ('e' to exit) ");
                var input = Console.ReadLine();

                if (DateTime.TryParse(input, out birthday))
                {
                    var today = DateTime.Now;
                    var difference = today - birthday;
                    var age = difference.Duration().Days / 365.25;

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("\x1b[KYou are {0} years old.\x1b[F", (int)age);
                    Console.ResetColor();
                }
                else if (input == "e")
                {
                    Console.Write("\x1b[2J\x1b[H");
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\x1b[KThat's not a valid date\x1b[F");
                    Console.ResetColor();
                }
            }
        }
    }
}
