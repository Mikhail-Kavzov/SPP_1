using TracerLibs.Tracer;

namespace TracerLibs.Serialize
{
    public interface ITracerSerialize
    {
        string Serialize(TraceResult traceResult);
    }
}
