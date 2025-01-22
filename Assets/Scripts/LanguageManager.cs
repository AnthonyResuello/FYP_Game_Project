using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    // Singleton to ensure we can access this from anywhere
    public static LanguageManager Instance;

    // Language chosen by the player
    public string selectedLanguage;

    void Awake()
    {
        // Make sure the script is a singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to set the selected language
    public void SetSelectedLanguage(string language)
    {
        selectedLanguage = language;
        Debug.Log("Selected Language: " + selectedLanguage);
    }
}
