using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuickInitialization : MonoBehaviour
{
    List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    LevelManager levelManager;

    // Start is called before the first frame update
    void Awake()
    {
        scenesLoading.Add(SceneManager.LoadSceneAsync("Persistant Elements", LoadSceneMode.Additive));
        scenesLoading.Add(SceneManager.LoadSceneAsync("HUD", LoadSceneMode.Additive));
        scenesLoading.Add(SceneManager.LoadSceneAsync("Player", LoadSceneMode.Additive));

        StartCoroutine(GetSceneProgress());
    }

    IEnumerator GetSceneProgress()
    {
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        for (int i = 0; i < scenesLoading.Count; i++)
        {
            while (!scenesLoading[i].isDone)
            {
                yield return null;
            }
        }
        SceneManager.UnloadSceneAsync(1);
    }



}
