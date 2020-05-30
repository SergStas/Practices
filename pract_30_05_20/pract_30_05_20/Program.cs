using System;

namespace pract_30_05_20
{
    class Program
    {
        static void Main(string[] args)
        {
            Screen screen = new Screen(64, 16);
            CommandEventArgs arg = new CommandEventArgs("Hello", ConsoleColor.Green, Position.Top, 1, 3);
            screen.LoadCommands(new[] {new Command(arg)});
            screen.Begin();
            Console.ReadKey();
        }
    }
}