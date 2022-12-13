public struct Stats_Enemy
{
    public string enemyName;
    public float maxHP;
    public float maxShield;
    public float moveSpeed;
    public float dp;

    /// <summary>
    /// 적 스탯 구조체 생성자
    /// </summary>
    /// <param name="name">적의 이름</param>
    /// <param name="hp">적의 체력</param>
    /// <param name="shield">적의 쉴드량</param>
    /// <param name="moveSpeed">적의 움직임 속도</param>
    /// <param name="dp">적의 방어력</param>
    public Stats_Enemy(string name, float maxHP, float maxShield,
        float moveSpeed, float dp)
    {
        this.enemyName = name;
        this.maxHP = maxHP;
        this.maxShield = maxShield;
        this.moveSpeed = moveSpeed;
        this.dp = dp;
    }
}
