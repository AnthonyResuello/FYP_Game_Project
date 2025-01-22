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
        currentHP = maxHP;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHP;
            healthSlider.value = maxHP;
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
    }

    private void CheckGameOver()
    {
        if (currentHP <= 0)
        {
            Debug.Log("Game Over! Player has lost.");
            SceneManager.LoadScene("GameOver");
        }
    }

    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }
}
