using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace pract_27_06_20_0
{
    public class Environment
    {
        private Directory _root;
        public Directory Current { get; private set; }
        private Dictionary<string, Action<string>> _actions;

        public Environment()
        {
            _root = new Directory(null, ".");
            Current = _root;
            InitializeDictionary();
        }

        private void InitializeDictionary() =>
            _actions = new Dictionary<string, Action<string>>
            {
                {"pwd", args => new pwd().Perform(this, args)},
                {"cd", args => new cd().Perform(this, args)},
                {"mkdir", args => new mkdir().Perform(this, args)},
            };

        public void Run() =>
            DoWork();

        private void DoWork()
        {
            while (true)
            {
                Console.Write('$');
                ProcessCommand(Console.ReadLine());
            }
        }

        private void ProcessCommand(string s)
        {
            string[] parts = s.Split(' ');
            string args = parts.Length == 1 ? "" : string.Join(" ", parts.Skip(1));
            if (_actions.ContainsKey(parts[0]))
                _actions[parts[0]](args);
            else
                Out("No such command");
        }

        public void Out(string content) =>
            Console.WriteLine(content);

        public void ChangeCurrent(Directory dir) =>
            Current = dir;
    }
}