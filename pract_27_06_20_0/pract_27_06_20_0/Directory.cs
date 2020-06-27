using System.Collections.Generic;
using System.Linq;

namespace pract_27_06_20_0
{
    public class Directory : FileNode
    {
        public List<FileNode> Children { get; } = new List<FileNode>();

        public object this[string name]
        {
            get => Children.FirstOrDefault(x => x.Name == name);
        }

        public void AddChildren(FileNode node) =>
            Children.Add(node);

        public string GetPath() =>
            $"{(Parent is null ? "" : Parent.GetPath() + "/")}{Name}";

        public Directory(Directory parent, string name) : base(parent, name) { }
    }
}