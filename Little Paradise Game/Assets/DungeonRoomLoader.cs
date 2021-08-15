using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using System.IO;

public class DungeonRoomLoader : MonoBehaviour
{
    public AssetReference scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadRoom(int zone)
    {

        //Subscribe OnSceneLoadComple to the Action "Completed", passing along the arg containing the status of scene.
        scene.LoadSceneAsync().Completed += OnSceneLoadComplete;

    }

    //Responsible for tracking the completion status.
    void OnSceneLoadComplete(AsyncOperationHandle<UnityEngine.ResourceManagement.ResourceProviders.SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {

            Debug.Log("Succesfully loaded scene.");
        }

        else
        {
            Debug.LogWarning("ERROR: Could not load scene.");
        }
    }



}
