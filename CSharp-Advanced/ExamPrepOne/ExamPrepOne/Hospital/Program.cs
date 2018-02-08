using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string[][]> dict = new Dictionary<string, string[][]>();
            Dictionary<string, List<string>> doctorsPatients = new Dictionary<string, List<string>>();
            string[] input = new string[4];
            while ((input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray())[0] != "Output")
            {
                var department = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];

                if (!dict.ContainsKey(department))
                {
                    dict.Add(department, new string[20][]);

                    for (int i = 0; i < 20; i++)
                    {
                        dict[department][i] = new string[3];
                    }
                }


                bool hospitalized = Hospitalize(dict, patient, department);

                if (hospitalized)
                {
                    if (!doctorsPatients.ContainsKey(doctor))
                    {
                        doctorsPatients.Add(doctor, new List<string>());
                    }
                    doctorsPatients[doctor].Add(patient);
                }

            }

            while ((input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray())[0] != "End")
            {

                if (dict.ContainsKey(input[0]))
                {
                    var department = input[0];
                    if (input.Length == 2)
                    {
                        var roomNumber = int.Parse(input[1]) -1;
                        if (dict[department][roomNumber].Any(x=>x!= null))
                        {
                            Console.WriteLine(string.Join("\r\n", dict[department][roomNumber].OrderBy(x => x).Where(x=>x != null)));
                        }
                        
                    }
                    else
                    {
                        foreach (var room in dict[department])
                        {
                            if (room.Any(x=>x != null))
                            {
                                Console.WriteLine(string.Join("\r\n", room.Where(x=>x!=null)));
                            }
                            
                        }
                    }
                }
                else
                {
                    var doctor = input[0] + " " + input[1];
                   
                    Console.WriteLine(string.Join("\r\n",doctorsPatients[doctor].OrderBy(x=>x).Where(x=>x!= null)));
                   
                }



            }



        }

        private static bool Hospitalize(Dictionary<string, string[][]> dict, string patient, string department)
        {

            foreach (var room in dict[department])
            {
                for (int j = 0; j < 3; j++)
                {
                    if (room[j] == null)
                    {
                        room[j] = patient;
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
