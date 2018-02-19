using System;

namespace P03_StudentSystem
{
    class StartUp
    {
        static void Main()
        {
            StudentSystem studentSystem = new StudentSystem();

            string args;
            while ((args = Console.ReadLine())!="Exit")
            {
                studentSystem.ParseCommand(args);
            }
        }
    }
}
