namespace TracerLibs.Printers
{
    public class ConsolePrinter : IPrintable
    {
        public void Print(string data) => Console.WriteLine(data);
    }
}
