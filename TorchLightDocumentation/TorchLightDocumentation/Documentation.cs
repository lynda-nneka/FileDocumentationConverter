using System;
using TorchLightDocumentation;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Linq;


public class Documentation
{
    public static List<object> GetDocs()
    {
        var assembly = Assembly.GetExecutingAssembly();

        List<object> documentObjects = new List<object>();

        foreach (Type type in assembly.GetTypes())
        {
            var attributes = type.GetCustomAttributes(typeof(DocumentAttribute), true);
            if (attributes.Length > 0)
            {
                documentObjects.Add("Class: " + type.Name);
                documentObjects.Add("\tDescription: " + ((DocumentAttribute)attributes[0]).Description);

            }

            foreach (ConstructorInfo constructor in type.GetConstructors())
            {
                var constructorAttributes = constructor.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (constructorAttributes.Length > 0)
                {
                    documentObjects.Add("Constructor: " + constructor.Name);
                    documentObjects.Add("\tDescription: " + ((DocumentAttribute)constructorAttributes[0]).Description);
                    documentObjects.Add("\tInput: " + ((DocumentAttribute)constructorAttributes[0]).Input);
                }
            }

            foreach (MethodInfo method in type.GetMethods())
            {
                var methodAttributes = method.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (methodAttributes.Length > 0)
                {
                    documentObjects.Add("Method: " + method.Name);
                    documentObjects.Add("\tDescription: " + ((DocumentAttribute)methodAttributes[0]).Description);
                    documentObjects.Add("\tInput: " + ((DocumentAttribute)methodAttributes[0]).Input);
                    documentObjects.Add("\tOutput: " + ((DocumentAttribute)methodAttributes[0]).Output);
                    
                }
            }

            foreach (PropertyInfo property in type.GetProperties())
            {
                var propertyAttributes = property.GetCustomAttributes(typeof(DocumentAttribute), true);
                if (propertyAttributes.Length > 0)
                {
                    documentObjects.Add("Property: " + property.Name);
                    documentObjects.Add("\tDescription: " + ((DocumentAttribute)propertyAttributes[0]).Description);
                    documentObjects.Add("\tOutput: " + ((DocumentAttribute)propertyAttributes[0]).Output);
                    
                }
            }


            if (type.IsEnum)
            {
                documentObjects.Add("Enum: " + type.Name);
                documentObjects.Add("\tDescription: " + ((DocumentAttribute?)attributes.SingleOrDefault(a => a.GetType() == typeof(DocumentAttribute)))?.Description);

                string[] names = type.GetEnumNames();
                foreach (string name in names)
                {
                    documentObjects.Add(name);

                }
                
            }
        }

        return documentObjects;
    }

    
}
