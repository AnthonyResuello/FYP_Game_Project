using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // UI Slider element to display health
    public Text playerHealthText; // UI Text element to display numeric health
    public float maxHP = 100f;
    private float currentHP;

    public PlayerAnimationController playerAnimationController; // Reference to animation controller

    void Start()
    {
        // Check if ProgressManager exists and load the health from there
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
        if (currentHP <= 0)
        {
            Debug.Log("Game Over! Player has lost.");
            // Reset health when player dies
            if (ProgressManager.Instance != null)
            {
                ProgressManager.Instance.playerHealth = maxHP;
            }

            SceneManager.LoadScene("GameOver"); // Load Game Over scene
        }
    }

    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }
}
