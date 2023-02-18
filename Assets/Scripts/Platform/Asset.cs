using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Asset", menuName = "Asset")]
public class Asset : ScriptableObject
{
    public List<trap> traps= new List<trap>();
    public GameObject force;
}
[Serializable]
public class trap
{
    public string Name;
    public GameObject AssetPerfab;
}
