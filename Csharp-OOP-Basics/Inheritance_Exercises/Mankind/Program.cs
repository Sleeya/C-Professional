using System;


class Program
{
    static void Main(string[] args)
    {
        try
        {
            var studentInfo = Console.ReadLine().Split();
            Student currentStudent = new Student
            (
                firstName: studentInfo[0],
                lastName: studentInfo[1],
                facultyNumber: studentInfo[2]
            );

            var workerInfo = Console.ReadLine().Split();
            Worker currentWorker = new Worker
            (firstName: workerInfo[0],
                lastName: workerInfo[1],
                weekSalary: double.Parse(workerInfo[2]),
                workHoursPerDay: double.Parse(workerInfo[3])
            );

            Console.WriteLine(currentStudent);
            Console.WriteLine();
            Console.WriteLine(currentWorker);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
