using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataUtils
{
    public enum statType { PAT, PATRES, MAT, MATRES, MVSPD, DODGE, CRIT };
    public enum behaviourType { Idle, Alert, Range, CloseCombat, Critical };
    public static class EnemyUtils
    {
        public static void AddDefaultStatParams(SerializableDictionary<string, float> dictionary)
        {
            foreach (statType e in (statType[]) Enum.GetValues(typeof(statType)))
            {
                string name = e.ToString();
                if (!dictionary.ContainsKey(name)) dictionary.Add(name, 0);
            }
        }

        public static void AddDefaultBattleBehaviour(SerializableDictionary<behaviourType, BattleBehaviour> dictionary)
        {
            foreach (behaviourType e in (behaviourType[])Enum.GetValues(typeof(behaviourType)))
            {
                //string name = e.ToString();
                if (!dictionary.ContainsKey(e)) dictionary.Add(e, null);
            }
        }

        public static void SetStatsAtoB(SerializableDictionary<string, float> dictionaryFrom, SerializableDictionary<string, float> dictionaryTo)
        {
            
            foreach (KeyValuePair<string, float> entry in dictionaryFrom)
            {
                if (dictionaryTo.ContainsKey(entry.Key))
                {
                    Debug.Log ("contains key");
                    dictionaryFrom.TryGetValue(entry.Key, out float valueFrom);
                    dictionaryTo.TryGetValue(entry.Key, out float valueTo);

                    if (valueFrom != valueTo)
                        {
                        Debug.Log("different values");
                        float val = entry.Value;
                        dictionaryTo[entry.Key] = val;

                        }
                    
                }
            }
        }
        public static void RemoveEntry(SerializableDictionary<string, float> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary.Remove(key);Debug.Log("ran");
            }
            
        }

        public static void ClearStatDictionary(SerializableDictionary<string, float> dictionary)
        {
            dictionary.Clear();

        }

        public static void UpdateEntry(SerializableDictionary<string, float> dictionary, string key, float value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }

        }
    }
    }
