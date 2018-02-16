using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;


class Program
{
    static void Main(string[] args)
    {
        var accounts = new Dictionary<int, BankAccount>();
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var currentCommand = command.Split();

            switch (currentCommand[0])
            {
                case "Create":
                    Create(currentCommand, accounts);
                    break;
                case "Deposit":
                    Deposit(currentCommand, accounts);
                    break;
                case "Withdraw":
                    Withdraw(currentCommand, accounts);
                    break;
                case "Print":
                    Print(currentCommand, accounts);
                    break;
            }
        }
    }

    private static void Print(string[] currentCommand, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(currentCommand[1]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            Console.WriteLine(accounts[id]);
        }

    }

    private static void Withdraw(string[] currentCommand, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(currentCommand[1]);
        decimal amount = decimal.Parse(currentCommand[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else if (accounts[id].Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            accounts[id].Balance -= amount;
        }
    }

    private static void Deposit(string[] currentCommand, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(currentCommand[1]);
        decimal amount = decimal.Parse(currentCommand[2]);
        if (!accounts.ContainsKey(id))
        {
            Console.WriteLine("Account does not exist");
        }
        else
        {
            accounts[id].Balance += amount;
        }
    }

    private static void Create(string[] command, Dictionary<int, BankAccount> accounts)
    {
        int id = int.Parse(command[1]);

        if (accounts.ContainsKey(id))
        {
            Console.WriteLine("Account already exists");
        }
        else
        {
            var acc = new BankAccount();
            acc.Id = id;
            accounts.Add(id, acc);
        }
    }
}

