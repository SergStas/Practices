using System;
using System.Drawing;

namespace pract_28_06_20
{
    public class Snake : IDrawable
    {
        public Segment Head { get; }
        public Segment Tail { get; private set; }
        public int Length { get; private set; }
        public Direction Direction { get; private set; }
        public Point PreviousPos { get; private set; }

        public Snake(Point startPos)
        {
            Head = new Segment(startPos.X, startPos.Y, true);
            Tail = Head;
            Length = 1;
        }

        public void Draw()
        {
            Segment current = Head;
            do
            {
                current.Draw();
                current = current.Next;
            } while (current != null);
        }

        public void Move()
        {
            Point previous = Head.Position;
            Segment current = Head;
            current.Shift(Direction);
            while (current.Next != null)
            {
                current = current.Next;
                Point temp = current.Position;
                current.Position = previous;
                previous = temp;
            }
            PreviousPos = previous;
        }

        public void Grow()
        {
            Segment newSegment = new Segment(PreviousPos.X, PreviousPos.Y);
            Tail.Next = newSegment;
            Tail = newSegment;
            Length++;
        }

        public void Turn(Direction dir)
        {
            if (((int) dir + (int) Direction) % 2 == 1)
                Direction = dir;
        }
    }
}