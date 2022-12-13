using UnitSpace;

public interface ISelectable
{
    public bool IsSelected { get; set; }
    public bool IsUnit { get; }
    /// <summary>
    /// 클릭했을 때 유닛 선택
    /// </summary>
    public bool GetSelected();
    public void UnSelect();
}
