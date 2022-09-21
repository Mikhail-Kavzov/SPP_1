using TracerLibs.Tracer;

namespace Classes
{
    public class Foo
    {
        private readonly Bar _bar;
        private readonly ITracer _tracer;

        public Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();
            _bar.InnerMethod();
            _tracer.StopTrace();
        }
    }
}
