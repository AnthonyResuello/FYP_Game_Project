using UnityEngine;

public class Player2AnimationController : MonoBehaviour
{
    private Animator animator;

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip attackSound;  // Reference to attack sound effect
    public AudioClip hurtSound;    // Reference to hurt sound effect

    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize Animator component
    }

    public void Play2HurtAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Hurt");

            // Play the hurt sound effect
            if (audioSource != null && hurtSound != null)
            {
                audioSource.PlayOneShot(hurtSound); // Play hurt sound once
            }

            Invoke("Play2IdleAnimation", 1f); // Ensure the hurt animation completes before idle
        }
    }

    public void Play2AttackAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Attack");

            // Play the attack sound effect
            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound); // Play attack sound once
            }

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
