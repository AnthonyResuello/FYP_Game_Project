using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button TryAgain;         // Reference to the Try Again button
    public Button Exit;             // Reference to the Exit button
    public GameObject gameOverPanel; // Reference to the Game Over panel UI (UI element)

    void Start()
    {
        // Check if buttons are assigned and show a warning if not
        if (TryAgain == null || Exit == null)
        {

            return;
        }

        // Automatically assign button actions when the scene starts
        TryAgain.onClick.AddListener(OnTryAgain);
        Exit.onClick.AddListener(ExitGame);

        // Show the GameOver panel and pause the game
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the GameOver screen
        }
        Time.timeScale = 0f; // Pause the game
    }

    // This function will be called when the Try Again button is clicked
    public void OnTryAgain()
    {
        // Reset the game progress immediately
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress
        }

        // Reload the game scene (Level 1)
        SceneManager.LoadScene("Level1"); // Make sure this is your game scene name
        Time.timeScale = 1f; // Unpause the game when reloading the level
    }

    public void ExitGame()
    {
        // Reset progress in the ProgressManager when exiting (not saving anything)
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress to default state
        }

        // Optionally load the main menu or exit
        SceneManager.LoadScene("MainMenu"); // Ensure this is your main menu scene name
        Time.timeScale = 1f; // Unpause the game when exiting to the main menu
    }
}
