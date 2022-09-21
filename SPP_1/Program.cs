using System.Collections.Concurrent;
using TracerLibs.Tracer;
using Classes;
using TracerLibs.Printers;
using TracerLibs.Serialize;

namespace Program
{
    class Program
    {
        private static void Main(string[] args)
        {
            var program = new Program();
            var thread = new Thread(program.Method);
            ITracer tracer = new Tracer(new TraceResult(new ConcurrentDictionary<int, ThreadTrace>()));

            var foo = new Foo(tracer);
            foo.MyMethod();
            thread.Start(tracer);
            thread.Join();

            ITracerSerialize serializator = new XmlTracerSerialize();
            string result = serializator.Serialize(tracer.GetTraceResult());
            IPrintable filePrinter = new FilePrinter("../../../tracer.xml");
            IPrintable consolePrinter = new ConsolePrinter();

            filePrinter.Print(result);
            consolePrinter.Print(result);

            serializator = new JsonTracerSerialize();
            result = serializator.Serialize(tracer.GetTraceResult());
            filePrinter = new FilePrinter("../../../tracer.json");

            filePrinter.Print(result);
            consolePrinter.Print(result);
            Console.ReadLine();
        }

        public void Method(object o)
        {
            var tracer = (Tracer)o;
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}