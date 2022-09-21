using System.Xml;
using System.Xml.Serialization;
using TracerLibs.Serialize;
using TracerLibs.Tracer;

namespace TracerLibs.Serialize
{
    public class XmlTracerSerialize : ITracerSerialize
    {
        public string Serialize(TraceResult traceResult)
        {
            var data = traceResult.ThreadTraces.Values.ToArray();
            var xmlSerializer = new XmlSerializer(data.GetType());
            string result = "";
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = new XmlTextWriter(stringWriter))
                {
                    xmlWriter.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xmlWriter, data);
                }
                result = stringWriter.ToString();
            }
            return result;
        }
    }
}


