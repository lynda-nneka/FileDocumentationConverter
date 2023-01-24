using System;
using System.Text;

namespace TorchLightDocumentation.Serializers
{
    public class TextSerializer
    {
        public static void Serialize(List<object> data, string filepath)
        {
            var builder = new StringBuilder();

            foreach (object stringData in data)
            {
                builder.Append(stringData);
                builder.AppendLine();
            }

            File.WriteAllText(filepath, builder.ToString());
        }
    }
}

