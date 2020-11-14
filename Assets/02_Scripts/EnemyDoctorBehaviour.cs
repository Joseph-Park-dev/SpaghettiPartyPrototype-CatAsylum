using UnityEngine;

public class EnemyDoctorBehaviour : MonoBehaviour
{
    [SerializeField] private CharacterMovementData enemyDoctorMoveData;

    [SerializeField] private GameObject targetObject;
    [SerializeField] float minDist;
    [SerializeField] private float maxSpeed = 2;
    private float distance;
    bool isGrounded;
    bool isCollidingWall;

    private EnemyDoctorAnimation enemyDoctorAnimation;
    private Vector2 startingPosition;
    private Vector2 targetPosition;
    private Vector2 roamingPosition;

    private int horizontalDir = 0;
    private float scaleX;

    private void Start()
    {
        enemyDoctorAnimation = GetComponent<EnemyDoctorAnimation>();
        startingPosition = transform.position;
        roamingPosition = GetRoaminigPosition();
        scaleX = transform.localScale.x;
    }

    private void Update()
    {
        SetHorizontalDir();
        MoveToTarget();
        AnimateEnemyDoctor();
    }

    private void MoveToTarget()
    {
        distance = Vector2.Distance(transform.position, targetObject.transform.position);
        if (distance > minDist)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                new Vector2(
                    targetObject.transform.position.x,
                    transform.position.y),
                maxSpeed * Time.deltaTime
                );
        }
    } 

    private void SetHorizontalDir()
    {
        Vector2 distanceVec2 = this.transform.position - targetObject.transform.position;
        if (distanceVec2.x > 0)
            horizontalDir = 1;
        else if (distanceVec2.x < 0)
            horizontalDir = -1;
    }
    private Vector2 GetRoaminigPosition()
    {
        return startingPosition + UtilsClass.GetRandomHorizontalDir() *
            Random.Range(enemyDoctorMoveData.RoamingMinDist, enemyDoctorMoveData.RoamingMaxDist);
    }

    private void AnimateEnemyDoctor()
    {
        if (horizontalDir > 0)
        {
            transform.localScale =
                new Vector2(-scaleX, transform.localScale.y);
        }
        else
        {
            transform.localScale =
                new Vector2(scaleX, transform.localScale.y);
        }
        // Animation for horizontal run
        enemyDoctorAnimation.EnemyDoctorMovesAnim(distance);  

    }
}