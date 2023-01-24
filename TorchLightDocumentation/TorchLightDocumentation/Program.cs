
using TorchLightDocumentation.Serializers;

static class Program
{
    public static void Main(string[] args)
    {
        List<object> docs = Documentation.GetDocs();

        // To save the docs as a text file

        TextSerializer.Serialize(docs, "lynn_documentation.txt");

        // To save the docs as a json

        CustomJSONSerializer.Serialize(docs, "lynn_documentation_new.json");

        // Deserialization

        var textDocument = TextDeserializer.Deserialize("lynn_documentation.txt");

        Console.WriteLine("This is the Text Document");
        Console.WriteLine(textDocument);

        var jsonDocument = CustomJSONDeserializer.Deserialize("lynn_documentation_new.json");
        Console.WriteLine("This is the JSON Document");
        Console.WriteLine(jsonDocument);

        Console.ReadKey();

    }
}
