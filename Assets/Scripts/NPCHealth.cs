using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Text npcHealthText;
    public float maxHP = 100f;
    private float currentHP;

    public Player2AnimationController npcAnimationController; // Reference to animation controller

    void Start()
    {
        currentHP = maxHP;
        UpdateHealthUI();
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;

        // Trigger hurt animation
        if (npcAnimationController != null)
        {
            npcAnimationController.Play2HurtAnimation();
        }

        UpdateHealthUI();

        if (currentHP == 0)
        {
            Debug.Log("NPC is dead!");
            // Add additional logic for NPC death, if needed
        }
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHP / maxHP;
        npcHealthText.text = "Monster Health: " + Mathf.Floor(currentHP).ToString();
    }

    public float GetHealthPercentage()
    {
        return currentHP / maxHP;
    }
}
