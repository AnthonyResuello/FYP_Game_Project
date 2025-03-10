using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageSelectionPanel : MonoBehaviour
{
    public Button javascriptButton; // JavaScript Button 
    public Button javaButton; // Java Button 
    public Button csharpButton; // CSharp Button 
    public Button pythonButton; // Python Button 

    public string selectedLanguage; // Store Selected programming langauge

    void Start()
    {
        javascriptButton.onClick.AddListener(() => SelectLanguage("JavaScript"));
        javaButton.onClick.AddListener(() => SelectLanguage("Java"));
        csharpButton.onClick.AddListener(() => SelectLanguage("C#"));
        pythonButton.onClick.AddListener(() => SelectLanguage("Python"));
    }

    // Method to manage the language selection of the player
    public void SelectLanguage(string language)
    {
        selectedLanguage = language;
       
        // Store selected language in PlayerPrefs so that it's persistent across scenes
        PlayerPrefs.SetString("SelectedLanguage", selectedLanguage);
        PlayerPrefs.Save();

        ProceedToGame();  // Start the game 
    }

    public void ProceedToGame()
    {
        SceneManager.LoadScene("Level1");  // Load Level1 
    }
}
