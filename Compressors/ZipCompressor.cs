using System.IO;
using System.IO.Compression;

namespace MultiTools.Compressors
{
    public class ZipCompressor
    {
        public void Compress(string path)
        {
            string zipPath = path + ".zip";
            if (Directory.Exists(path))
            {
                ZipFile.CreateFromDirectory(path, zipPath);
            }
            else if (File.Exists(path))
            {
                using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
                {
                    archive.CreateEntryFromFile(path, Path.GetFileName(path));
                }
            }
        }
    }
}
