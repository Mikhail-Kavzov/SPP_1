using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace TracerLibs.Tracer
{
    public class MethodData
    {
        [XmlAttribute("name"), JsonPropertyName("name")]
        public string? MethodName { get; set; }

        [XmlAttribute("class"), JsonPropertyName("class")]
        public string? ClassName { get; set; }

        private long time;

        [XmlAttribute("time"), JsonPropertyName("time")]
        public long Time
        {
            get
            {
                if (time == 0)
                    throw new ArgumentException("Cannot measure time. Call StartTrace method before StopTrace");
                return time;
            }
            set => time = value;
        }

        [XmlElement("methods"), JsonPropertyName("methods")]
        public List<MethodData>? NestedMethods { get; set; }

        [JsonIgnore]
        private readonly Stopwatch _stopwatch = new();

        public MethodData(string methodName, string className)
        {
            MethodName = methodName;
            ClassName = className;
            _stopwatch.Start();
        }
        public MethodData() { }

        public void SetNested(List<MethodData> nestedMethods)
        {
            NestedMethods = nestedMethods;
        }

        public void CalculateTime()
        {
            _stopwatch.Stop();
            Time = _stopwatch.ElapsedMilliseconds;
        }
    }
}