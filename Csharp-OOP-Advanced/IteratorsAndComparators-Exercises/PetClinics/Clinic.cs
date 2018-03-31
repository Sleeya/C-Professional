using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    private Pet[] rooms;
    private int numberOfRooms;
    private string name;
    private int[] AddOrder;
    private int addIndex;

    public Clinic(string name, int numberOfRooms)
    {
        this.Name = name;
        this.NumberOfRooms = numberOfRooms;
        this.rooms = new Pet[this.NumberOfRooms];

        this.AddOrder = new int[this.NumberOfRooms];

        AssignAddOrder();
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int NumberOfRooms
    {
        get => this.numberOfRooms;
        private set
        {
            if (value % 2 == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            this.numberOfRooms = value;
        }
    }

    public bool Add(Pet pet)
    {
        if (rooms.Any(x => x == null))
        {
            this.rooms[AddOrder[addIndex]] = pet;
            addIndex++;
            return true;
        }
        return false;
    }

    private void AssignAddOrder()
    {
        int startIndex = this.NumberOfRooms / 2;

        for (int i = 0; i < this.NumberOfRooms; i++)
        {
            if (i % 2 != 0)
            {
                startIndex -= i;
            }
            else
            {
                startIndex += i;
            }

            AddOrder[i] = startIndex;
        }
    }

    public bool Release()
    {
        if (this.rooms.Any(x => x != null))
        {
            for (int i = this.NumberOfRooms / 2; i < this.rooms.Length + this.NumberOfRooms / 2; i++)
            {
                if (rooms[i % rooms.Length] != null)
                {
                    rooms[i % rooms.Length] = null;
                    return true;
                }
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return rooms.Any(x => x == null);
    }

    public string Print()
    {
        StringBuilder builder = new StringBuilder();
        foreach (var room in this.rooms)
        {
            if (room == null)
            {
                builder.AppendLine("Room empty");
            }
            else
            {
                builder.AppendLine($"{room.Name} {room.Age} {room.Kind}");
            }
        }

        return builder.ToString().Trim();
    }

    public string Print(int roomNumber)
    {
        if (rooms[roomNumber - 1] == null)
        {
            return "Room empty";
        }
        return $"{rooms[roomNumber - 1].Name} {rooms[roomNumber - 1].Age} {rooms[roomNumber - 1].Kind}";
    }
}
