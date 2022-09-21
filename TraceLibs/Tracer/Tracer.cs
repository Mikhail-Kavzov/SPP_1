using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerLibs.Tracer
{
    public class Tracer : ITracer
    {
        private readonly TraceResult traceResult;

        public Tracer(TraceResult _traceResult)
        {
            traceResult = _traceResult;
        }

        public void StartTrace()
        {
            var threadTrace = traceResult.GetThreadTrace(Environment.CurrentManagedThreadId);
            GetMethodInformation(out string className, out string methodName);
            threadTrace.Push(methodName, className);
        }

        private static void GetMethodInformation(out string className, out string methodName)
        {
            var stackTrace = new StackTrace();
            var method = stackTrace.GetFrame(2)!.GetMethod();
            methodName = method!.Name;
            className = method.ReflectedType!.Name;
        }

        public void StopTrace()
        {
            var threadTrace = traceResult.GetThreadTrace(Environment.CurrentManagedThreadId);
            GetMethodInformation(out string className, out string methodName);
            threadTrace.Pop(methodName, className);
        }

        public TraceResult GetTraceResult() => traceResult;
    }
}
