using TracerLibs.Tracer;

namespace TracerTests
{
    [TestClass]
    public class TracerTests
    {
        private ITracer tracer = null!;

        [TestInitialize]
        public void Init()
        {
            tracer = new Tracer(new TraceResult());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStarAndStopSequence()
        {
            tracer.StopTrace();
            tracer.StartTrace();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestManyStarts()
        {
            tracer.StartTrace();
            tracer.StartTrace();
            tracer.StopTrace();
        }

        [TestMethod]
        public void TestTracerNormalWork()
        {
            tracer.StartTrace();
            Method(tracer);
            tracer.StopTrace();
            var result = tracer.GetTraceResult();
            Assert.IsNotNull(result.ThreadTraces.Keys);
        }

        public void Method(ITracer tracer)
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }
    }
}