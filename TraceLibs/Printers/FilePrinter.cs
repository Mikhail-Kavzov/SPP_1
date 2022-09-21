using System.Text;

namespace TracerLibs.Printers
{
    public class FilePrinter : IPrintable
    {
        private readonly string _fileName;

        public FilePrinter(string pathFile)
        {
            _fileName = pathFile;
        }

        public void Print(string data)
        {
            using FileStream fStream = new(_fileName, FileMode.Create);
            var bytes = Encoding.Default.GetBytes(data);
            fStream.Write(bytes, 0, bytes.Length);
        }
    }
}
