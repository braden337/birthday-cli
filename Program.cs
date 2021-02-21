using System;

namespace Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            var clearScreen = "\x1b[2J\x1b[H";
            var clearLine = "\x1b[K";
            var upLine = "\x1b[F";

            Console.Write(clearScreen);

            DateTime birthday;

            while (true)
            {
                Console.Write("{0}When's your birthday? ('e' to exit) ", clearLine);
                var input = Console.ReadLine();

                if (DateTime.TryParse(input, out birthday))
                {
                    var today = DateTime.Now;
                    TimeSpan difference = today - birthday;
                    var age = (int)(difference.Duration().Days / 365.25);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("{0}You are {1} years old.{2}", clearLine, age, upLine);
                    Console.ResetColor();
                }
                else if (input == "e")
                {
                    Console.Write(clearScreen);
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}hat's not a valid date{1}", clearLine, upLine);
                    Console.ResetColor();
                }
            }
        }
    }
}
