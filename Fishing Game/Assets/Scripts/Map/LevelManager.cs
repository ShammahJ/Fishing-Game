using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string sceneName;
    public string biome = "Clear";
    public void SceneChange()
    {
        GameManager.instance.biome = biome;
        SceneManager.LoadScene(sceneName);
    }
}
