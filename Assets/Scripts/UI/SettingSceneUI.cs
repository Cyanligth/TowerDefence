using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingSceneUI : SceneUI
{
    Button configButton;
    Button soundButton;
    Button infoButton;

    protected override void Awake()
    {
        base.Awake();

        buttons["ConfigButton"].onClick.AddListener(() => { OpenPausePopUpUI(); });
        buttons["SoundButton"].onClick.AddListener(() => { Debug.Log("Sound"); });
        buttons["InfoButton"].onClick.AddListener(() => { Debug.Log("Info"); });
    }

    public void OpenPausePopUpUI()
    {
        GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SettingPopUpUI");
    }
}
