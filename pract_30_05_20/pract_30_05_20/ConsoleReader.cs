using System;
using System.Collections.Generic;

namespace pract_30_05_20
{
    public class ConsoleReader
    {
        private List<Command> _result;

        private void DoWork()
        {
            Console.WriteLine("Input args:");
            string request = Console.ReadLine();
        }

        private bool ProcessRequest(string request) //TODO: finish
        {
            string[] parts = request.Split(' ');
            if (parts.Length != 5)
                return false;
            //if (Enum.TryParse(ConsoleColor, ))

            return true;
        }
    }
}