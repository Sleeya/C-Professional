using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        Type classType = Type.GetType("HarvestingFields");
        FieldInfo[] fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder builder = new StringBuilder();
        string command;
        while ((command = Console.ReadLine()) != "HARVEST")
        {
            switch (command)
            {
                case "private":
                    foreach (var fieldInfo in fields.Where(x => x.IsPrivate))
                    {
                        builder.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                    break;
                case "protected":
                    foreach (var fieldInfo in fields.Where(x => x.IsFamily))
                    {
                        builder.AppendLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                    break;
                case "public":
                    foreach (var fieldInfo in fields.Where(x => x.IsPublic))
                    {
                        builder.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                    }
                    break;
                case "all":
                    foreach (var fieldInfo in fields)
                    {
                        if (fieldInfo.IsFamily)
                        {
                            builder.AppendLine($"protected {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                        }
                        else
                        {
                            builder.AppendLine($"{fieldInfo.Attributes.ToString().ToLower()} {fieldInfo.FieldType.Name} {fieldInfo.Name}");
                        }
                    }
                    break;
            }
        }

        Console.WriteLine(builder.ToString().Trim());
    }
}

