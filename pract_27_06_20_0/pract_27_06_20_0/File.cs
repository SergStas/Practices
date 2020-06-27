namespace pract_27_06_20_0
{
    public class File : FileNode
    {
        public string Content { get; private set; }

        public void Write(string content) => 
            Content = content;

        public File(Directory parent, string name) : base(parent, name) { }
    }
}