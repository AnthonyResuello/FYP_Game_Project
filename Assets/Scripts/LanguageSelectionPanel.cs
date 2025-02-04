using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageSelectionPanel : MonoBehaviour
{
    public Button javascriptButton;
    public Button javaButton;
    public Button csharpButton;
    public Button pythonButton;

    public string selectedLanguage;

    void Start()
    {
        // Add listeners to buttons
        javascriptButton.onClick.AddListener(() => SelectLanguage("JavaScript"));
        javaButton.onClick.AddListener(() => SelectLanguage("Java"));
        csharpButton.onClick.AddListener(() => SelectLanguage("C#"));
        pythonButton.onClick.AddListener(() => SelectLanguage("Python"));
    }

    // Method to handle language selection
    public void SelectLanguage(string language)
    {
        selectedLanguage = language;
        Debug.Log("Selected language: " + selectedLanguage);

        // Store selected language in PlayerPrefs so that it's persistent across scenes
        PlayerPrefs.SetString("SelectedLanguage", selectedLanguage);
        PlayerPrefs.Save();

        // Proceed to the game (after language selection)
        ProceedToGame();
    }

    public void ProceedToGame()
    {
        // Proceed to quiz level scene or reset the current scene to update the questions
        SceneManager.LoadScene("Level1");  // Load the quiz scene (adjust as needed)
    }
}
