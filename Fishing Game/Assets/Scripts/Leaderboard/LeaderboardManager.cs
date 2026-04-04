using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance { get; private set; }

    [Header("Leaderboard Settings")]
    [SerializeField] private int maxEntriesPerDifficulty = 10;

    private List<LeaderboardEntry> easyScores = new List<LeaderboardEntry>();
    private List<LeaderboardEntry> normalScores = new List<LeaderboardEntry>();
    private List<LeaderboardEntry> hardScores = new List<LeaderboardEntry>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(string playerName, float score, int difficulty)
    {
        LeaderboardEntry newEntry = new LeaderboardEntry(playerName, score);

        switch (difficulty)
        {
            case 0:
                AddScoreToList(easyScores, newEntry);
                break;
            case 1:
                AddScoreToList(normalScores, newEntry);
                break;
            case 2:
                AddScoreToList(hardScores, newEntry);
                break;
            default:
                Debug.Log("fart");
                break;
        }
    }

    private void AddScoreToList(List<LeaderboardEntry> list, LeaderboardEntry newEntry)
    {
        list.Add(newEntry);

        list = list.OrderByDescending(entry => entry.score).ToList();

        if (list.Count > maxEntriesPerDifficulty)
        {
            list.RemoveRange(maxEntriesPerDifficulty, list.Count - maxEntriesPerDifficulty);
        }
    }

    public List<LeaderboardEntry> GetLeaderboard(int difficulty)
    {
        switch (difficulty)
        {
            case 0:
                return new List<LeaderboardEntry>(easyScores);
            case 1:
                return new List<LeaderboardEntry>(normalScores);
            case 2:
                return new List<LeaderboardEntry>(hardScores);
            default:
                return new List<LeaderboardEntry>();
        }
    }

    public bool IsHighScore(float score, int difficulty)
    {
        List<LeaderboardEntry> list = GetLeaderboard(difficulty);

        if (list.Count < maxEntriesPerDifficulty)
            return true;

        float lowestScore = list.Last().score;
        return score > lowestScore;
    }
}