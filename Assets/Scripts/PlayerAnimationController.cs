using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator; // Player animator

    public AudioSource audioSource; 
    public AudioClip attackSound; // Sound effect for attack
    public AudioClip hurtSound; // Sound effect for hurt

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Method to play the Hurt Animation 
    public void PlayHurtAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // Play the Hurt Animation

           
            if (audioSource != null && hurtSound != null)
            {
                audioSource.PlayOneShot(hurtSound); // Play hurt sound 
            }

            Invoke("PlayIdleAnimation", 1f); // Delay before switching to idle
        }
    }

    // Method to play the Attack Animation 
    public void PlayAttackAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Attack"); // Play attack animation

            // Play the attack sound effect
            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound); // Play attack 
            }

            Invoke("PlayIdleAnimation", 1f); // Delay before switching to idle
        }
    }

    // Method to play the Idle animation
    public void PlayIdleAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("idle"); // Play idle animation
        }
    }
}
