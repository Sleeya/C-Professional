using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;


public class Song
{
    private string artistName;
    private string songName;
    private DateTime songLength;

    public Song(string artistName,string songName, DateTime songLength)
    {
        ArtistName = artistName;
        SongName = songName;
        SongLength = songLength;
    }

    public string ArtistName
    {
        get => this.artistName;
        set =>artistName = value;
    }

    public string SongName
    {
        get => this.songName;
        set=> songName = value;
       
    }

    public DateTime SongLength
    {
        get => this.songLength;
        set=> songLength = value;
    }
}


