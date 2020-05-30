using System;

namespace pract_30_05_20
{
    public class Command : ICommand
    {
        public EventArgs Args { get; }

        public Command(CommandEventArgs args) =>
            Args = args;
        
        public void Execute(IScreen screen) =>
            screen.RegisterCommand(this);
    }
}