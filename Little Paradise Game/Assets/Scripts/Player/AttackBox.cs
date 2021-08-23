using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    public List<IDamageable> damagebleEntities = new List<IDamageable>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IDamageable>() != null)
        {
            damagebleEntities.Add(other.GetComponent<IDamageable>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        damagebleEntities.Remove(other.GetComponent<IDamageable>());
    }
}