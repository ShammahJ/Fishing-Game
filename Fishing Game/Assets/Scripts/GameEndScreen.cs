using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndScreen : MonoBehaviour
{
    public void ResetGame()
    {
        GameManager.instance.ResetGame();
        SceneManager.LoadScene(0);
    }
}
