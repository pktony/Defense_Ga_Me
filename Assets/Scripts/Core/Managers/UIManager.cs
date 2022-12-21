using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    TextUIController textUIs;
    ButtonController buttonController;
    InfoPanelController infoPanels;

    public InfoPanelController InfoPanels => infoPanels;

    protected override void Initialize()
    {
        textUIs = FindObjectOfType<TextUIController>();
        buttonController = textUIs.GetComponent<ButtonController>();
        infoPanels = FindObjectOfType<InfoPanelController>();
    }

    public void PopupText(string text, Color color)
    {
        textUIs.PopupText.ShowText(text, 50, color);
    }

    public void DisableButtons(bool isExchangable, bool isSellable)
    {
        buttonController.DisableButtons(isExchangable, isSellable);
    }

}
