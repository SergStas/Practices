namespace pract_27_06_20_0
{
    public class mkdir : ICommand
    {
        public void Perform(Environment sender, string args) =>
            sender.Current.AddChildren(new Directory(sender.Current, args));
    }
}