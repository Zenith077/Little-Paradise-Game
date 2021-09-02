using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public LevelManager levelManager;

    void Awake()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
    }
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {

    }
}
