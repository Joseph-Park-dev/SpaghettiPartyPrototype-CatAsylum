using UnityEngine;

[CreateAssetMenu(fileName = "New CharacterMovementData",
                 menuName = "Character Movement Data",
                 order = 51)]
public class CharacterMovementData : ScriptableObject
{
    [Header("Horizontal Move")]
    //[SerializeField] private float maxSpeed;
    [SerializeField] private float acceleration;
    private float speed = 0;

    [Header("Jumping Move")]
    [SerializeField] private float jumpThrust;
    [SerializeField] private float gravityVal;
    private Rigidbody2D rigid2D;

    [Header("Moving AI")]
    [SerializeField] private float roamingMinDist;
    [SerializeField] private float roamingMaxDist;

    /*
    public float MaxSpeed
    {
        get { return maxSpeed; }
        set { maxSpeed = value; }
    }
    */

    public float Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

    public float JumpThrust
    {
        get { return jumpThrust; }
        set { jumpThrust = value; }
    }

    public float GravityVal
    {
        get { return gravityVal; }
        set { gravityVal = value; }
    }

    public Vector2 GetHorizontalTarget(float maxSpeed, int horizontalDir)
    {
        speed = Mathf.Clamp(speed, 0, maxSpeed);
        return new Vector2(speed * horizontalDir * Time.deltaTime, 0);
    }

    public void Jump(Rigidbody2D rigid2D)
    {
        rigid2D.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);
    }

    public void Fall(Rigidbody2D rigid2D)
    {
        rigid2D.AddForce(Vector2.down * gravityVal);
    }

    public float RoamingMinDist
    {
        get { return roamingMinDist; }
        set { roamingMinDist = value; }
    }
    public float RoamingMaxDist
    {
        get { return roamingMaxDist; }
        set { roamingMaxDist = value; }
    }
}
