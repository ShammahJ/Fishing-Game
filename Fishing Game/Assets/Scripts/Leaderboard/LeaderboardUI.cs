using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardUI : MonoBehaviour
{
    [Header("Panel References")]
    [SerializeField] private GameObject leaderboardPanel;
    [SerializeField] private TMP_Dropdown difficultyDropdown;
    [SerializeField] private Button refreshButton;

    [Header("Display References")]
    [SerializeField] private Transform entriesContainer;
    [SerializeField] private GameObject entryPrefab;

    [Header("Input for New Score")]
    [SerializeField] private GameObject newScorePanel;
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private Button submitScoreButton;

    private int currentDifficulty = 1;

    private void Start()
    {
        if (refreshButton != null)
            refreshButton.onClick.AddListener(RefreshLeaderboard);

        if (difficultyDropdown != null)
            difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);

        if (submitScoreButton != null)
            submitScoreButton.onClick.AddListener(SubmitScore);

        //hides leaderboard initially
        if (leaderboardPanel != null)
            leaderboardPanel.SetActive(false);

        if (newScorePanel != null)
            newScorePanel.SetActive(false);
    }

    public void ShowLeaderboard()
    {
        if (leaderboardPanel != null)
        {
            leaderboardPanel.SetActive(true);
            RefreshLeaderboard();
        }
    }

    public void ShowNewScoreEntry(float finalScore, int difficulty)
    {
        currentDifficulty = difficulty;

        if (newScorePanel != null)
        {
            newScorePanel.SetActive(true);
            if (finalScoreText != null)
                finalScoreText.text = $"Final Score: {finalScore:F0}";

            if (playerNameInput != null)
                playerNameInput.text = "";
        }
    }

    private void SubmitScore()
    {
        string playerName = "Anonymous";
        if (playerNameInput != null && !string.IsNullOrWhiteSpace(playerNameInput.text))
        {
            playerName = playerNameInput.text;
        }

        float finalScore = GameManager.instance != null ? GameManager.instance.money : 0;

        if (LeaderboardManager.Instance != null)
        {
            LeaderboardManager.Instance.AddScore(playerName, finalScore, currentDifficulty);
        }

        if (newScorePanel != null)
            newScorePanel.SetActive(false);

        ShowLeaderboard();
    }

    private void RefreshLeaderboard()
    {
        if (LeaderboardManager.Instance == null) return;

        //get current difficulty from dropdown
        if (difficultyDropdown != null)
            currentDifficulty = difficultyDropdown.value;

        //clear existing entries
        foreach (Transform child in entriesContainer)
        {
            Destroy(child.gameObject);
        }

        //get leaderboard entries
        List<LeaderboardEntry> entries = LeaderboardManager.Instance.GetLeaderboard(currentDifficulty);

        //create entries
        for (int i = 0; i < entries.Count; i++)
        {
            LeaderboardEntry entry = entries[i];
            GameObject entryObj = Instantiate(entryPrefab, entriesContainer);

            //setup entry display
            TextMeshProUGUI[] texts = entryObj.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = $"#{i + 1}";
            texts[1].text = entry.playerName;
            texts[2].text = $"{entry.score:F0}";
        }
    }

    private void OnDifficultyChanged(int value)
    {
        currentDifficulty = value;
        RefreshLeaderboard();
    }

    private void OnDestroy()
    {
        if (refreshButton != null)
            refreshButton.onClick.RemoveListener(RefreshLeaderboard);
        if (difficultyDropdown != null)
            difficultyDropdown.onValueChanged.RemoveListener(OnDifficultyChanged);
        if (submitScoreButton != null)
            submitScoreButton.onClick.RemoveListener(SubmitScore);
    }
}