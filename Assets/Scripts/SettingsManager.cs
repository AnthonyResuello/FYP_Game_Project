using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; 
    public Slider volumeSlider;      
    public Button resumeButton;   
    public Button settingsButton; 
    public Button quitButton;    
    
    public AudioSource backgroundMusic;     
    public GameObject darkOverlay;        

    private float maxVolume = 0.9f; // Max Volume      
    private float defaultVolume = 0.9f; // Default Volume 

    void Start()
    {
       
        ApplySavedVolume(); // Apply Saved Volume Setting 
        volumeSlider.maxValue = maxVolume;
        volumeSlider.value = AudioListener.volume; 
        volumeSlider.onValueChanged.AddListener(SetVolume);

        resumeButton.onClick.AddListener(ResumeGame); // Resume Game 

        settingsButton.onClick.AddListener(ShowSettingsPanel); // Show settings

        quitButton.onClick.AddListener(QuitGame); // Quit game
    }


    // Method to apply the saved volume from PlayerPrefs
    private void ApplySavedVolume()
    {
        float savedVolume = PlayerPrefs.GetFloat("volume", defaultVolume);  // Get saved volume
        AudioListener.volume = savedVolume; // Apply volume
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = savedVolume; // Apply to music
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
       
    }

    // Method to set the volume of the game and background music
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


    // Method to show the settings panel and pause the game
    public void ShowSettingsPanel()
    {
        settingsPanel.SetActive(true);   
        darkOverlay.SetActive(true);      
        Time.timeScale = 0f;   
    }


    // Method to resume the game and hide the settings panel
    public void ResumeGame()
    {
        settingsPanel.SetActive(false);    
        darkOverlay.SetActive(false);     
        Time.timeScale = 1f;             
    }


    // Method to quit the game or return to the main menu
    public void QuitGame()
    {
        Debug.Log("Returning to main menu or quitting game.");

       
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
   
    }
}
