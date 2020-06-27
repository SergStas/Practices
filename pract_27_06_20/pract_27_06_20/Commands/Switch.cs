namespace pract_27_06_20
{
    public class Switch : Command
    {
        public bool Raise { get; }

        public Switch(bool b) =>
            Raise = b;
    }
}