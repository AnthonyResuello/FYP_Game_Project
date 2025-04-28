using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : MonoBehaviour
{
    public Slider healthSlider; // Health Bar Slider
    public Text npcHealthText; // Health Text 
    public float maxHP = 100f; // Max Health of the Enemy NPC
    private float currentHP; // Current Health of the Enemy NPC

    public Player2AnimationController npcAnimationController; 
    public DamagePopUp damagePopUpManager; 

    void Start()
    {
        currentHP = maxHP; // Set Enemy NPC health to Max Health
        UpdateHealthUI(); 
    }


    // Method for when the enemy NPC takes damage
    public void TakeDamage(float damage)
    {
        currentHP -= damage; // Decrease the NPC's Health 
        if (currentHP < 0) currentHP = 0;

        // Trigger hurt animation
        if (npcAnimationController != null)
        {
            npcAnimationController.Play2HurtAnimation();
        }

        // Show damage pop-up text 
        if (damagePopUpManager != null)
        {
            damagePopUpManager.ShowDamage(damage, transform.position + new Vector3(0, 1, 0)); // To show above the NPC
        }

        UpdateHealthUI();

        // Check if enemy's HP is 0 (enemy dies)
        if (currentHP == 0)
        {
            Debug.Log("Enemy NPC is dead!"); // Show when the enemy NPC dies
        }
    }

    // Method to update the health bar slider and text 
    private void UpdateHealthUI()
    {
        healthSlider.value = currentHP / maxHP;
        npcHealthText.text = "Monster Health: " + Mathf.Floor(currentHP).ToString();
    }

    
    // Method to get the enemy NPC health percentage
    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }
}
