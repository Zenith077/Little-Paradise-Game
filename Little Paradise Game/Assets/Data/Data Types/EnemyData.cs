using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataUtils;


[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Data/EnemyData")]
public class EnemyData : ScriptableObject 
{
    public new string name;
    public string description;
    public bool neutral;

    [Header("Health")]
    public float maxHealth;
    public float currentHealth;

    [Header("Stats")]
    public SerializableDictionary<string, float> baseStats;
    public SerializableDictionary<string, float> activeStats;

    [Header("Battle")]
    public List<Move> moveList;
    public SerializableDictionary<DataUtils.behaviourType, BattleBehaviour> battleBehaviour;
    public List<Status> activeStatuses;
}
