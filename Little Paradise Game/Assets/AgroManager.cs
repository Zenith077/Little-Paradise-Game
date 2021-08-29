using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    public Dictionary<GameObject, float> enemyDistances;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Hostile");
        player = GameObject.FindGameObjectWithTag("Hostile");
    }
    void Update()
    {
        foreach(GameObject enemy in enemies)
        {

        }
    }
}
