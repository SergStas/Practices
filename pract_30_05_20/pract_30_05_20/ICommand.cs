using System;

namespace pract_30_05_20
{
    public interface ICommand
    {
        public void Execute(IScreen screen);
        public EventArgs Args { get; }
    }
}