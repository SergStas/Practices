using System.Linq;

namespace pract_27_06_20_0
{
    public class cd : ICommand
    {
        public void Perform(Environment sender, string args)
        {
            Directory target = sender.Current.Children.FirstOrDefault(x => x.Name == args) as Directory;
            if (target is null)
                sender.Out("No such directory");
            else
                sender.ChangeCurrent(target);
        }
    }
}