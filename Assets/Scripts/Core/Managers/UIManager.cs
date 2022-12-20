using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    TextUIController textUIs;
    InfoPanelController infoPanels;

    public InfoPanelController InfoPanels => infoPanels;

    protected override void Initialize()
    {
        textUIs = FindObjectOfType<TextUIController>();
        infoPanels = FindObjectOfType<InfoPanelController>();
    }

    public void PopupText(string text)
    {
        textUIs.PopupText.ShowText(text, 50);
    }
}
