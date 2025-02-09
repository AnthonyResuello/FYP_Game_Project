using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator; // Reference to Animator component

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip attackSound;  // Reference to attack sound effect
    public AudioClip hurtSound;    // Reference to hurt sound effect

    void Start()
    {
        animator = GetComponent<Animator>(); // Initialize Animator component
    }

    public void PlayHurtAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Play hurt animation

            // Play the hurt sound effect
            if (audioSource != null && hurtSound != null)
            {
                audioSource.PlayOneShot(hurtSound); // Play hurt sound once
            }

            Invoke("PlayIdleAnimation", 1f); // Adjust the delay according to the duration of the Hurt animation
        }
    }

    public void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Play attack animation

            // Play the attack sound effect
            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound); // Play attack sound once
            }

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
