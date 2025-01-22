using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator; // Reference to Animator component

    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize Animator component
    }

    public void PlayHurtAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Play hurt animation
            Invoke("PlayIdleAnimation", 1f); // Adjust the delay according to the duration of the Hurt animation
        }
    }

    public void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Play attack animation
            Invoke("PlayIdleAnimation", 1f); // Adjust the delay according to the duration of the Attack animation
        }
    }

    public void PlayIdleAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("idle"); // Play idle animation

        }
    }
}
