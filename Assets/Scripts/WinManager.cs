using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public Button mainMenuButton; // Main menu button
    public Button playAgainButton; // Play again button
    public GameObject winPanel;    

    void Start()
    {
        // Check if buttons are assigned 
        if (mainMenuButton == null || playAgainButton == null)
        {
            return; // Return if buttons are not assigned 
        }

        // Assign button actions
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        playAgainButton.onClick.AddListener(OnPlayAgainClicked);

        // Show the Win panel and pause the game
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Show the Win screen
        }
        Time.timeScale = 0f; // Pause the game
    }


    // Main Menu button clicked
    public void OnMainMenuClicked()
    {
    
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress 
        }

        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
        Time.timeScale = 1f; // Unpause the game when exiting to the main menu
    }



    // Play Again button clicked
    public void OnPlayAgainClicked()
    {
     
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress 
        }

        // Reload the first level scene
        SceneManager.LoadScene("Level1"); 
        Time.timeScale = 1f; // Unpause the game when restarting
    }
}
