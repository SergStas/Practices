using System.Windows.Forms;
using System.Text;
using System.IO;
using System;
using System.Linq;
using encoder;

namespace pract_23_05_20
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            FileEncoder encoder = new FileEncoder();
            while (true)
            {
                try
                {
                    string operation = Console.ReadLine();
                    if (operation == "-quit" || operation == "-q")
                        break;
                    string source = Console.ReadLine();
                    if (!(source.Split(' ')[0] == "-s" || source.Split(' ')[0] == "-source") || source.Split(' ').Length != 2)
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }
                    string path = Console.ReadLine();
                    if (!(path.Split(' ')[0] == "-f" || path.Split(' ')[0] == "-file") || path.Split(' ').Length != 2)
                    {
                        Console.WriteLine("Incorrect input"); 
                        continue;
                    }
                    if (operation == "-encode" || operation == "-e")
                    {
                        if (source.Split(' ')[1] == "file")
                            encoder.EncodeToFile(path.Split(' ')[1]);
                        else if (source.Split(' ')[1] == "buffer")
                            encoder.EncodeToBuffer(path.Split(' ')[1]);
                        else
                        {
                            Console.WriteLine("Incorrect input");
                            continue;
                        }
                    }
                    else if (operation == "-decode" || operation == "-d")
                    {
                        if (source.Split(' ')[1] == "file")
                            encoder.DecodeFromFile(path.Split(' ')[1]);
                        else if (source.Split(' ')[1] == "buffer")
                            encoder.DecodeFromBuffer(path.Split(' ')[1]);
                        else
                        {
                            Console.WriteLine("Incorrect input");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }
                    Console.WriteLine("Successfully");
                }
                catch
                {
                    Console.WriteLine("Something wrong");
                }
            }
        }
    }
}
