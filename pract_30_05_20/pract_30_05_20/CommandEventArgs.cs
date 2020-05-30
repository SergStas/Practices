using System;
using System.Drawing;

namespace pract_30_05_20
{
    public class CommandEventArgs : EventArgs
    {
        public Position Position { get; }
        public ConsoleColor? Color { get; }
        public string Content { get; }
        public int BeginningTime { get; }
        public int EndingTime { get; }

        public CommandEventArgs(string content, ConsoleColor color, Position pos, int start, int end)
        {
            Content = content;
            Color = color;
            Position = pos;
            BeginningTime = start;
            EndingTime = end;
        }
    }
}