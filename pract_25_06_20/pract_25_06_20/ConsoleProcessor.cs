using System;
using System.Collections.Generic;
using System.Linq;

namespace pract_25_06_20
{
    public class ConsoleProcessor
    {
        private MatrixProcessor _engine;

        private Dictionary<string, Action<string>> _commands;

        public ConsoleProcessor(MatrixProcessor matrixProcessor)
        {
            _engine = matrixProcessor;
            InitializeCommands();
            DoWork();
        }

        public void InitializeCommands() =>
            _commands = new Dictionary<string, Action<string>>
            {
                {"new", CreateMatrix},
                {"show", index => Console.WriteLine(_engine.Show(int.Parse(index)))}
            };

        public void DoWork()
        {
            bool exit = false;
            while (!exit)
                try {PerformNext(out exit);}
                catch {Console.WriteLine("Something wrong");}
        }

        void PerformNext(out bool exit)
        {
            exit = false;
            string request = Console.ReadLine();
            if (request is null)
                return;
            string[] parts = request.Split(' ');
            if (request[0] != '-')
                Console.WriteLine("Incorrect input");;
            string command = parts[0].Substring(1);
            if (command == "exit")
                exit = true;
            string args = string.Join(' ', parts.Skip(1));
            if (!_commands.ContainsKey(command))
                Console.WriteLine($"Unknown command \"{command}\"");
            _commands[command](args);
        }
        
        bool TryParseNumbers(string args, out Tuple<double,double> result)
        {
            result = Tuple.Create<double, double>(0, 0);
            string[] parts = args.Split(' ');
            if (parts.Length != 2 || !double.TryParse(parts[0], out double n1) ||
                !double.TryParse(parts[1], out double n2))
                return false;
            result = Tuple.Create<double, double>(n1, n2);
            return true;
        }

        void CreateMatrix(string args)
        {
            string[] parts = args.Split(' ');
            if (parts.Length != 3 || int.TryParse(parts[1], out int rowsCount) ||
                int.TryParse(parts[2], out int columnsCount) || int.TryParse(parts[3], out int index))
            {
                Console.WriteLine("Incorrect arguments");
                return;
            }
            if (TryReadMatrix(rowsCount, columnsCount, out double[,] values))
                _engine.Create(index, values);
            else
                Console.WriteLine("Creation aborted");
        }

        bool TryReadMatrix(int rows, int columns, out double[,] values)
        {
            values = new double[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine()?.Split(' ');
                if (row is null || row.Length != columns)
                {
                    Console.WriteLine("Incorrect input");
                    return false;
                }
                for (int j = 0; j < columns; j++)
                    if (!double.TryParse(row[j], out values[i,j]))
                    {
                        Console.WriteLine("Incorrect input");
                        return false;
                    }
            }
            return true;
        }
    }
}