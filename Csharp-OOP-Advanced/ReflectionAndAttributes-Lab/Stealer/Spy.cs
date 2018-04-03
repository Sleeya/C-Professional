using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string nameToInvestigate, params string[] fieldsToInvestigate)
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Class under investigation: {nameToInvestigate}");

        Type classType = Type.GetType(nameToInvestigate);
        FieldInfo[] classFields =
            classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                BindingFlags.NonPublic);

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        foreach (FieldInfo field in classFields.Where(x => fieldsToInvestigate.Contains(x.Name)))
        {
            builder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }


        return builder.ToString().Trim();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder builder = new StringBuilder();

        Type classType = Type.GetType(className);

        FieldInfo[] classPublicFields =
            classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        foreach (var classField in classPublicFields)
        {
            builder.AppendLine($"{classField.Name} must be private!");
        }

        foreach (var classMethod in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
        {
            builder.AppendLine($"{classMethod.Name} have to be public!");
        }

        foreach (var classMethod in classPublicMethods.Where(x => x.Name.StartsWith("set")))
        {
            builder.AppendLine($"{classMethod.Name} have to be private!");
        }

        return builder.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder builder = new StringBuilder();

        Type classType = Type.GetType(className);

        MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        builder.AppendLine($"All Private Methods of Class: {classType.Name}");
        builder.AppendLine($"Base Class: {classType.BaseType.Name}");
        foreach (var nonPublicMethod in nonPublicMethods)
        {
            builder.AppendLine($"{nonPublicMethod.Name}");
        }
        return builder.ToString().Trim();
    }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        StringBuilder builder = new StringBuilder();

        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] classMethods =
            classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic |
                                 BindingFlags.Public);

        foreach (var method in classMethods.Where(x=>x.Name.StartsWith("get")))
        {
            builder.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
        }

        foreach (var method in classMethods.Where(x=>x.Name.StartsWith("set")))
        {
            builder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return builder.ToString().Trim();
    }
}
