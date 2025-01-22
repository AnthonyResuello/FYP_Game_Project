using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public Button mainMenuButton;  // Reference to the Main Menu button
    public Button playAgainButton; // Reference to the Play Again button
    public GameObject winPanel;    // Reference to the Win panel UI (UI element)

    void Start()
    {
        // Check if buttons are assigned and show a warning if not
        if (mainMenuButton == null || playAgainButton == null)
        {
            Debug.LogError("Buttons are not assigned in the Inspector!");
            return;
        }

        // Automatically assign button actions when the scene starts
        mainMenuButton.onClick.AddListener(OnMainMenuClicked);
        playAgainButton.onClick.AddListener(OnPlayAgainClicked);

        // Show the Win panel and pause the game
        if (winPanel != null)
        {
            winPanel.SetActive(true); // Show the Win screen
        }
        Time.timeScale = 0f; // Pause the game
    }

    // This function will be called when the Main Menu button is clicked
    public void OnMainMenuClicked()
    {
        // Reset progress in the ProgressManager when going to the main menu (not saving anything)
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress to default state
        }

        // Load the main menu scene
        SceneManager.LoadScene("MainMenu"); // Ensure this is your main menu scene name
        Time.timeScale = 1f; // Unpause the game when exiting to the main menu
    }

    // This function will be called when the Play Again button is clicked
    public void OnPlayAgainClicked()
    {
        // Reset progress in the ProgressManager when restarting the game
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset progress to default state
        }

        // Reload the first level scene
        SceneManager.LoadScene("Level1"); // Ensure this is your level name
        Time.timeScale = 1f; // Unpause the game when restarting
    }
}
