using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DashAPI.Helpers
{
    public class TimeSpanJsonConverter : JsonConverter
    {
        public TimeSpanJsonConverter()
        {
            Format = "s";
        }

        public TimeSpanJsonConverter(string format)
            : this()
        {
            Format = format;
        }

        /// <summary>
        /// tks = TotalDays
        /// ms  = TotalMilliseconds
        /// s   = TotalSeconds
        /// m   = TotalMinutes
        /// h   = TotalHours
        /// d   = TotalDays
        /// </summary>
        public string Format { get; set; }

        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(TimeSpan))
                return true;
            //if (objectType == typeof(string))
            //    return true;
            //if (objectType == typeof(int))
            //    return true;
            //if (objectType == typeof(double))
            //    return true;
            //if (objectType == typeof(decimal))
            //    return true;
            //if (objectType == typeof(float))
            //    return true;
            //if (objectType == typeof(long))
            //    return true;
            //if (objectType == typeof(short))
            //    return true;
            return false;
        }

        public override bool CanRead => true;

        public override bool CanWrite => true;


        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            object newValue = value;
            if (value is TimeSpan)
            {
                var timeSpan = (TimeSpan)value;
                switch (Format)
                {
                    case "tks":
                        newValue = timeSpan.Ticks;
                        break;
                    case "ms":
                        newValue = timeSpan.TotalMilliseconds;
                        break;
                    case "s":
                        newValue = timeSpan.TotalSeconds;
                        break;
                    case "m":
                        newValue = timeSpan.TotalMinutes;
                        break;
                    case "h":
                        newValue = timeSpan.TotalHours;
                        break;
                    case "d":
                        newValue = timeSpan.TotalDays;
                        break;
                }
            }
            else
            {
                
            }

            writer.WriteValue(newValue);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            double val;
            if (double.TryParse(reader.Value?.ToString(), out val))
            {
                TimeSpan timeSpan;
                switch (Format)
                {
                    case "tks":
                        timeSpan = TimeSpan.FromTicks((long) val);
                        break;
                    case "ms":
                        timeSpan = TimeSpan.FromMilliseconds(val);
                        break;
                    case "s":
                        timeSpan = TimeSpan.FromSeconds(val);
                        break;
                    case "m":
                        timeSpan = TimeSpan.FromMinutes(val);
                        break;
                    case "h":
                        timeSpan = TimeSpan.FromHours(val);
                        break;
                    case "d":
                        timeSpan = TimeSpan.FromDays(val);
                        break;
                    default:
                        return existingValue;
                }
                return timeSpan;
            }
            return existingValue;
        }
    }
}
