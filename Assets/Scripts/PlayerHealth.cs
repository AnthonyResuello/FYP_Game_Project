using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene transitions

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // UI Slider element to display health
    public Text playerHealthText; // UI Text element to display numeric health
    public float maxHP = 100f;
    private float currentHP;

    public PlayerAnimationController playerAnimationController; // Reference to animation controller
    public LevelManager levelManager;  // Reference to LevelManager for feedback panel

    public DamagePopUp damagePopUpManager; // Reference to the DamagePopUp manager

    private bool isGameOver = false; // Flag to track if game over has been triggered

    void Start()
    {
        if (ProgressManager.Instance != null)
        {
            currentHP = ProgressManager.Instance.playerHealth; // Load the saved health
        }
        else
        {
            currentHP = maxHP; // If no ProgressManager, initialize with max HP
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHP;
            healthSlider.value = currentHP;
        }
        else
        {
            Debug.LogError("Health Slider is not assigned in PlayerHealth.");
        }

        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        Debug.Log($"Applying Damage: {amount}");
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

    private void CheckGameOver()
    {
        if (currentHP <= 0 && !isGameOver)
        {
            isGameOver = true; // Ensure the game over process happens only once
            Debug.Log("Game Over! Player has lost.");

            // Show feedback panel immediately when the player dies
            if (levelManager != null)
            {
                levelManager.ShowFeedbackPanelOnGameOver(); // Show feedback panel before transitioning
            }

            // Optionally reset health when player dies (you can adjust this as needed)
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
