using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }
}
