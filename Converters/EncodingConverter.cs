using System.IO;
using System.Text;

namespace MultiTools.Converters
{
    public class EncodingConverter
    {
        public void ConvertEncoding(string filePath, Encoding targetEncoding)
        {
            string content = File.ReadAllText(filePath);
            File.WriteAllText(filePath, content, targetEncoding);
        }
    }
}
