using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;

namespace pract_30_05_20
{
    public class Screen : IScreen
    {
        public Size Size { get; }

        private int MiddlePos => (Size.Height - 2) / 2;
        
        private Dictionary<int, Command> _startTime = new Dictionary<int, Command>();
        private Dictionary<int, Command> _endTime = new Dictionary<int, Command>();
        private Dictionary<Command, Point> _positions = new Dictionary<Command, Point>();
        private Timer _timer;
        private int _counter;

        public Screen(int width, int height)
        {
            Size = new Size(width, height);
            DrawScreen();
            SetTimer();
        }

        public void LoadCommands(IEnumerable<Command> commands)
        {
            foreach (Command command in commands)
                RegisterCommand(command);
        }

        public void RegisterCommand(ICommand iCommand)
        {
            Command command = (Command) iCommand;
            CommandEventArgs args = GetCommandEventArgs(command);
            _startTime[args.BeginningTime] = command;
            _endTime[args.EndingTime] = command;
        }

        public void Begin() =>
            _timer.Start();

        private void DrawScreen()
        {
            for (int i = 0; i < Size.Width; i++)
                Console.Write('#');
            for (int i = 0; i < Size.Height - 2; i++)
                Console.Write("\n#" + new string(' ', Size.Width - 2) + "#");
            Console.WriteLine();
            for (int i=0; i< Size.Width;i++)
                Console.Write('#');
        }

        private void SetTimer()
        {
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Elapsed += (sender, args) =>
            {
                _counter++;
                if (_startTime.ContainsKey(_counter))
                    Output(_startTime[_counter]);
                if (_endTime.ContainsKey(_counter))
                    Dispose(_endTime[_counter]);
            };
        }

        private void Output(Command command)
        {
            CommandEventArgs args = GetCommandEventArgs(command);
            Console.ForegroundColor = args.Color ?? ConsoleColor.White;
            Point position = GetPosition(args);
            _positions[command] = position;
            Console.SetCursorPosition(position.X, position.Y);
            Console.Write(args.Content);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private void Dispose(Command command)
        {
            Console.SetCursorPosition(_positions[command].X, _positions[command].Y);
            CommandEventArgs args = GetCommandEventArgs(command);
            for (int i = 0; i < args.Content.Length; i++)
                Console.Write(' ');
        }

        private Point GetPosition(CommandEventArgs args)
        {
            int x, y;
            switch (args.Position)
            {
                case Position.Right:
                    y = MiddlePos;
                    x = Size.Width - 2 - args.Content.Length;
                    break;
                case Position.Left:
                    y = MiddlePos;
                    x = 1;
                    break;
                case Position.Top:
                    y = 1;
                    x = (Size.Width - 2 - args.Content.Length) / 2;
                    break;
                default:
                    y = Size.Height - 2;
                    x = (Size.Width - 2 - args.Content.Length) / 2;
                    break;
            }
            return new Point(x, y);
        }
        
        private CommandEventArgs GetCommandEventArgs(Command command) =>
            (CommandEventArgs) command.Args;
    }
}