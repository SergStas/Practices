using System;
using System.Collections.Generic;

namespace pract_26_06_20
{
    public class ConsoleParser
    {
        private Dictionary<char, Func<Ratio, Ratio, Ratio>> _operations;
        
        public void Start()
        {
            InitializeDictionary();
            bool quit = false;
            while (!quit)
                ParseLine(out quit);
        }

        private void InitializeDictionary() =>
            _operations = new Dictionary<char, Func<Ratio, Ratio, Ratio>>
            {
                {'+', (ratio, ratio1) => ratio + ratio1},
                {'-', (ratio, ratio1) => ratio - ratio1},
                {'*', (ratio, ratio1) => ratio * ratio1},
                {':', (ratio, ratio1) => ratio / ratio1},
            };

        private void ParseLine(out bool quit)
        {
            quit = false;
            string request = Console.ReadLine().Replace("//", ":");
            if (request == "quit")
                quit = true;
            else
            {
                string[] parts = request.Split(new[] {':', '-', '+', '*'});
                Ratio result = _operations[request[parts[0].Length]](ParseRatio(parts[0]), ParseRatio(parts[1]));
                Console.WriteLine(result);
            }
        }

        private Ratio ParseRatio(string s)
        {
            string[] parts = s.Split(' ');
            int integer = parts.Length == 1 ? 0 : int.Parse(parts[0]);
            string[] ratioParts = parts[^1].Split('/');
            return new Ratio(int.Parse(ratioParts[0]), int.Parse(ratioParts[1]), integer);
        }
    }
}