using UnityEngine;

[CreateAssetMenu(fileName = "New CollisionData",
                 menuName = "Collision Data",
                 order = 52)]
public class CollisionData : ScriptableObject
{
    private const string groundCollisionData = "Ground";
    private const string wallCollisionData = "Wall";

    public string GroundCollisionData
    {
        get
        {
            return groundCollisionData;
        }
    }
    public string WallCollisionData
    {
        get
        {
            return wallCollisionData;
        }
    }
}
