using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    public TowerPlace towerPlace;

    protected override void Awake()
    {
        base.Awake();

        buttons["Blocker"].onClick.AddListener(() => { GameManager.UI.CloseInGameUI(this); });
        buttons["ArchorButton"].onClick.AddListener(() => { BuildArchorTower(); });
        buttons["BombButton"].onClick.AddListener(() => { BuildCannonTower(); });
    }

    public void BuildArchorTower()
    {
        TowerData data = GameManager.Resource.Load<TowerData>("Data/ArchorTowerData");
        towerPlace.BuildTower(data);
        GameManager.UI.CloseInGameUI(this);
    }
    public void BuildCannonTower()
    {
        TowerData data = GameManager.Resource.Load<TowerData>("Data/CannonTowerData");
        towerPlace.BuildTower(data);
        GameManager.UI.CloseInGameUI(this);
    }
}
