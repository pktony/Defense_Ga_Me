using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputActions inputs;
    Camera mainCam;

    private ISelectable selectedCharacter;
    private IUnit selectedUnit;

    private void Awake()
    {
        inputs = new();
        mainCam = Camera.main;
    }

    private void OnEnable()
    {
        inputs.Enable();
        inputs.Player.Select_Move.performed += OnSelection;
    }

    private void OnDisable()
    {
        inputs.Player.Select_Move.performed -= OnSelection;
        inputs.Disable();
    }

    private void OnSelection(InputAction.CallbackContext _)
    {
        Ray ray = mainCam.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, LayerMask.GetMask("Default")))
        {
            if(hit.collider.TryGetComponent<ISelectable>(out ISelectable selectable))
            {
                selectedCharacter = selectable;
                //unit.GetSelected();

                if(selectedCharacter.IsUnit)
                {// unit 일 때 
                    if (hit.collider.TryGetComponent<IUnit>(out IUnit unit))
                    {
                        selectedUnit = unit;
                        selectable.GetSelected();

                        // Unit의 스탯 가져와서 UI 갱신
                    }
                }
                else
                {// 적을 선택했을 때 
                    selectable.GetSelected();

                    // Enemy의 스탯을 가져와서 UI 갱신 
                }
            }
            else
            {// 유닛 외 다른 선택을 함
                //if(selectedUnit != null)
                //{
                //    selectedUnit.Move(hit.point);
                //}
            }
        }
    }
}
