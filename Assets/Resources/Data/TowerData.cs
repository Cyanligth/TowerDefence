using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "TowerData", menuName = "Data/Tower")]

public class TowerData : ScriptableObject // ISerializationCallbackReceiver
{
    [SerializeField] TowerInfo[] towers;
    public TowerInfo[] Towers { get { return towers; } }

    [Serializable]
    public class TowerInfo
    {
        int molu;
    }
    public Tower lv1Tower;

    public int damage;
    public float range;
    public float delay;
    public float buildTime;
    public int buildCost;
    public int sellCost;
}
