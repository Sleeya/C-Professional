using System;
using System.Collections.Generic;
using System.Text;


public class MoodFactory
{
    public static Mood GetMood(int happiness)
    {
        if (happiness >= 15)
        {
            return new JavaScript(happiness);
        }
        if (happiness >= 1 && happiness < 15)
        {
            return new Happy(happiness);
        }
        if (happiness >= -5 && happiness <= 0)
        {
            return new Sad(happiness);
        }

        return new Angry(happiness);

    }
}
