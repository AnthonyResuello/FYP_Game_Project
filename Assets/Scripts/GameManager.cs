using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public GameObject infoPanel; // Info panel 
    public GameObject darkOverlay; // Dark overlay to cover background
    public Button closeButton; // Close Button to close panel 

    public AudioSource backgroundMusic; // Background music for the game 
    public AudioSource panelOpenSound; // Panel sound effect
    public AudioClip confirmSound; // Confirm sound effect

    private AudioSource audioSource; // For UI sounds

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        ShowInfoPanel(); // Show the info panel when the game starts
        closeButton.onClick.AddListener(OnCloseButtonClicked); // Add listener for the close button
    }



    // Method to show the info panel and dark overlay
    public void ShowInfoPanel()
    {
        infoPanel.SetActive(true); 
        darkOverlay.SetActive(true); 
        Time.timeScale = 0f; // Pause the game when the panel is open 

        // Check if open panel sound effect is assigned 
        if (panelOpenSound != null)
        {
            panelOpenSound.Play();  // Play panel sound effect
        }
    
    }



    // Method to hide the info panel and dark overlay
    public void HideInfoPanel()
    {
        infoPanel.SetActive(false);
        darkOverlay.SetActive(false); 
        Time.timeScale = 1f; // Resume the game when the panel is closed 

        StartBackgroundMusic(); // Start the background music 
    }



    // Method to start the background music
    private void StartBackgroundMusic()
    {
        // Check if background music is assigned and if it isn't already playing
        if (backgroundMusic != null && !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play(); // Start playing the background music
        }
     
    }



    // Method to handle button click
    private void OnCloseButtonClicked()
    {
        PlayConfirmSound(); // Play confirmation sound on button click
        HideInfoPanel(); // Hide the info panel
    }



    // Method to play the confirm sound
    public void PlayConfirmSound()
    {
        // Check if confirm sound is assigned 
        if (confirmSound != null)
        {
            audioSource.PlayOneShot(confirmSound); // Play confirm sound
        }
    }
}
