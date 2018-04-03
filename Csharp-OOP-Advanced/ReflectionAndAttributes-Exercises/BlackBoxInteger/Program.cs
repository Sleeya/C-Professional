using System;
using System.Reflection;

public class Program
{
    static void Main(string[] args)
    {
        Type classType = Type.GetType("BlackBoxInteger");
        ConstructorInfo[] cons = Type.GetType(classType.Name).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
        Object classObject = cons[0].Invoke(new object[] { 0 });
        FieldInfo field = classType.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var splitCommand = command.Split("_");
            var commandType = splitCommand[0];
            var number = int.Parse(splitCommand[1]);
            switch (commandType)
            {
                case "Add":
                    var addMethod = classType.GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance);
                    addMethod.Invoke(classObject, new object[] { number });
                    break;
                case "Subtract":
                    var subtractMethod = classType.GetMethod("Subtract", BindingFlags.NonPublic | BindingFlags.Instance);
                    subtractMethod.Invoke(classObject, new object[] { number });
                    break;
                case "Multiply":
                    var multiplyMethod = classType.GetMethod("Multiply", BindingFlags.NonPublic | BindingFlags.Instance);
                    multiplyMethod.Invoke(classObject, new object[] { number });
                    break;
                case "Divide":
                    var divideMethod = classType.GetMethod("Divide", BindingFlags.NonPublic | BindingFlags.Instance);
                    divideMethod.Invoke(classObject, new object[] { number });
                    break;
                case "LeftShift":
                    var leftShiftMethod = classType.GetMethod("LeftShift", BindingFlags.NonPublic | BindingFlags.Instance);
                    leftShiftMethod.Invoke(classObject, new object[] { number });
                    break;
                case "RightShift":
                    var rightShiftMethod = classType.GetMethod("RightShift", BindingFlags.NonPublic | BindingFlags.Instance);
                    rightShiftMethod.Invoke(classObject, new object[] { number });
                    break;

            }
            Console.WriteLine(field.GetValue(classObject));
        }
    }
}

