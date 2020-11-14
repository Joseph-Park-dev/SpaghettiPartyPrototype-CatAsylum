using UnityEngine;

public class UtilsClass
{
    public static Vector2 GetRandomHorizontalDir()
    {
        return new Vector2(Random.Range(-1f, 1f), 0).normalized;
    }
}
