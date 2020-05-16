using System;
using System.Collections.Generic;
using System.Linq;

namespace _16_05_20_pract
{
    public class Calculator
    {
        List<Variable> vars;
        readonly Action<string> output;
        List<MathOperation> commands;

        public Calculator(Action<string> output)
        {
            vars = new List<Variable>();
            this.output = output;
            FillCommandsList();
        }

        public void Clear() =>
            vars = new List<Variable>();
        
        public void ProcessCase(string input)
        {
            vars = new List<Variable>();
            string[] rows = input.Split('\n');
            foreach (string row in rows)
                ProcessString(row);
            output("---------------------------");
            OutputResult();
            output("===========================\n");
        }

        //да, код убогий, пока не вижу, как его более компактно переписать:
        public void ProcessString(string command)
        {
            string[] parts = command.Split(' ').Select(x => x.Replace("\r","")).ToArray();
            double value;
            Variable variable;
            if (parts[0] == "var")
            {
                value = parts.Length == 4 ? GetValue(parts[^1]) : 0;
                variable = CreateVar(parts[1], value);
            }
            else
            {
                value = GetValue(parts[2]);
                variable = vars.FirstOrDefault(x => x.Name == parts[1]);
            }
            if (variable is null)
                output($"\t>>Variable \"{parts[1]}\" was not found:");
            else if (!commands.Select(x => x.Name).Contains(parts[0]))
                output($"\t>>Command \"{parts[0]}\" was not found:");
            else 
                commands.FirstOrDefault(x => x.Name == parts[0])?.Act(variable, value);
            output(command);
        }

        public void OutputResult() =>
            output(string.Join('\n', vars));
        
        void FillCommandsList() => 
            commands = new List<MathOperation>
            {
                new MathOperation("var", (v, d) => vars.Add(v)),
                new MathOperation("mov", (v, d) => v.Value = d),
                new MathOperation("add", (v, d) => v.Value += d),
                new MathOperation("sub", (v, d) => v.Value -= d),
                new MathOperation("mul", (v, d) => v.Value *= d),
                new MathOperation("div", (v, d) =>
                {
                    if (Math.Abs(d) < 1e-7)
                        output("\t>>Division by zero detected:");
                    else
                        v.Value /= d;
                })
            };

        Variable CreateVar(string name, double value) =>
            new Variable(name, value, vars.Count);

        double GetValue(string token) => 
            vars.Select(x => x.Name).Contains(token)
                ? vars.FirstOrDefault(x => x.Name == token).Value
                : double.Parse(token);
    }
}