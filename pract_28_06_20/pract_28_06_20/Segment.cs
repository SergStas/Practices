using System;
using System.Drawing;

namespace pract_28_06_20
{
    public class Segment : IDrawable
    {
        public Point Position { get; set; }
        public Segment Next { get; set; }
        public bool IsHead { get; }

        public Segment(int x, int y) =>
            Position = new Point(x, y);

        public Segment(int x, int y, bool isHead) : this(x, y) =>
            IsHead = isHead;
        
        public void Draw()
        {
            Console.SetCursorPosition(Position.X,Position.Y);
            Console.Write(IsHead ? 'O' : 'X');
        }

        public void Connect(Segment tail) =>
            Next = tail;

        public void Shift(Direction dir)
        {
            switch (dir)
            {
                case Direction.Down:
                    Position = new Point(Position.X, Position.Y + 1);
                    break;
                case Direction.Up:
                    Position = new Point(Position.X, Position.Y - 1);
                    break;
                case Direction.Left:
                    Position = new Point(Position.X - 1, Position.Y);
                    break;
                case Direction.Right:
                    Position = new Point(Position.X + 1, Position.Y);
                    break;
            }
        }
    }
}