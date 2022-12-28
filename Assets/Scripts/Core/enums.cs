public enum MonsterTypes : byte
{
    NormalEnemy,
    ShieldEnemy,
    Boss,
}

public enum Monsters : byte
{
    STARTINGINDEX = 0,

    slime_Red,
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

    Golem_Poly = 23,

    metalon_Green,
    metalon_Purple,
    metalon_Red,

    Chest_Red,
    Chest_Glow,
    Chest_Black,

    Virus_Red,
    Virus_Glow,
    Virus_Black,

    slime_Red_Mid,
    slime_Blue_Mid,

    Lurker_Boss = 35,

    slime_Green_Mid,
    spiky_Blue_Mid,
    spiky_Green_Mid,
    spiky_Red_Mid,

    bat_Red_Mid,
    bat_Green_Mid,
    bat_Violet_Mid,
    bat_yellow_Mid,

    Ghost_Brown_Mid,
    Ghost_Green_Mid,
    Ghost_Violet_Mid,
    Ghost_White_Mid,

    Rabbit_Cyan_Mid,
    Rabbit_Green_Mid,

    Golem_SkillBoss,

    Rabbit_Red_Mid,
    SlimeVar_Blue_Mid,
    SlimeVar_Green_Mid,
    SlimeVar_Red_Mid,
    SlimeVar_Yellow_Mid,

    metalon_Green_Mid,
    metalon_Purple_Mid,
    metalon_Red_Mid,

    Chest_Red_Mid,
    Chest_Glow_Mid,
    Chest_Black_Mid,

    Virus_Red_Mid,
    Virus_Glow_Mid,
    Virus_Black_Mid,
    Virus_White_Mid,

    Lurker_SkillBoss,

    slime_Red_Big,
    slime_Blue_Big,
    slime_Green_Big,

    spiky_Blue_Big,
    spiky_Green_Big,
    spiky_Red_Big,

    bat_Red_Big,
    bat_Green_Big,
    bat_Violet_Big,
    bat_yellow_Big,

    Ghost_Brown_Big,
    Ghost_Green_Big,
    Ghost_Violet_Big,

    Golem_SkillBoss_Big,

    Ghost_White_Big,
    SlimeVar_Blue_Big,
    SlimeVar_Green_Big,
    SlimeVar_Red_Big,
    SlimeVar_Yellow_Big,

    metalon_Green_Big,
    metalon_Purple_Big,
    metalon_Red_Big,

    Chest_Red_Big,
    Chest_Glow_Big,
    Chest_Black_Big,

    Virus_Red_Big,
    Virus_Glow_Big,
    Virus_Black_Big,

    Golem_Boss_Final,
    Lurker_Boss_Final,
    Golem_Skill_2,
    Lurker_Skill_2,
    Golem_Skill_3,
    Lurker_Skill_3,
}


public enum ProjectileID : byte
{
    Bullet_7mm = 0,
    Rocket,
    Missile,
    Mine_Legend,
    RocketFast,
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

    public enum UnitTypes
    {
        Gunner,
        Tank,
        Turret,
        Drone,
        Wizard,
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
        Wizard_Fire,

        //Epic (방어력 무시)
        Drone_Laser,
        DroneRed,
        Wizard_Bolt,

        //Legend(방어력 무시, 스플레시)
        Wizard_Storm,

        //Initium (전 타일 공격)
        GunnerNuclear,
        WizardWater,
    }

    public enum ProjectileUnitType : byte
    {
        //Ancient
        gunner_7mmBullet = 0,
        Turret_Rocket,

        //Legend(방어력 무시, 스플레시)
        Tank_Missile,
        Miner,

        //Myth (방어력 무시 , 스플레시 , 빠른 공격력 )
        Turret_Fast,
        Miner_Fast,

        //Initium
        Tank_Nuclear,
    }


    public enum Units
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
        Wizard_Fire,
        gunner_7mmBullet,
        Turret_Rocket,

        //Epic (방어력 무시)
        Drone_Laser,
        DroneRed,
        Wizard_Bolt,

        //Legend(방어력 무시, 스플레시)
        Wizard_Storm,
        Tank_Missile,
        Miner,

        //Myth(
        Turret_Fast,
        Miner_Fast,
        TEMP_EMPTY,

        //Initium (전 타일 공격)
        GunnerNuclear,
        WizardWater,
        Tank_Nuclear,
    }
}