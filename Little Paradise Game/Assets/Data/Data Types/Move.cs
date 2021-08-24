using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Data/Move")]
public class Move : ScriptableObject
{
    public new string name;
    public string description;
    public float phDmg;
    public float matDmg;
    public float cooldown;
    public float hitboxDistance;

    [Tooltip("1.0 is 100% of inflicting status, 0.0 is 0 chance")]
    public SerializableDictionary<Status, float> InflictedStatusChance;
}
