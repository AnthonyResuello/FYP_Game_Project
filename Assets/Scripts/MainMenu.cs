using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton; // Play Button 
    public Button playInstructions; // Instructions Button

    public AudioClip buttonClickSound; // Sound effect for button click
    public AudioClip backgroundMusic; // Background music 
    public AudioClip panelOpenSound; // Sound effect for opening panel
    public AudioClip panelCloseSound; // Sound effect for closing panel

    private AudioSource audioSource; // AudioSource to handle music and sound effects
    private AudioSource backgroundMusicSource; // Separate AudioSource for background music

    public GameObject languageSelectionPanel; // Language selection panel
    public GameObject darkOverlay; // Dark overlay 

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Audtio Source for Sound Effects
        backgroundMusicSource = gameObject.AddComponent<AudioSource>(); // Audio Source for Background Music 

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true; // Loop background music 
        backgroundMusicSource.Play(); // Play the background music

        playButton.onClick.AddListener(PlayGame); 
        playInstructions.onClick.AddListener(PlayInstructions);
    }


    // Method to show the language selection panel and play its sound
    public void ShowLanguageSelectionPanel()
    {

        // Check if the panel open sound effect is assigned
        if (panelOpenSound != null)
        {
            audioSource.PlayOneShot(panelOpenSound); // Play the sound effect 
        }

        backgroundMusicSource.Pause();  // Pause the background music

        languageSelectionPanel.SetActive(true); // Activate the language selection panel
        darkOverlay.SetActive(true); // Activate the dark overlay

        Time.timeScale = 0f; // Pause the game while the panel is open
    }


    // Method to hide the language selection panel and dark overlay
    public void HideLanguageSelectionPanel()
    {
        // Check if the panel close sound effect is assigned
        if (panelCloseSound != null)
        {
            audioSource.PlayOneShot(panelCloseSound); // Play sound effect 
        }

        languageSelectionPanel.SetActive(false); // Deactivate the language selection panel
        darkOverlay.SetActive(false); // Deactivate the dark overlay
        Time.timeScale = 1f;  // Resume the game

        backgroundMusicSource.Play(); // Resume the background music when the panel is closed 
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


    void PlayButtonClickSound()
    {
        // Check if the audioSource and button click sound are assigned
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Play the button click sound
        }
    }
}
