using UnityEngine;

public class Player2AnimationController : MonoBehaviour
{
    private Animator animator; // Enemy NPC animator

    public AudioSource audioSource; 
    public AudioClip attackSound; // Sound effect for attack
    public AudioClip hurtSound; // Sound effect for hurt

    void Start()
    {
        animator = GetComponent<Animator>(); 
    }


    // Method to play the Hurt Animation for the Enemy NPC
    public void Play2HurtAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Hurt"); // Play the Hurt Animation

            if (audioSource != null && hurtSound != null)
            {
                audioSource.PlayOneShot(hurtSound); // Play hurt sound 
            }

            Invoke("Play2IdleAnimation", 1f); // Delay before switching to idle
        }
    }


    // Method to play the Attack Animation for the Enemy NPC
    public void Play2AttackAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("Attack"); // Play attack animation


            if (audioSource != null && attackSound != null)
            {
                audioSource.PlayOneShot(attackSound); // Play attack
            }

            Invoke("Play2IdleAnimation", 1f); // Delay before switching to idle
        }
    }


    // Method to play the Idle Animation for the Enemy NPC
    public void Play2IdleAnimation()
    {
        if (animator != null)
        {
            ResetAnimations();
            animator.SetTrigger("idle");
        }
    }


    // Method to reset the animation
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
