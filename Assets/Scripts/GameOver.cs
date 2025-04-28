using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button TryAgain; // Try again button
    public Button Exit; // Exit Button
    public GameObject gameOverPanel; // Game Over Panel for the buttons

    void Start()
    {
        TryAgain.onClick.AddListener(OnTryAgain);
        Exit.onClick.AddListener(ExitGame);

        // Check if the GameOver panel is assigned
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Show the GameOver screen
        }

        Time.timeScale = 0f; // Pause the game
    }


    public void OnTryAgain()
    {

        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress
        }

        // Reload the game scene (Level 1)
        SceneManager.LoadScene("Level1"); 
        Time.timeScale = 1f; // Unpause the game when reloading the level
    }

    public void ExitGame()
    {
       
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress 
        }

        SceneManager.LoadScene("MainMenu"); 
        Time.timeScale = 1f; // Unpause the game when exiting to the main menu
    }
}
