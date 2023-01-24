using System;
namespace TorchLightDocumentation.Serializers
{
    public class TextDeserializer
    {
        public static string Deserialize(string filePath)
        {
            var fileString = File.ReadAllText(filePath);
            return fileString;
        }
    }
}