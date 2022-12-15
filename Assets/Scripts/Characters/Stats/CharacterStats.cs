using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ISelectable
{
    protected GameObject selectionCircle;
    protected bool isSelected;

    private bool isUnit;

    public Vector3 currentPos => transform.position;
    public virtual bool IsSelected { get; set;}
    public bool IsUnit { get => isUnit; }

    protected virtual void Awake()
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
        IsSelected = false;
    }
}
