using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ISelectable
{
    private GameObject selectionCircle;
    private bool isSelected;

    public Stats stats;

    public bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!isSelected)
            {// 선택되지 않았으면
                selectionCircle.SetActive(true);
                Debug.Log("selected");
            }
            else
            {// 이미 선택 됐으면
                UnSelect();
                return;
            }
            isSelected = value;
        }
    }

    public bool IsUnit { get; }

    private void Awake()
    {
        selectionCircle = transform.GetChild(1).gameObject;
    }

    public bool GetSelected()
    {
        IsSelected = true;
        return IsSelected;
    }

    public void UnSelect()
    {
        selectionCircle.SetActive(false);
        isSelected = false;
    }


}
