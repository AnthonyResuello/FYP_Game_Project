using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button playInstructions;
    public AudioClip buttonClickSound;   // Sound for button click
    public AudioClip backgroundMusic;    // Background music for the main menu
    public AudioClip panelOpenSound;     // Sound for when the language selection panel opens
    public AudioClip panelCloseSound;    // Sound for when the language selection panel closes

    private AudioSource audioSource;      // AudioSource to handle music and sound effects
    private AudioSource backgroundMusicSource;  // Separate AudioSource for background music

    public GameObject languageSelectionPanel; // Language selection panel
    public GameObject darkOverlay;       // Dark overlay for the transition

    void Start()
    {
        // Get or create an AudioSource for UI sounds
        audioSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();

        // Set up background music to loop and play
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();

        // Assign button listeners
        playButton.onClick.AddListener(PlayGame);
        playInstructions.onClick.AddListener(PlayInstructions);
    }

    // Method to show the language selection panel and play its sound
    public void ShowLanguageSelectionPanel()
    {
        // Play the sound effect for opening the panel
        if (panelOpenSound != null)
        {
            audioSource.PlayOneShot(panelOpenSound);
        }

        // Stop the background music when the language selection panel is shown
        backgroundMusicSource.Pause();  // Pause the background music

        languageSelectionPanel.SetActive(true);    // Activate the language selection panel
        darkOverlay.SetActive(true);   // Activate the dark overlay
        Time.timeScale = 0f;          // Pause the game while the panel is open
    }

    // Method to hide the language selection panel and dark overlay
    public void HideLanguageSelectionPanel()
    {
        // Play the sound effect for closing the panel
        if (panelCloseSound != null)
        {
            audioSource.PlayOneShot(panelCloseSound);
        }

        languageSelectionPanel.SetActive(false);    // Deactivate the language selection panel
        darkOverlay.SetActive(false);   // Deactivate the dark overlay
        Time.timeScale = 1f;           // Resume the game

        // Resume the background music when the language selection panel is closed
        backgroundMusicSource.Play(); // Restart playing the background music
    }

    // Method to handle the Play button click
    public void PlayGame()
    {
        PlayButtonClickSound(); // Play button click sound
        ShowLanguageSelectionPanel(); // Show the language selection panel
    }

    // Method to handle the Instructions button click
    public void PlayInstructions()
    {
        PlayButtonClickSound(); // Play button click sound
        SceneManager.LoadScene("Instructions"); // Load the Instructions scene
    }

    // Method to play the button click sound
    void PlayButtonClickSound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the button click sound
        }
    }
}
