using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InfoPanelAbs : MonoBehaviour
{
    UI_Fade fadeUI;

    protected virtual void Awake()
    {
        fadeUI = GetComponent<UI_Fade>();
    }

    public void ShowPanel()
    {
        fadeUI.ShowImage(0.2f);
    }

    public void HidePanel()
    {
        fadeUI.HideImage(0.2f);
    }
}
