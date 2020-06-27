namespace pract_27_06_20_0
{
    public class pwd : ICommand
    {
        public void Perform(Environment sender, string args) =>
            sender.Out(sender.Current.GetPath());
    }
}