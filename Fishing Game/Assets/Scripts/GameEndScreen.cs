using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreen : MonoBehaviour
{
    private void Start()
    {
        GameManager.instance.AddLeaderboardEntry();
    }
    public void ResetGame()
    {
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(0);
    }
}
