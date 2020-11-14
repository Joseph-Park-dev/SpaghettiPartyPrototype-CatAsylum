using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] 
    private Animator playerAnimator;

    public void PlayerRunsAnim(float speed)
    {
        playerAnimator.SetFloat("speed", speed);
    }

    public void PlayerJumpsAnim(bool isGrounded)
    {
        playerAnimator.SetBool("isGrounded", isGrounded);
    }
}
