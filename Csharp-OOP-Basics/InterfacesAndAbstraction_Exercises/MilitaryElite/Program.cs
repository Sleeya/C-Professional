using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Soldier> dudes = new List<Soldier>();

        InsertDudes(dudes);

        PrintDudes(dudes);
    }

    private static void PrintDudes(List<Soldier> dudes)
    {
        foreach (var soldier in dudes)
        {
            Console.WriteLine(soldier);
        }
    }

    private static void InsertDudes(List<Soldier> dudes)
    {
        var command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            try
            {
                var info = command.Split();
                var type = info[0];
                switch (type)
                {
                    case "Private":
                        AddCurrentPrivate(dudes, info);
                        break;
                    case "LeutenantGeneral":
                        AddCurrentLeutenantGeneral(dudes, info);
                        break;
                    case "Engineer":
                        AddCurrentEngineer(dudes, info);
                        break;
                    case "Commando":
                        AddCurrentCommando(dudes, info);
                        break;
                    case "Spy":
                        AddCurrentSpy(dudes, info);
                        break;

                }
            }
            catch (ArgumentException e)
            {

            }
        }
    }

    private static void AddCurrentSpy(List<Soldier> dudes, string[] info)
    {
        Spy currentSpy = new Spy(info[1], info[2], info[3], int.Parse(info[4]));
        dudes.Add(currentSpy);
    }

    private static void AddCurrentCommando(List<Soldier> dudes, string[] info)
    {
        List<string> missions = new List<string>();
        for (int i = 6; i < info.Length; i += 2)
        {
            if (info[i + 1] != "inProgress" && info[i + 1] != "Finished")
            {
                continue;
            }
            string mission = $"Code Name: {info[i]} State: {info[i + 1]}";
            missions.Add(mission);
        }
        Commando currentCommando = new Commando(info[1], info[2], info[3], double.Parse(info[4]), info[5], missions);
        dudes.Add(currentCommando);
    }

    private static void AddCurrentEngineer(List<Soldier> dudes, string[] info)
    {
        List<string> repairs = new List<string>();
        for (int i = 6; i < info.Length; i += 2)
        {
            string repair = $"Part Name: {info[i]} Hours Worked: {info[i + 1]}";
            repairs.Add(repair);
        }
        Engineer currentEngineer = new Engineer(info[1], info[2], info[3], double.Parse(info[4]), info[5], repairs);
        dudes.Add(currentEngineer);
    }

    private static void AddCurrentLeutenantGeneral(List<Soldier> dudes, string[] info)
    {
        LeutenantGeneral currentLeutenantGeneral = new LeutenantGeneral(info[1], info[2], info[3], double.Parse(info[4]));

        for (int i = 5; i < info.Length; i++)
        {
            string currentPrivateId = info[i];

            currentLeutenantGeneral.AddPrivates(dudes.Find(x => x.Id == currentPrivateId) as Private);
        }
        dudes.Add(currentLeutenantGeneral);
    }

    private static void AddCurrentPrivate(List<Soldier> dudes, string[] info)
    {
        Private currentPrivate = new Private(info[1], info[2], info[3], double.Parse(info[4]));
        dudes.Add(currentPrivate);
    }
}

