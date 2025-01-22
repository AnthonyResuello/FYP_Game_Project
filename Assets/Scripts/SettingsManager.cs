using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;        // Reference to the settings panel
    public Slider volumeSlider;             // Reference to the volume slider
    public Button resumeButton;             // Reference to the resume button
    public Button settingsButton;           // Reference to the settings button
    public Button quitButton;               // Reference to the quit button
    public AudioSource backgroundMusic;     // Reference to the background music AudioSource
    public GameObject darkOverlay;          // Reference to the dark overlay

    private float maxVolume = 0.9f;         // Set max volume to 90%
    private float defaultVolume = 0.9f;     // Default volume is 90%

    void Start()
    {
        // Apply the saved volume setting
        ApplySavedVolume();

        // Set the slider's maximum value to 0.9
        volumeSlider.maxValue = maxVolume;

        // Set the slider value to match the current global volume (savedVolume)
        volumeSlider.value = AudioListener.volume; // Reflect the actual volume on the slider

        // Add listener to the volume slider to adjust the game volume
        volumeSlider.onValueChanged.AddListener(SetVolume);

        // Add listener for the resume button
        resumeButton.onClick.AddListener(ResumeGame);

        // Add listener for the settings button to open the settings panel
        settingsButton.onClick.AddListener(ShowSettingsPanel);

        // Add listener for the quit button
        quitButton.onClick.AddListener(QuitGame);
    }

    // This method is used to apply the saved volume from PlayerPrefs
    private void ApplySavedVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", defaultVolume); // Retrieve saved volume
        AudioListener.volume = savedVolume;   // Set global volume to saved or default value
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = savedVolume; // Set background music volume to saved or default value
        }
    }

    // Method to start the background music
    public void StartBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            // Check if the music is not playing, only then start it
            if (!backgroundMusic.isPlaying)
            {
                backgroundMusic.Play(); // Start playing the background music
            }
        }
        else
        {
            Debug.LogError("Background music AudioSource is not assigned!");
        }
    }

    // Adjusts the global volume based on the slider, limiting it to 0.9 max
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;  // Adjusts the overall game volume, max 0.9
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume; // Adjusts the background music volume too
        }

        // Save the volume setting to PlayerPrefs so it persists across sessions
        PlayerPrefs.SetFloat("volume", volume); // Save volume setting
        PlayerPrefs.Save();
    }

    // Pauses the game and shows the settings panel
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);    // Show the settings panel when the button is clicked
        darkOverlay.SetActive(true);      // Show the dark overlay
        Time.timeScale = 0f;              // Pause the game
    }

    // Resumes the game and hides the settings panel
    public void ResumeGame()
    {
        settingsPanel.SetActive(false);    // Hide the settings panel
        darkOverlay.SetActive(false);      // Hide the dark overlay
        Time.timeScale = 1f;               // Resume the game
    }

    // Quits the game or returns to the main menu
    public void QuitGame()
    {
        Debug.Log("Quit button pressed. Returning to main menu or quitting game.");

        // Reset progress (but not settings like volume)
        ResetProgress(); // Clear game progress but retain settings

        SceneManager.LoadScene("MainMenu"); // Load main menu scene
    }

    // Resets the game progress
    private void ResetProgress()
    {
        if (ProgressManager.Instance != null)
        {
            ProgressManager.Instance.ResetGame(); // Reset the game's progress
        }
        else
        {
            Debug.LogWarning("ProgressManager is not found or not assigned.");
        }
    }
}
