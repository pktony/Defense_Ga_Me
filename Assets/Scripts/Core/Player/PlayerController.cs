using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputActions inputs;
    Camera mainCam;

    private IUnit selectedUnit;

    private void Awake()
    {
        inputs = new();
        mainCam = Camera.main;
    }

    private void Start()
    {
        
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
            if(hit.collider.TryGetComponent<IUnit>(out IUnit unit))
            {
                selectedUnit = unit;
                unit.GetSelected();
            }
            else
            {// 유닛 외 다른 선택을 함
                if(selectedUnit != null)
                {
                    selectedUnit.Move(hit.point);
                }
            }
        }
    }
}
