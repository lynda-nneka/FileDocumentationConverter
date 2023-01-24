using System;
using System.Text.Json;

namespace TorchLightDocumentation.Serializers
{
    public class CustomJSONSerializer
    {
        public static void Serialize(List<object> data, string filePath)
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(data, options);

            File.WriteAllText(filePath, json);
        }
    }
}
