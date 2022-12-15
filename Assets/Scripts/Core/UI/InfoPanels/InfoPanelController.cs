using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPanelController : MonoBehaviour
{
    private InfoPanel_Unit infoPanel_Unit;
    private InfoPanel_Enemy infoPanel_Enemy;

    public InfoPanel_Unit UnitPanel => infoPanel_Unit;
    public InfoPanel_Enemy EnemyPanel => infoPanel_Enemy;

    private UICam uiCam;

    private void Awake()
    {
        infoPanel_Unit = transform.GetChild(1).GetComponent<InfoPanel_Unit>();
        infoPanel_Enemy = transform.GetChild(2).GetComponent<InfoPanel_Enemy>();

        uiCam = FindObjectOfType<UICam>();
        HideAllPanels();
    }

    public void ShowUnitPanel()
    {
        EnemyPanel.HidePanel();
        UnitPanel.ShowPanel();
        uiCam.gameObject.SetActive(true);
    }

    public void ShowEnemyPanel()
    {
        UnitPanel.HidePanel();
        EnemyPanel.ShowPanel();
        uiCam.gameObject.SetActive(true);
    }

    public void HideAllPanels()
    {
        UnitPanel.HidePanel();
        EnemyPanel.HidePanel();
        uiCam.gameObject.SetActive(false);
    }
}
