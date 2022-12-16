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
    private Unit selectedUnit;

    public ISelectable SelectedCharacter => selectedCharacter;

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
        if (Physics.Raycast(ray, out RaycastHit hit, 999f))
        {
            if(hit.collider.TryGetComponent<ISelectable>(out ISelectable selectable))
            {
                if(selectedCharacter != null)
                {// 이미 선택된 경우 원래 캐릭터를 선택해제
                    selectedCharacter.UnSelect();

                    if (selectedCharacter == selectable)
                    {// 같은 캐릭터를 선택한 경우 선택된 캐릭터 해제
                        selectedCharacter = null;
                        selectedUnit = null;
                        return;
                    }
                }
                selectedCharacter = selectable;

                if(selectedCharacter.IsUnit)
                {// unit 일 때 
                    if (hit.collider.TryGetComponent<Unit>(out Unit unit))
                    {
                        UnitManager.Inst.SetSelectedUnit(unit);
                        selectedUnit = unit;
                        selectable.GetSelected();
                    }
                }
                else
                {// 적을 선택했을 때 
                    selectable.GetSelected();
                }
            }
            else
            {// 유닛 외 다른 선택을 함
                if(selectedUnit != null)
                {
                    Vector3 newPos = hit.point;
                    newPos.y = 0f;
                    selectedUnit.Move(newPos);
                }
            }
        }
    }
}
