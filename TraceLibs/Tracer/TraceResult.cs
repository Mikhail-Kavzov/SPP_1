using System;
using System.Collections.Concurrent;

namespace TracerLibs.Tracer
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadTrace> ThreadTraces { get; } = new();

        public ThreadTrace GetThreadTrace(int threadId)
        {
            return ThreadTraces.GetOrAdd(threadId, new ThreadTrace(threadId));
        }
    }
}
