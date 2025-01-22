using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image progressBarFill1;  // Progress bar for Level 1
    [SerializeField] private Image progressBarFill2;  // Progress bar for Level 2
    [SerializeField] private Image progressBarFill3;  // Progress bar for Level 3
    [SerializeField] private Image progressBarFill4;  // Progress bar for Level 4

    private float maxProgress = 1f; // Full bar progress (used to calculate the fill)
    private int currentLevel = 1;  // Current level tracker (starts with Level 1)

    public PlayerHealth playerHealth; // Reference to the player health script
    public NPCHealth npcHealth; // Reference to the NPC health script

    void Start()
    {
        // Debugging to check if references are assigned
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth is not assigned in LevelManager!");
        }

        if (npcHealth == null)
        {
            Debug.LogError("NPCHealth is not assigned in LevelManager!");
        }

        if (ProgressManager.Instance == null)
        {
            Debug.LogError("ProgressManager.Instance is null!");
            return; // Prevent further execution if the instance is not available
        }

        // Initialize the progress bars based on saved progress
        InitializeLevelProgress();
    }

    void InitializeLevelProgress()
    {
        // Check if all progress bars are assigned
        if (progressBarFill1 == null || progressBarFill2 == null || progressBarFill3 == null || progressBarFill4 == null)
        {
            Debug.LogError("Progress bar(s) not assigned in the Inspector!");
            return;
        }

        // Get the saved current level from ProgressManager
        currentLevel = ProgressManager.Instance.currentLevel;

        // Initialize Level progress bars
        progressBarFill1.fillAmount = (currentLevel >= 1) ? ProgressManager.Instance.level1Progress : 0f;
        progressBarFill2.fillAmount = (currentLevel >= 2) ? ProgressManager.Instance.level2Progress : 0f;
        progressBarFill3.fillAmount = (currentLevel >= 3) ? ProgressManager.Instance.level3Progress : 0f;
        progressBarFill4.fillAmount = (currentLevel >= 4) ? ProgressManager.Instance.level4Progress : 0f;
    }

    public void UpdateProgress(float playerHealthPercentage, float npcHealthPercentage)
    {
        // Ensure healthPercentage is within a valid range (0 to 1)
        if (npcHealthPercentage < 0f || npcHealthPercentage > 1f)
        {
            Debug.LogError("NPC health percentage out of range: " + npcHealthPercentage);
            return;
        }

        // Calculate the fill amount for the progress bar (1 - npcHealthPercentage to fill bar as health decreases)
        float targetFillAmount = (1f - npcHealthPercentage) * maxProgress;

        // Get the current level from ProgressManager
        currentLevel = ProgressManager.Instance.currentLevel;

        if (currentLevel == 1)
        {
            progressBarFill1.fillAmount = targetFillAmount;
            ProgressManager.Instance.level1Progress = targetFillAmount;

            // Check if Level 1 is complete
            if (targetFillAmount >= maxProgress)
            {
                Debug.Log("Level 1 Complete! Moving to Level 2...");
                MoveToNextLevel(); // Move to Level 2
            }
        }
        else if (currentLevel == 2)
        {
            progressBarFill2.fillAmount = targetFillAmount;
            ProgressManager.Instance.level2Progress = targetFillAmount;

            // Check if Level 2 is complete
            if (targetFillAmount >= maxProgress)
            {
                Debug.Log("Level 2 Complete! Moving to Level 3...");
                MoveToNextLevel(); // Move to Level 3
            }
        }
        else if (currentLevel == 3)
        {
            progressBarFill3.fillAmount = targetFillAmount;
            ProgressManager.Instance.level3Progress = targetFillAmount;

            // Check if Level 3 is complete
            if (targetFillAmount >= maxProgress)
            {
                Debug.Log("Level 3 Complete! Moving to Level 4...");
                MoveToNextLevel(); // Move to Level 4
            }
        }
        else if (currentLevel == 4)
        {
            progressBarFill4.fillAmount = targetFillAmount;
            ProgressManager.Instance.level4Progress = targetFillAmount;

            // Check if Level 4 is complete (NPC's health reaches 0)
            if (targetFillAmount >= maxProgress)
            {
                Debug.Log("Level 4 Complete! You Win!");
                EndGame(); // Load the Win Scene
            }
        }
    }

    public void MoveToNextLevel()
    {
        // Increment the level
        currentLevel++;
        ProgressManager.Instance.currentLevel = currentLevel; // Save the current level

        // Keep progress bars updated for next level
        if (currentLevel == 2)
        {
            progressBarFill1.fillAmount = 1f; // Keep Level 1 bar filled
            progressBarFill2.fillAmount = 0f; // Reset Level 2 bar
            SceneManager.LoadScene("Level2"); // Load Level 2
        }
        else if (currentLevel == 3)
        {
            progressBarFill2.fillAmount = 1f; // Keep Level 2 bar filled
            progressBarFill3.fillAmount = 0f; // Reset Level 3 bar
            SceneManager.LoadScene("Level3"); // Load Level 3
        }
        else if (currentLevel == 4)
        {
            progressBarFill3.fillAmount = 1f; // Keep Level 3 bar filled
            progressBarFill4.fillAmount = 0f; // Reset Level 4 bar
            SceneManager.LoadScene("Level4"); // Load Level 4
        }
        else
        {
            Debug.Log("All levels completed. Display the end screen or reset the game.");
        }
    }

    public void EndGame()
    {
        // Final game logic for winning (loading the Win scene)
        Debug.Log("You win! Transitioning to Win Scene...");

        // Load the Win scene (Make sure this scene exists in your project)
        SceneManager.LoadScene("Win"); // Ensure the scene is correctly named in your project
    }
}
