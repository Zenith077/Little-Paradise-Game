using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    PlayerMover player;
    // Start is called before the first frame update

    void Awake()
    {

    }
    void Start()
    {
        player = FindObjectOfType<PlayerMover>();
        player.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));
    }
}
