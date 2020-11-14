using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoctorAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator enemyDoctorAnimator;

    public void EnemyDoctorMovesAnim(float distance)
    {
        enemyDoctorAnimator.SetFloat("distance", distance);
    }
}
