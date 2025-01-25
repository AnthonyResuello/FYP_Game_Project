using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance; // Singleton instance for easy access

    public int currentLevel = 1;
    public string selectedLanguage = ""; // Variable to store the selected language

    public float level1Progress = 0f;
    public float level2Progress = 0f;
    public float level3Progress = 0f;
    public float level4Progress = 0f;

    public float playerHealth = 100f; // Player health stored here

    void Awake()
    {
        // Ensure the singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
            Debug.Log("ProgressManager initialized.");
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }

        // Load selected language from PlayerPrefs (default to "English")
        selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "English");
        Debug.Log("Selected Language: " + selectedLanguage);
    }

    public void SetLanguage(string language)
    {
        selectedLanguage = language;
        Debug.Log("Language set to: " + selectedLanguage);
    }

    public string GetLanguage()
    {
        return selectedLanguage;
    }

    public void ResetGame()
    {
        currentLevel = 1;
        level1Progress = 0f;
        level2Progress = 0f;
        level3Progress = 0f;
        level4Progress = 0f;
        playerHealth = 100f; // Reset player health to max when resetting the game
        selectedLanguage = "English"; // Reset language to default
    }

    // Optionally, you could have a method to load the ProgressManager prefab if it doesn't exist
    public static void CreateProgressManager()
    {
        if (Instance == null)
        {
            Debug.Log("ProgressManager not found, creating a new one.");
            var progressManagerPrefab = Resources.Load("ProgressManagerPrefab") as GameObject;
            if (progressManagerPrefab != null)
            {
                Instantiate(progressManagerPrefab);
            }
            else
            {
                Debug.LogError("ProgressManager prefab not found in Resources folder!");
            }
        }
    }
}
