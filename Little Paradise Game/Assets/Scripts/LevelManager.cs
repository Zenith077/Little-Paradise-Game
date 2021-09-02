using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelManager : MonoBehaviour
{
    public Color fadeColor;

    public float fadeInTime;
    public float fadeOutTime;

    Scene currentScene;

    public int testScene;

    LoadingScreen loadingScreen;

    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();

    public static Action OnLoadNewSceneBegin;

    public static Action OnLoadNewSceneFinished;
    // Start is called before the first frame update

    void Awake()
    {
        // grab a reference to the loadingScreen
        loadingScreen = FindObjectOfType<LoadingScreen>();
    }

    public void LoadNewScene(int currentSceneIndex, int newSceneIndex)
    {
        StartCoroutine(LoadNewSceneRoutine(currentSceneIndex, newSceneIndex));
    }

    public void LoadNewScene(string currentSceneName, string newSceneName)
    {
        StartCoroutine(LoadNewSceneRoutine(currentSceneName, newSceneName));
    }


    IEnumerator LoadNewSceneRoutine(int currentSceneIndex, int newSceneIndex)
    {
        if (OnLoadNewSceneBegin != null)
        {
            OnLoadNewSceneBegin.Invoke();
        }
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
    //An overload taking the scene name as an argument instead of scene index.
    IEnumerator LoadNewSceneRoutine(string currentSceneName, string newSceneName)
    {
        loadingScreen.FadeLoadScreen(fadeColor, fadeInTime);
        yield return new WaitForSeconds(fadeInTime);
        scenesLoading.Add(SceneManager.LoadSceneAsync(newSceneName, LoadSceneMode.Additive));

        while (!scenesLoading[0].isDone)
        {
            yield return null;
        }

        scenesLoading.Add(SceneManager.UnloadSceneAsync(currentSceneName));

        StartCoroutine(GetSceneProgress());
    }

    IEnumerator GetSceneProgress()
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
        if (OnLoadNewSceneFinished != null)
        {
            OnLoadNewSceneFinished.Invoke();
        }
        loadingScreen.FadeLoadScreen(new Color(0, 0, 0, 0), fadeOutTime);
        scenesLoading.Clear();
    }


}
