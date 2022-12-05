public enum Monsters : byte
{
    slime_Red = 0,
    slime_Blue,
    slime_Green,

    spiky_Blue,
    spiky_Green,
    spiky_Red,

    bat_Red,
    bat_Green,
    bat_Violet,
    bat_yellow,

    Ghost_Brown,
    Ghost_Green,
    Ghost_Violet,
    Ghost_White,

    Rabbit_Cyan,
    Rabbit_Green,
    Rabbit_Red,
    Rabbit_Yellow,

    SlimeVar_Blue,
    SlimeVar_Green,
    SlimeVar_Red,
    SlimeVar_Yellow,

    Golem_Poly = 22,

    metalon_Green,
    metalon_Purple,
    metalon_Red,
}

public enum NormalEnemyType : byte
{
    slime_Red = 0,
    slime_Blue,
    slime_Green,

    spiky_Blue,
    spiky_Green,
    spiky_Red,

    bat_Red,
    bat_Green,
    bat_Violet,
    bat_yellow,

    Ghost_Brown,
    Ghost_Green,
    Ghost_Violet,
    Ghost_White,

    Rabbit_Cyan,
    Rabbit_Green,
    Rabbit_Red,
    Rabbit_Yellow,

    SlimeVar_Blue,
    SlimeVar_Green,
    SlimeVar_Red,
    SlimeVar_Yellow,
}

public enum ShieldEnemyType : byte
{
    metalon_Green = 0,
    metalon_Purple,
    metalon_Red,
}

public enum BossType : byte
{
    golem_Poly = 0,
    Lurker,
}


public enum ProjectileID : byte
{
    Bullet_7mm = 0,
    Rocket,
    Missile,
    Mine_Legend,
    Nuclear,
}

namespace UnitSpace
{
    public enum UnitClasses : byte
    {
        Normal,
        Rare,
        Ancient,
        Epic,
        Legend,
        Myth,
        Initium
    }

    public enum InstantUnitType : byte
    {
        //Normal
        gunner_Single = 0,
        pistol_Male,
        pistol_Female,

        //Rare
        gunner_Multiple,
        AR_Male,
        AR_Female,

        //Ancient(스플래시)
        Gunner_Rocket,
        Turret_Rocket,
        Wizard_Fire,

        //Epic (방어력 무시)
        Drone_Laser,
        DroneRed,


        //Initium (전 타일 공격)
        GunnerNuclear,
    }

    public enum ProjectileUnitType : byte
    {
        //Ancient
        gunner_7mmBullet = 0,
        Turret_Rocket,

        //Myth (방어력 무시 , 스플레시 , 빠른 공격력 )

        //Legend(방어력 무시, 스플레시)
        Tank_Missile,
        Miner,

        //Initium
        Tank_Nuclear,
    }   
}