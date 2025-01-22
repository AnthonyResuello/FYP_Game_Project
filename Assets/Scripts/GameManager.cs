using UnityEngine;
using UnityEngine.UI; // Required for UI components

public class GameManager : MonoBehaviour
{
    public GameObject infoPanel;         // Reference to the InfoPanel
    public GameObject darkOverlay;        // Reference to the DarkOverlay
    public Button closeButton;            // Reference to the Close button
    public AudioSource backgroundMusic;   // Reference to the background music AudioSource
    public AudioSource panelOpenSound;    // Reference to the sound played when the panel opens
    public AudioClip confirmSound;        // Reference to the confirm sound effect

    private AudioSource audioSource;      // Reference to an AudioSource for UI sounds

    void Start()
    {
        // Get or create an AudioSource for UI sounds
        audioSource = gameObject.AddComponent<AudioSource>();

        // Show the info panel when the game starts
        ShowInfoPanel();

        // Add listener for the close button
        closeButton.onClick.AddListener(OnCloseButtonClicked);
    }

    // Method to show the info panel and dark overlay
    public void ShowInfoPanel()
    {
        infoPanel.SetActive(true);    // Activate the info panel
        darkOverlay.SetActive(true);   // Activate the dark overlay
        Time.timeScale = 0f;          // Pause the game while the panel is open

        // Play the sound effect for opening the panel
        if (panelOpenSound != null)
        {
            panelOpenSound.Play();
        }
        else
        {
            Debug.LogError("Panel open sound is not assigned!");
        }
    }

    // Method to hide the info panel and dark overlay
    public void HideInfoPanel()
    {
        infoPanel.SetActive(false);    // Deactivate the info panel
        darkOverlay.SetActive(false);   // Deactivate the dark overlay
        Time.timeScale = 1f;           // Resume the game

        // Start the background music when the info panel is closed
        StartBackgroundMusic();
    }

    // Method to start the background music
    private void StartBackgroundMusic()
    {
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play(); // Start playing the background music
        }
        else
        {
            Debug.LogError("Background music AudioSource is not assigned or is already playing!");
        }
    }

    // Method to handle button click
    private void OnCloseButtonClicked()
    {
        PlayConfirmSound(); // Play confirmation sound on button click
        HideInfoPanel();    // Hide the info panel
    }

    // Method to play the confirm sound
    public void PlayConfirmSound()
    {
        if (confirmSound != null)
        {
            audioSource.PlayOneShot(confirmSound); // Play confirm sound
        }
        else
        {
            Debug.LogError("Confirm sound is not assigned!");
        }
    }
}
