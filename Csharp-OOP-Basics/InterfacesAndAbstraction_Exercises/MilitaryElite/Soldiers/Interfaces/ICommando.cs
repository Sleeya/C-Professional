using System.Collections.Generic;

public interface ICommando
{
    List<string> Missions { get; set; }

    void CompleteMission();
}
