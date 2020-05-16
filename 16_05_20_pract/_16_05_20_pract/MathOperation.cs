using System;

namespace _16_05_20_pract
{
    public class MathOperation
    {
        public string Name { get; }
        private Action<Variable, double> act;

        public MathOperation(string name, Action<Variable, double> action)
        {
            Name = name;
            act = action;
        }

        public void Act(Variable v, double d) =>
            act(v, d);
    }
}