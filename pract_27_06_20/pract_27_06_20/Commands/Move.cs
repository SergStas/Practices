namespace pract_27_06_20
{
    public class Move : Command
    {
        public Direction Direction { get; }

        public Move(Direction dir) =>
            Direction = dir;
    }
}