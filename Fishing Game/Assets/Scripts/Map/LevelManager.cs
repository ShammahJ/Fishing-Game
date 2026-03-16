using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public void SceneChange()
    {
        SceneManager.LoadScene(sceneName);
    }
}
