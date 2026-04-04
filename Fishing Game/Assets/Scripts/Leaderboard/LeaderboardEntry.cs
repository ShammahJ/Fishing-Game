using System;

[Serializable]
public class LeaderboardEntry
{
    public string playerName;
    public float score;

    public LeaderboardEntry(string playerName, float score)
    {
        this.playerName = playerName;
        this.score = score;
    }
}