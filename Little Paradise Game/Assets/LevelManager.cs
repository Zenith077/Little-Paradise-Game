using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Color fadeColor;

    public float fadeInTime;
    public float fadeOutTime;

    Scene currentScene;

    public int testScene;

    LoadingScreen loadingScreen;

    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadNewScene(0, 2));
        }
    }



    void Awake()
    {
        //A basic singleton implementation:
        if (instance == null) //Is the instance null? if it is, no scenemanager has been created
        {
            instance = this; //Hence, we assign the instance to this object.
        }

        else if (instance != this) //If the instance is not this, that means the instance was filled by another object.
        {
            Destroy(gameObject); //That means we have two SceneManagers, and so we destroy the duplicate.
        }

        //And we also grab a reference to the loadingScreen
        loadingScreen = FindObjectOfType<LoadingScreen>();
    }

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    public IEnumerator LoadNewScene(int currentSceneIndex, int newSceneIndex)
    {
        loadingScreen.FadeLoadScreen(fadeColor, fadeInTime);
        yield return new WaitForSeconds(fadeInTime);
        scenesLoading.Add(SceneManager.LoadSceneAsync(newSceneIndex, LoadSceneMode.Additive));

        while (!scenesLoading[0].isDone)
        {
            yield return null;
        }

        scenesLoading.Add(SceneManager.UnloadSceneAsync(currentSceneIndex));

        StartCoroutine(GetSceneProgress());
    }

    public IEnumerator GetSceneProgress()
    {
        //If a scene is still loading
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        //Once it is finished
        loadingScreen.FadeLoadScreen(new Color(0, 0, 0, 0), fadeOutTime);
        scenesLoading.Clear();

    }


}
