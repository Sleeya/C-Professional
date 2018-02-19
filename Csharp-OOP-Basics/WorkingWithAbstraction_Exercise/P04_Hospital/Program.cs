using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    public static void Main()
    {
        Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
        Dictionary<string, List<List<string>>> departments = new Dictionary<string, List<List<string>>>();

        string command;
        while ((command = Console.ReadLine()) != "Output")
        {
            HospitalizePatient(doctors, departments, command);
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            PrintCommand(doctors, departments, input);
        }
    }

    private static void PrintCommand(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string input)
    {
        string[] args = input.Split();

        if (args.Length == 1)
        {
            Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
        }
        else if (args.Length == 2 && int.TryParse(args[1], out int staq))
        {
            Console.WriteLine(string.Join("\n", departments[args[0]][staq - 1].OrderBy(x => x)));
        }
        else
        {
            Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
        }
    }

    private static void HospitalizePatient(Dictionary<string, List<string>> doctors, Dictionary<string, List<List<string>>> departments, string command)
    {
        string[] tokens = command.Split();
        var departament = tokens[0];
        var firstName = tokens[1];
        var lastName = tokens[2];
        var patient = tokens[3];
        var fullName = firstName + lastName;

        if (!doctors.ContainsKey(firstName + lastName))
        {
            doctors[fullName] = new List<string>();
        }
        if (!departments.ContainsKey(departament))
        {
            departments[departament] = new List<List<string>>();
            for (int stai = 0; stai < 20; stai++)
            {
                departments[departament].Add(new List<string>());
            }
        }

        bool notFull = departments[departament].SelectMany(x => x).Count() < 60;
        if (notFull)
        {
            int room = 0;
            doctors[fullName].Add(patient);
            for (int st = 0; st < departments[departament].Count; st++)
            {
                if (departments[departament][st].Count < 3)
                {
                    room = st;
                    break;
                }
            }
            departments[departament][room].Add(patient);
        }
    }
}
