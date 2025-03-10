using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene transitions

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // Health Bar Slider 
    public Text playerHealthText; // Health Text
    public float maxHP = 100f; // Max Health of the Player
    private float currentHP; // Current Health of the player

    public PlayerAnimationController playerAnimationController; 
    public LevelManager levelManager;  

    public DamagePopUp damagePopUpManager; 

    private bool isGameOver = false; // Track if game over has been triggered

    void Start()
    {

        // Load the saved player health from ProgressManager (if available) 
        if (ProgressManager.Instance != null)
        {
            currentHP = ProgressManager.Instance.playerHealth; // Load the saved health
        }
        else
        {
            currentHP = maxHP; // If no ProgressManager, set to max Health
        }

        // Check if healthSlider is assigned
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHP;
            healthSlider.value = currentHP;
        }

        UpdateHealthBar();
    }

    // Method to apply damage to player 
    public void TakeDamage(float amount)
    {
      
        currentHP -= amount;
        if (currentHP < 0) currentHP = 0;

        // Trigger hurt animation
        if (playerAnimationController != null)
        {
            playerAnimationController.PlayHurtAnimation();
        }

        // Show damage pop-up
        if (damagePopUpManager != null)
        {
            damagePopUpManager.ShowDamage(amount, transform.position + new Vector3(0, 1, 0)); // Position slightly above the player
        }

        UpdateHealthBar();
        CheckGameOver();
    }


    // Method to update the health slider and text 
    private void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHP;
        }

        if (playerHealthText != null)
        {
            playerHealthText.text = $"Player HP: {currentHP:0}";
        }

        // Save health in ProgressManager
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.playerHealth = currentHP;
        }
    }

    // Method to check if the game is over (health <= 0)
    private void CheckGameOver()
    {
        if (currentHP <= 0 && !isGameOver)
        {
            isGameOver = true; // Ensure the game over process happens only once
            Debug.Log("Game Over! Player has lost.");

            // Show feedback panel immediately when the player dies
            if (levelManager != null)
            {
                levelManager.ShowFeedbackPanelOnGameOver(); // Show feedback panel 
            }

            if (ProgressManager.Instance != null)
            {
                ProgressManager.Instance.playerHealth = maxHP;
            }
        }
    }

    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }
}
