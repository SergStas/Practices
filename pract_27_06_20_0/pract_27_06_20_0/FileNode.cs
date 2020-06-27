using System.Collections.Generic;

namespace pract_27_06_20_0
{
    public abstract class FileNode
    {
        public Directory Parent { get; set; }
        public string Name { get; protected set; }

        public FileNode(Directory parent, string name)
        {
            Parent = parent;
            Name = name;
        }

        public void Rename(string newName) =>
            Name = newName;
    }
}