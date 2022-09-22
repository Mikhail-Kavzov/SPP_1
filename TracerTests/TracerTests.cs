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
    }
}