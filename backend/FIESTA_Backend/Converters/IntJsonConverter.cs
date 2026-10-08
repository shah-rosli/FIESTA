using Newtonsoft.Json;
using System.Text.Json;

namespace FIESTA_Backend.Converters
{
    public class IntJsonConverter : JsonConverter<int>
    {
        public override int ReadJson(JsonReader reader, Type objectType, int existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var value = reader.Value?.ToString()?.ToLower();

            if (value == "false")
            {
                return 0;
            }
            else if (value == "true")
            {
                return 1;
            }
            else
            {
                return int.Parse(value);
            }
        }

        public override void WriteJson(JsonWriter writer, int value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
    }
}
