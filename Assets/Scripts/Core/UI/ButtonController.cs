using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private Button sellButton;
    private Button upgradeButton;
    private Button exchangeButton;

    private void Awake()
    {
        Transform buttonParent = transform.GetChild(3).GetChild(2);
        sellButton = buttonParent.GetChild(1).GetComponent<Button>();
        upgradeButton = buttonParent.GetChild(2).GetComponent<Button>();
        exchangeButton = buttonParent.GetChild(3).GetComponent<Button>();
    }

    private void EnableButtons()
    {
        sellButton.interactable = true;
        //upgradeButton.interactable = true;
        exchangeButton.interactable = true;
    }

    public void DisableButtons(bool isExchangable, bool isSellable)
    {
        EnableButtons();
        if(!isExchangable && !isSellable)
        {
            sellButton.interactable = false;
            exchangeButton.interactable = false;
        }
        else if(isSellable && !isExchangable)
        {
            exchangeButton.interactable = false;
        }
        else if(!isSellable && isExchangable)
        {
            sellButton.interactable = false;
        }
    }
}
