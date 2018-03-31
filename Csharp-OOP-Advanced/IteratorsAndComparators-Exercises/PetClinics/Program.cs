using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Pet> pets = new List<Pet>();
        List<Clinic> clinics = new List<Clinic>();

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            var input = Console.ReadLine().Split();
            var command = input[0];
            var output = string.Empty;
            try
            {
                switch (command)
                {
                    case "Create":
                        var createType = input[1];
                        switch (createType)
                        {
                            case "Pet":
                                pets.Add(new Pet(input[2], int.Parse(input[3]), input[4]));
                                break;
                            case "Clinic":
                                clinics.Add(new Clinic(input[2], int.Parse(input[3])));
                                break;
                        }
                        break;
                    case "Add":
                        var petName = input[1];
                        var clinicName = input[2];
                        output = clinics.Find(x => x.Name == clinicName).Add(pets.Find(x => x.Name == petName)).ToString();
                        break;
                    case "Release":
                        var releaseClinicName = input[1];
                        output = clinics.Find(x => x.Name == releaseClinicName).Release().ToString();
                        break;
                    case "HasEmptyRooms":
                        var checkClinic = input[1];
                        output = clinics.Find(x => x.Name == checkClinic).HasEmptyRooms().ToString();
                        break;
                    case "Print":
                        var printClinic = clinics.Find(x => x.Name == input[1]);
                        if (input.Length == 2)
                        {
                            output = printClinic.Print();
                        }
                        else
                        {
                            output = printClinic.Print(int.Parse(input[2]));
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }

            if (output!= string.Empty)
            {
                Console.WriteLine(output);
            }
        }
    }
}
