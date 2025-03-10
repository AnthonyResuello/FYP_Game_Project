using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance; 

    public int currentLevel = 1; // Tracks the player current level
    public string selectedLanguage = ""; // Stores selected programming langauge

    // Stores progress for each level
    public float level1Progress = 0f;
    public float level2Progress = 0f;
    public float level3Progress = 0f;
    public float level4Progress = 0f;

    public float playerHealth = 100f; // Player Health

    void Awake()
    {
      
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
        
        }
        else
        {
            Destroy(gameObject); // Destroy any duplicate instances
        }

      
        selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "Java"); // Load saved language, default to "Java"
        Debug.Log("Selected Language: " + selectedLanguage); 
    }

    // Method to update the selected sanguage 
    public void SetLanguage(string language)
    {
        selectedLanguage = language;
        Debug.Log("Language set to: " + selectedLanguage);
    }

    // Method to retrieve the selected language
    public string GetLanguage()
    {
        return selectedLanguage;
    }


    // Method to reset all game progress
    public void ResetGame()
    {
        currentLevel = 1;
        level1Progress = 0f;
        level2Progress = 0f;
        level3Progress = 0f;
        level4Progress = 0f;
        playerHealth = 100f; // Reset player health to max when resetting the game
        selectedLanguage = "Java"; // Reset language to default
    }


    // Create ProgressManager instance if it doesn't exist
    public static void CreateProgressManager()
    {
     
        if (Instance == null) 
        {
            var progressManagerPrefab = Resources.Load("ProgressManagerPrefab") as GameObject;
            if (progressManagerPrefab != null)
            {
                Instantiate(progressManagerPrefab); 
            }
          
        }
    }
}
