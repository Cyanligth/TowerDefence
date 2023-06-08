using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BuildInGameUI buildUI = GameManager.UI.OpenInGameUI<BuildInGameUI>("UI/BuildInGameUI");
        buildUI.SetTarget(transform);
        buildUI.SetOffset(new Vector2(0,100));
        buildUI.towerPlace = this;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }

    public void BuildTower(TowerData tower)
    {
        GameManager.Resource.Destroy(gameObject);
        GameManager.Resource.Instantiate(tower.lv1Tower, transform.position, transform.rotation);
    }
}
