using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusTester : MonoBehaviour
{
    public GameObject testcube;
    private Vector3 target;
    void Start()
    {
        target = gameObject.transform.position + Random.insideUnitSphere * 2;
        Vector3 xzTarget = new Vector3(target.x, gameObject.transform.position.y, target.z);
        Instantiate(testcube, target, gameObject.transform.rotation);
    }

    void Update()
    {
        
    }
}
