namespace _16_05_20_pract
{
    public class Variable
    {
        public string Name { get; }
        public double Value { get; set; }
        public int Index { get; }

        public Variable(string name, double value, int index)
        {
            Name = name;
            Value = value;
            Index = index;
        }
        
        public override string ToString()
        {
            return $"Var#{Index}: {Name} = {Value}";
        }
    }
}