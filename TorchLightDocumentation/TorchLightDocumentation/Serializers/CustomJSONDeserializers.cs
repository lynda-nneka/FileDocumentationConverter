using System;
using System.Text;
using System.Text.Json;

namespace TorchLightDocumentation.Serializers
{
    public class CustomJSONDeserializer
    {
        public static string Deserialize(string filePath)
        {
            var fileString = File.ReadAllText(filePath);
            var deserializedString = JsonSerializer.Deserialize<List<string>>(fileString);

            var builder = new StringBuilder();

            foreach (string newString in deserializedString)
            {
                builder.Append(newString);
                builder.AppendLine();
            }

            return builder.ToString();
        }
    }
}
