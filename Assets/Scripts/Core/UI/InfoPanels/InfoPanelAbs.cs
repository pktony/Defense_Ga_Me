using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InfoPanelAbs : MonoBehaviour
{
    private CanvasGroup group;

    protected virtual void Awake()
    {
        group = GetComponent<CanvasGroup>();
    }

    public void ShowPanel()
    {
        group.alpha = 1f;
        group.interactable = true;
        group.blocksRaycasts = true;
    }

    public void HidePanel()
    {
        group.alpha = 0f;
        group.interactable = false;
        group.blocksRaycasts = false;
    }
}
