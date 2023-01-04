using UnitSpace;

/// <summary>
/// UI에 정보를 넘겨주기 위해서 여러가지 타입을 넘겨줘야 한다. 
/// </summary>
public struct Stats_Unit
{
    public string name;
    public UnitClasses classType;
    public int attackPower;
    public int attackNumber;
    public float attackCoolTime;
    public float attackRange;
    public bool isDPPentratable;
    public UnitTypes type;

    /// <summary>
    /// Stat 설정용 구조체 생성자
    /// </summary>
    /// <param name="name">유닛의 이름 </param>
    /// <param name="classType">유닛의 클래스 </param>
    /// <param name="AP">유닛의 공격력 </param>
    /// <param name="attackSpeed">유닛의 공격 쿨타임</param>
    /// <param name="attackRange">유닛의 공격 사거리 </param>
    /// <param name="isDPPentratable">방어력 무시 여부</param>
    public Stats_Unit(string name, UnitClasses classType, UnitTypes type, int AP,
        int attackNum, float attackSpeed, float attackRange, bool isDPPentratable)
    {
        this.name = name;
        this.classType = classType;
        this.type = type;
        this.attackPower = AP;
        this.attackNumber = attackNum;
        this.attackCoolTime = attackSpeed;
        this.attackRange = attackRange;
        this.isDPPentratable = isDPPentratable;
    }

    // 구조체는 DEFAULT 생성자를 만들 수 없다
}
