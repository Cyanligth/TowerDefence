using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerPlace : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("asdfasdf");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        renderer.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        renderer.material.color = normal;
    }
}
