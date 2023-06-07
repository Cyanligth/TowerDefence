using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private EventSystem eventSystem;
    private Canvas popUpCanvas;
    private Stack<PopUpUI> popUpStack;

    private void Awake()
    {
        eventSystem = GameManager.Resource.Instantiate<EventSystem>("UI/EventSystem");
        eventSystem.transform.SetParent(transform);

        popUpCanvas = GameManager.Resource.Instantiate<Canvas>("UI/Canvas");
        popUpCanvas.gameObject.name = "PopUpCanvas";
        popUpCanvas.sortingOrder = 100;

        popUpStack = new Stack<PopUpUI>();
    }

    public PopUpUI ShowPopUpUI<T>(T popUpUI) where T : PopUpUI
    {
        if(popUpStack.Count > 0)
        {
            PopUpUI prevUI = popUpStack.Peek();
            prevUI.gameObject.SetActive(false);
        }
        PopUpUI ui = GameManager.Pool.GetUI(popUpUI);
        ui.transform.SetParent(popUpCanvas.transform, false);
        popUpStack.Push(ui);
        Time.timeScale = 0;
        return ui;
    }
    public PopUpUI ShowPopUpUI<T>(string path) where T : PopUpUI
    {
        T ui = GameManager.Resource.Load<T>(path);
        return ShowPopUpUI(ui);
    }
    public void ClosePopUpUI()
    {
        if (popUpStack.Count <= 0)
            return;

        PopUpUI ui = popUpStack.Pop();
        GameManager.Pool.Release(ui.gameObject);
        if (popUpStack.Count > 0)
        {
            PopUpUI curUI = popUpStack.Peek();
            curUI.gameObject.SetActive(true);
        }
        if (popUpStack.Count <= 0)
            Time.timeScale = 1;
    }
}
