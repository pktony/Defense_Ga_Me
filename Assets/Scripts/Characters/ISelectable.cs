using UnityEngine;
using UnitSpace;

public interface ISelectable
{
    /// <summary>
    /// UI cam 용 프롶퍼티
    /// </summary>
    public Vector3 currentPos { get; }

    public bool IsSelected { get; set; }
    public bool IsUnit { get; }
    /// <summary>
    /// 클릭했을 때 유닛 선택
    /// </summary>
    public bool GetSelected();
    public void UnSelect();
}