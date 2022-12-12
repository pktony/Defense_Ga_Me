using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class RandomSeedGenerator
{
    private static Random random;
    private static Random unitRand;

    /// <summary>
    /// 랜덤 클래스를 뽑기 위한 난수 생성
    /// </summary>
    /// <param name="seed"></param>
    public static void SetupClassRandom(int seed)
    {
        random = new Random(seed);
    }

    /// <summary>
    /// 클래스 내 랜덤 유닛을 뽑기 위한 난수 생성 
    /// </summary>
    /// <param name="seed"></param>
    public static void SetupUnitRandom(int seed)
    {
        unitRand = new Random(seed);
    }

    /// <summary>
    /// 난수 생성
    /// </summary>
    /// <param name="isClassRandom"> True : 클래스(0~100),  False : 유닛(0~1)</param>
    /// <returns></returns>
    public static float GenerateRandomNumber()
    {
        float result = random.NextSingle(0f, 100f);

        return result;
    }

    /// <summary>
    /// 난수 생성 
    /// </summary>
    /// <returns> 0 ~ 2 까지 정수</returns>
    public static int GenerateRandomInteger()
    {
        int result = unitRand.Next(0, 2);
        return result;
    }

}
