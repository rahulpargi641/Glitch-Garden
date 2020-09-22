using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int currentBuildIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentBuildIndex == 0)
        {
            StartCoroutine(LoadStartScene());

        }
    }

    IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(3f);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);

    }
}
