using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{

    public Button startButton; // Start Button 


    void Start()
    {
        startButton.onClick.AddListener(Game);
    }

    // Method to load the main menu scene 
    public void Game()
    {
        SceneManager.LoadScene("MainMenu"); // Load Main Menu Scene 
    }


}
