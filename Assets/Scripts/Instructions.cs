using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{

    public Button startButton;


    void Start()
    {
        // Automatically assign button actions when the scene starts
        startButton.onClick.AddListener(Game);

    }

    // This function will be called when the Start Game button is clicked
    public void Game()
    {
        // Assuming your main game scene is called "SampleScene"
        SceneManager.LoadScene("MainMenu");
    }


}
