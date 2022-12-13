using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ISelectable
{
    private GameObject selectionCircle;
    private bool isSelected;
    private bool isUnit;

    //public Stats_Unit stats;

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

    public bool IsUnit { get => isUnit; }

    private void Awake()
    {
        selectionCircle = transform.GetChild(1).gameObject;

        isUnit = transform.CompareTag("Unit");
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
