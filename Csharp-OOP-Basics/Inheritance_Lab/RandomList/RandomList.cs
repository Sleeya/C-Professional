using System;
using System.Collections.Generic;

public class RandomList:List<string>
{
    private List<string> words = new List<string>();

    public string RandomString()
    {
        Random random = new Random();

        return words[random.Next(0, words.Count)];
    }
}
