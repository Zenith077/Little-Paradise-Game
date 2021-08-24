using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Status", menuName = "Data/Status")]
public class Status : ScriptableObject
{
    public new string name;
    public string description;

    [Header("Effect on Stats")]
    public SerializableDictionary<string, float> statEffect;
}
