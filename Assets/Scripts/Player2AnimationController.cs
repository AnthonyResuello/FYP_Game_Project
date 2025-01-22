using UnityEngine;

public class Player2AnimationController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Play2HurtAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Hurt");
            Invoke("Play2IdleAnimation", 1f); // Ensure the hurt animation completes before idle
        }
    }

    public void Play2AttackAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Attack");
            Invoke("Play2IdleAnimation", 1f); // Ensure attack animation completes before idle
        }
    }

    public void Play2IdleAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("idle");
        }
    }

    private void ResetAnimations()
    {
        if (animator != null)
        {
            animator.ResetTrigger("Hurt");
            animator.ResetTrigger("Attack");
            animator.ResetTrigger("idle");
        }
    }
}
