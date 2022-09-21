using TracerLibs.Serialize;
using TracerLibs.Tracer;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace TracerLibs.Serialize
{
    public class JsonTracerSerialize : ITracerSerialize
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public string Serialize(TraceResult traceResult)
        {
            var arrays = new Dictionary<string, ICollection<ThreadTrace>>
            {
                {"threads", traceResult.ThreadTraces.Values}
            };
            return JsonSerializer.Serialize(arrays, options);
        }
    }
}