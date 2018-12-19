using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateStatDataClass
{
    [MenuItem("Assets/FSM/StatData")]
    public static StatData CreateStatData()
    {
        StatData asset = ScriptableObject.CreateInstance<StatData>();
        AssetDatabase.CreateAsset(asset, "Assets/Script/Data/StatData.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}

public class StatData : ScriptableObject
{
    public float maxHP = 100.0f;
    public float baseRange = 50.0f;
}
