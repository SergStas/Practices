using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace pract_27_06_20
{
    public class ConsoleWorker
    {
        public Size WindowSize { get; } // беcполезное говно
        private bool[,] _cells;
        private string[] _commands;
        private Entity _entity;
        private const int _delayTime = 100;
        private int _steps;

        public ConsoleWorker(int width, int height)
        {
            WindowSize = new Size(width, height);
            _cells = new bool[height, width];
            UploadCommands();
            Begin();
            OutputStats();
            Console.ReadKey();
        }

        private void Begin()
        {
            Console.Clear();
            _entity = new Entity();
            foreach (string line in _commands)
            {
                Command command = ParseCommand(line);
                Point oldPos = _entity.Position;
                _entity.Perform(command);
                Rewrite(oldPos, _entity.Position, _entity.Writing);
                Thread.Sleep(_delayTime);
            }
            Console.SetCursorPosition(0,0);
            Console.Write("Done");
        }

        private void Rewrite(Point from, Point to, bool fill)
        {
            if (from.Equals(to))
                return;
            _steps++;
            Console.SetCursorPosition(from.X, from.Y);
            _cells[from.Y, from.X] = _cells[from.Y, from.X] || fill;
            Console.Write(_cells[from.Y, from.X] ? 'X' : ' ');
            Console.SetCursorPosition(to.X, to.Y);
            Console.Write('@');
        }

        private void OutputStats()
        {
            int marked = 0;
            foreach (bool b in _cells)
                if (b)
                    marked++;
            string result = $"End position: {_entity.Position.X + "; " + _entity.Position.Y}\nSteps: {_steps}\nMarked: {marked}";
            File.WriteAllText("statistics.txt", result);
        }

        private Command ParseCommand(string line)
        {
            Command result;
            if (Enum.TryParse(line, true, out Direction dir))
                result = new Move(dir);
            else if (line == "TailUp" || line == "TailDown")
                result = new Switch(line[4] == 'U');
            else
                throw new Exception();
            return result;
        }

        private void UploadCommands()
        {
            Console.Write("Path: ");
            _commands = File.ReadAllLines(Console.ReadLine());
        }

        private class Entity : IPerformer
        {
            public Point Position { get; private set; } = new Point(0, 0);
            public bool Writing { get; private set; }

            private void SwitchWriting(bool newValue) =>
                Writing = newValue;

            private void Move(Direction dir)
            {
                switch (dir)
                {
                    case Direction.Down:
                        Position = new Point(Position.X, Position.Y + 1);
                        break;
                    case Direction.Right:
                        Position = new Point(Position.X + 1, Position.Y);
                        break;
                    case Direction.Up:
                        Position = new Point(Position.X, Position.Y - 1);
                        break;
                    case Direction.Left:
                        Position = new Point(Position.X - 1, Position.Y);
                        break;
                }
            }

            public void Perform(Command command)
            {
                if (command is Switch)
                    SwitchWriting(((Switch)command).Raise);
                else if (command is Move)
                    Move(((Move)command).Direction);
            }
        }
    }
}