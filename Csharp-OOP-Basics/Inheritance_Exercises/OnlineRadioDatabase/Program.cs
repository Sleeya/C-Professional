using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        int numberOfSongs = int.Parse(Console.ReadLine());
        List<Song> songs = new List<Song>();
        for (int i = 0; i < numberOfSongs; i++)
        {
            string[] song = Console.ReadLine().Split(";").ToArray();

            if (ValidateInput(song))
            {
                DateTime songLength = DateTime.ParseExact(song[2], "m:s", CultureInfo.InvariantCulture);
                Song currentSong = new Song(song[0], song[1], songLength);
                songs.Add(currentSong);
                Console.WriteLine("Song added.");
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");
        DateTime sumOfLengths = new DateTime();
        foreach (var song in songs)
        {

            sumOfLengths = sumOfLengths.AddSeconds(song.SongLength.Second);
            sumOfLengths = sumOfLengths.AddMinutes(song.SongLength.Minute);

        }
        Console.WriteLine($"Playlist length: {sumOfLengths.Hour}h {sumOfLengths.Minute}m {sumOfLengths.Second}s");
    }

    public static bool ValidateInput(string[] song)
    {
        string artistName = song[0];
        string songName = song[1];
        string[] splitSongLength = song[2].Split(":");

        if (string.IsNullOrEmpty(artistName) || artistName.Trim().Length < 3 || artistName.Trim().Length > 20)
        {
            Console.WriteLine("Artist name should be between 3 and 20 symbols.");
            return false;
        }
        if (string.IsNullOrEmpty(songName) || songName.Trim().Length < 3 || songName.Trim().Length > 30)
        {
            Console.WriteLine("Song name should be between 3 and 30 symbols.");
            return false;
        }

        int minutes;
        int seconds;
        if (splitSongLength.Length != 2 || !int.TryParse((splitSongLength[0]), out minutes) || !int.TryParse((splitSongLength[1]), out seconds))
        {
            Console.WriteLine("Invalid song length.");
            return false;
        }
        if (int.Parse(splitSongLength[0]) > 14)
        {
            Console.WriteLine("Song minutes should be between 0 and 14.");
            return false;
        }

        if (int.Parse(splitSongLength[1]) > 59)
        {
            Console.WriteLine("Song seconds should be between 0 and 59.");
            return false;
        }
        

        return true;
    }
}

