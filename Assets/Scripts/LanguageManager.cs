using UnityEngine;

public class LanguageManager : MonoBehaviour
{
  
    public static LanguageManager Instance;
    public string selectedLanguage; // Language chosen by the player

    void Awake()
    {
       // Ensure there is only one instance of the Langauge Manager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to set the selected programming language for the quiz 
    public void SetSelectedLanguage(string language)
    {
        selectedLanguage = language;
    }
}
