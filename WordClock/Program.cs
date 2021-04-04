using System;
using System.Threading;

namespace WordClock
{
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Clock clock = Clock.Create(Language.Spanish);
            DateTime dt = DateTime.Now;

            while (true)
            {
                Console.Clear();

                Console.WriteLine(dt.ToString("HH:mm"));

                clock.Print(dt);

                Console.WriteLine();
                Console.WriteLine(clock.Get(dt));

                Console.WriteLine();
                Console.WriteLine("Press Q to exit.");
                Console.WriteLine("Press B to go back to previous minute.");
                Console.WriteLine("Press N or space to go to the next minute.");
                Console.WriteLine("Press W to write a custom time.");
                Console.WriteLine();

                ConsoleKeyInfo key = Console.ReadKey(intercept: true /* Do not display the key */);
                switch (key.KeyChar)
                {
                    // Previous minute
                    case 'b':
                    case 'B':
                        dt = dt.AddMinutes(-1);
                        break;

                    // Next minute
                    case 'n':
                    case 'N':
                    case ' ':
                        dt = dt.AddMinutes(1);
                        break;

                    // Custom time
                    case 'w':
                    case 'W':
                        Console.Write("Type a valid time (HH:mm): ");
                        string? custom = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(custom))
                        {
                            Console.WriteLine("Must type a valid string.");
                        }
                        else if (DateTime.TryParse(custom, out DateTime r))
                        {
                            dt = new DateTime(dt.Year, dt.Month, dt.Day, r.Hour, r.Minute, r.Second);
                        }
                        else
                        {
                            Console.WriteLine("Invalid time!");
                            Thread.Sleep(TimeSpan.FromSeconds(1));
                        }
                        break;

                    // Quit
                    case 'q':
                    case 'Q':
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Unrecognized key. Try again.");
                        break;

                }
            }
        }
    }
}
