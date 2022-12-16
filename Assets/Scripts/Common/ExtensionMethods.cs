using System;
using Random = System.Random;

/// <summary>
/// 확장 메서드는 static Class에서 static으로 정의되어야 함
/// 첫 parameter를 this 키워드로 되어야 한다.
/// </summary>
public static class ExtensionMethods
{
    public static float NextSingle(this Random random, float min, float max)
    {
        return UnityEngine.Mathf.Lerp(min, max, (float)random.NextDouble());
    }

    /// <summary>
    /// Key 값이 같은 enum 변경
    /// string parse를 사용 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="fromEnum"></param>
    /// <returns></returns>
    public static T ConvertEnumTo<T>(this Enum fromEnum)
    {
        return (T)Enum.Parse(typeof(T), fromEnum.ToString());
    }
}