using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : Tower
{
    private void Awake()
    {
        data = GameManager.Resource.Load<TowerData>("Data/CannonTowerData");
    }
}
