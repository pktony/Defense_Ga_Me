using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public Stats_Enemy stats;

    private float healthPoint;
    private float shield;

    public float hp
    {
        get => healthPoint;
        set => healthPoint = value;
    }
    public float Shield
    {
        get => shield;
        set => shield = value;
    }

    public override bool IsSelected
    {
        get => isSelected;
        set
        {
            if (!isSelected)
            {// 선택되지 않았으면
                selectionCircle.SetActive(true);
                UIManager.Inst.InfoPanels.EnemyPanel.SetDatas(ref stats, shield, hp);
                UIManager.Inst.InfoPanels.ShowEnemyPanel();
                Debug.Log("selected");
            }
            else
            {// 이미 선택 됐으면
                selectionCircle.SetActive(false);
                UIManager.Inst.InfoPanels.HideAllPanels();
            }
            isSelected = value;
        }
    }

    public void SetStats(MonsterScriptables data)
    {
        stats = new Stats_Enemy(data.name, data.maxHP, data.shield,
            data.moveSpeed, data.dp);
    }
}
