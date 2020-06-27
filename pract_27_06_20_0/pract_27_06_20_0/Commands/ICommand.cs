namespace pract_27_06_20_0
{
    public interface ICommand
    {
        void Perform(Environment sender, string args);
        // touch,
        // ls,
        // cat,
        // rm,
        // write,
        // mv
    }
}