using System;
using System.Drawing;
using System.Timers;
using System.Windows;

namespace pract_28_06_20
{
    public class ConsoleWorker
    {
        public Size WindowSize { get; }
        private Snake _snake;
        private const int Interval = 500;
        private int i = 0;

        public ConsoleWorker(int width, int height)
        {
            WindowSize = new Size(width,height);
            _snake = new Snake(new Point(1,1));
        }
        
        public void Run()
        {
            while (true)
                Tick();
        }

        private void Tick()
        {
            i++;
            Console.Clear();
            DrawBorders();
            _snake.Draw();
            if (TryProcessKey(Console.ReadKey(), out Direction dir))
                _snake.Turn(dir);
            _snake.Move();
            if (i % 2 == 0)
                _snake.Grow();
        }

        private void DrawBorders()
        {
            Console.SetCursorPosition(0,0);
            for (int i = 0; i < WindowSize.Width; i++)
                Console.Write("@");
            Console.WriteLine();
            for (int i = 1; i < WindowSize.Height - 1; i++)
            {
                Console.Write("@");
                Console.SetCursorPosition(WindowSize.Width -1, i);
                Console.WriteLine("@");
            }
            for (int i = 0; i < WindowSize.Width; i++)
                Console.Write("@");
        }

        private bool TryProcessKey(ConsoleKeyInfo key, out Direction dir)
        {
            dir = Direction.Down;
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    dir = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    dir = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    dir = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    dir = Direction.Right;
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}