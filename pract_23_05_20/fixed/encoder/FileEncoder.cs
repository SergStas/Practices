using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace encoder
{
    public class FileEncoder
    {
        public void EncodeToFile(string filePath) 
        {
            byte[] content = File.ReadAllBytes(filePath);
            string encoded = Base64Encode(content);
            string[] parts = filePath.Split('\\');
            string name = parts[parts.Length - 1].Replace(".", "_") + ".txt";
            string resultPath = string.Join("\\", parts.Take(parts.Length - 1)) + "\\" + name;
            File.WriteAllText(resultPath, encoded);
        }

        public void DecodeFromFile(string filePath)
        {
            string content = File.ReadAllText(filePath);
            byte[] decoded = Base64Decode(content);
            File.WriteAllBytes(GetDecodedFilePath(filePath), decoded);
        }

        public void EncodeToBuffer(string filePath)
        {
            byte[] content = File.ReadAllBytes(filePath);
            string encoded = Base64Encode(content);
            Clipboard.SetText(encoded);
        }

        public void DecodeFromBuffer(string filePath)
        {
            string content = Clipboard.GetText();
            byte[] decoded = Base64Decode(content);
            File.WriteAllBytes(filePath, decoded);
        }

        string Base64Encode(byte[] bytes) =>
            Convert.ToBase64String(bytes);

        byte[] Base64Decode(string base64EncodedData) =>
            Convert.FromBase64String(base64EncodedData);

        string GetDecodedFilePath(string filePath)
        {
            string path = string.Join(".", filePath.Split('.').Take(filePath.Split('.').Length - 1));
            string[] parts = path.Split('_');
            return string.Join("_", parts.Take(parts.Length - 1)) + "0." + parts[parts.Length - 1];
        }
    }
}
