using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene transitions
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Image progressBarFill1;  // Progress bar for Level 1
    [SerializeField] private Image progressBarFill2;  // Progress bar for Level 2
    [SerializeField] private Image progressBarFill3;  // Progress bar for Level 3
    [SerializeField] private Image progressBarFill4;  // Progress bar for Level 4
    [SerializeField] private GameObject FeedbackDarkOverlay; // Reference to the dark overlay panel

    [Header("Feedback Panel Elements")]
    public GameObject feedbackPanel;
    public GameObject feedbackItemPrefab;
    public Transform feedbackContentParent;
    public Button nextLevelButton; // Reference to the "Next Level" button

    [Header("Audio")]
    public AudioSource backgroundMusic; // Background music AudioSource
    public AudioClip feedbackPanelSound; // Sound effect when feedback panel appears
    private AudioSource audioSource; // To play the sound

    private float maxProgress = 1f;
    private int currentLevel = 1;

    public PlayerHealth playerHealth;
    public NPCHealth npcHealth;
    public QuizManager quizManager;

    void Start()
    {
        if (playerHealth == null)
            Debug.LogError("PlayerHealth is not assigned in LevelManager!");
        if (npcHealth == null)
            Debug.LogError("NPCHealth is not assigned in LevelManager!");
        if (quizManager == null)
            Debug.LogError("QuizManager is not assigned in LevelManager!");
        if (ProgressManager.Instance == null)
        {
            Debug.LogError("ProgressManager.Instance is null!");
            return;
        }

        InitializeLevelProgress();

        // Get or create an AudioSource for UI sounds
        audioSource = gameObject.AddComponent<AudioSource>();

        // Make sure the button calls the function when clicked
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);
        }
        else
        {
            Debug.LogError("Next Level Button is not assigned!");
        }
    }

    void InitializeLevelProgress()
    {
        if (progressBarFill1 == null || progressBarFill2 == null || progressBarFill3 == null || progressBarFill4 == null)
        {
            Debug.LogError("Progress bar(s) not assigned in the Inspector!");
            return;
        }

        currentLevel = ProgressManager.Instance.currentLevel;
        progressBarFill1.fillAmount = (currentLevel >= 1) ? ProgressManager.Instance.level1Progress : 0f;
        progressBarFill2.fillAmount = (currentLevel >= 2) ? ProgressManager.Instance.level2Progress : 0f;
        progressBarFill3.fillAmount = (currentLevel >= 3) ? ProgressManager.Instance.level3Progress : 0f;
        progressBarFill4.fillAmount = (currentLevel >= 4) ? ProgressManager.Instance.level4Progress : 0f;
    }

    public void UpdateProgress(float playerHealthPercentage, float npcHealthPercentage)
    {
        if (npcHealthPercentage < 0f || npcHealthPercentage > 1f)
        {
            Debug.LogError("NPC health percentage out of range: " + npcHealthPercentage);
            return;
        }

        float targetFillAmount = (1f - npcHealthPercentage) * maxProgress;
        currentLevel = ProgressManager.Instance.currentLevel;

        if (currentLevel == 1)
        {
            progressBarFill1.fillAmount = targetFillAmount;
            ProgressManager.Instance.level1Progress = targetFillAmount;
            if (targetFillAmount >= maxProgress)
            {
                ShowFeedbackPanel(quizManager.GetLevelFeedback(currentLevel));
            }
        }
        else if (currentLevel == 2)
        {
            progressBarFill2.fillAmount = targetFillAmount;
            ProgressManager.Instance.level2Progress = targetFillAmount;
            if (targetFillAmount >= maxProgress)
            {
                ShowFeedbackPanel(quizManager.GetLevelFeedback(currentLevel));
            }
        }
        else if (currentLevel == 3)
        {
            progressBarFill3.fillAmount = targetFillAmount;
            ProgressManager.Instance.level3Progress = targetFillAmount;
            if (targetFillAmount >= maxProgress)
            {
                ShowFeedbackPanel(quizManager.GetLevelFeedback(currentLevel));
            }
        }
        else if (currentLevel == 4)
        {
            progressBarFill4.fillAmount = targetFillAmount;
            ProgressManager.Instance.level4Progress = targetFillAmount;
            if (targetFillAmount >= maxProgress)
            {
                ShowFeedbackPanel(quizManager.GetLevelFeedback(currentLevel));
            }
        }
    }

    // Show the feedback panel and populate it with feedback data
    public void ShowFeedbackPanel(List<QuizManager.FeedbackData> feedbackList)
    {
        FeedbackDarkOverlay.SetActive(true);
        feedbackPanel.SetActive(true);

        // Stop background music when feedback panel appears
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

        // Play the sound effect for showing feedback panel
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound);
        }
        else
        {
            Debug.LogError("Feedback panel sound is not assigned!");
        }

        // Clear existing feedback items in the panel
        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }

        // Populate feedback panel with new feedback items
        foreach (var feedback in feedbackList)
        {
            GameObject feedbackItem = Instantiate(feedbackItemPrefab, feedbackContentParent);
            feedbackItem.transform.Find("QuestionText").GetComponent<Text>().text = "Question: " + feedback.questionText;
            feedbackItem.transform.Find("CorrectAnswerText").GetComponent<Text>().text = "Correct Answer: " + feedback.correctAnswer;
            feedbackItem.transform.Find("PlayerAnswerText").GetComponent<Text>().text = "Your Answer: " + feedback.playerAnswer;
            feedbackItem.transform.Find("ExplanationText").GetComponent<Text>().text = "Explanation: " + feedback.explanation;
        }

        // Optionally, you can enable the "Next Level" button after feedback is shown
        nextLevelButton.gameObject.SetActive(true);
    }

    // Show the feedback panel for Game Over (when player dies)
    public void ShowFeedbackPanelOnGameOver()
    {
        // Show the feedback panel (with dark overlay)
        FeedbackDarkOverlay.SetActive(true);
        feedbackPanel.SetActive(true);

        // Stop background music when feedback panel appears
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

        // Play the feedback panel sound effect if it exists
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound);
        }

        // Clear any existing feedback items in the panel
        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }


        // Add a special Game Over message at the top of the feedback content
        GameObject gameOverMessage = Instantiate(feedbackItemPrefab, feedbackContentParent);

        // Set the "QuestionText" to "Game Over!" and center it with the dark gray color
        Text questionText = gameOverMessage.transform.Find("QuestionText").GetComponent<Text>();
        questionText.text = "Game Over!";
        questionText.alignment = TextAnchor.MiddleCenter;  // Center the text
        questionText.color = new Color(0.180f, 0.180f, 0.180f);  // Set the color to #2E2E2E (RGB)
        questionText.fontSize = 52;  // Set the font size to make it bigger (adjust as needed)

        // Set the "CorrectAnswerText" to a more encouraging message
        Text correctAnswerText = gameOverMessage.transform.Find("PlayerAnswerText").GetComponent<Text>();
        correctAnswerText.text = "Don't worry, you'll do better next time!"; 
        correctAnswerText.alignment = TextAnchor.MiddleCenter;
        correctAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        correctAnswerText.fontSize = 38;  // Set the font size for this text

        // Set the "PlayerAnswerText" to a more motivating message
        Text playerAnswerText = gameOverMessage.transform.Find("CorrectAnswerText").GetComponent<Text>();
        playerAnswerText.text = "Here’s some feedback to help you improve your next attempt!";
        playerAnswerText.alignment = TextAnchor.MiddleCenter;
        playerAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        playerAnswerText.fontSize = 38;  // Set the font size for this text

        // Set the "ExplanationText" to offer helpful advice
        Text explanationText = gameOverMessage.transform.Find("ExplanationText").GetComponent<Text>();
        explanationText.text = "";
        explanationText.alignment = TextAnchor.MiddleCenter;
        explanationText.color = new Color(0.180f, 0.180f, 0.180f);
        explanationText.fontSize = 38;  // Set the font size for this text

        playerAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  // Enable wrapping
        playerAnswerText.verticalOverflow = VerticalWrapMode.Overflow;  // Allow vertical overflow
        // Get the feedback data for the current level (same feedback data as when a level ends)
        List<QuizManager.FeedbackData> feedbackList = quizManager.GetLevelFeedback(ProgressManager.Instance.currentLevel);

        // Populate the feedback panel with the feedback data
        foreach (var feedback in feedbackList)
        {
            GameObject feedbackItem = Instantiate(feedbackItemPrefab, feedbackContentParent);
            feedbackItem.transform.Find("QuestionText").GetComponent<Text>().text = "Question: " + feedback.questionText;
            feedbackItem.transform.Find("CorrectAnswerText").GetComponent<Text>().text = "Correct Answer: " + feedback.correctAnswer;
            feedbackItem.transform.Find("PlayerAnswerText").GetComponent<Text>().text = "Your Answer: " + feedback.playerAnswer;
            feedbackItem.transform.Find("ExplanationText").GetComponent<Text>().text = "Explanation: " + feedback.explanation;
        }

        // Enable the Next Level button after the feedback is shown
        nextLevelButton.gameObject.SetActive(true);

        // Set the button’s onClick listener to restart the game or show the Game Over scene
        nextLevelButton.onClick.RemoveAllListeners();
        nextLevelButton.onClick.AddListener(RestartLevel); // Optionally restart or show Game Over screen
    }


    // Function to restart the level or load a different scene when button is clicked
    public void RestartLevel()
    {
        // Optionally, you can load the Game Over screen or retry the current level
        SceneManager.LoadScene("GameOver"); // Or load any specific scene like "MainMenu" or "Level1"
    }

    // Function to move to the next level when the button is clicked
    public void OnNextLevelButtonClicked()
    {
        FeedbackDarkOverlay.SetActive(false); // Hide overlay
        feedbackPanel.SetActive(false); // Hide feedback panel

        // Resume background music when feedback panel closes
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause();
        }

        MoveToNextLevel();
    }

    public void MoveToNextLevel()
    {
        currentLevel++;
        ProgressManager.Instance.currentLevel = currentLevel;

        if (currentLevel == 2)
        {
            SceneManager.LoadScene("Level2");
        }
        else if (currentLevel == 3)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (currentLevel == 4)
        {
            SceneManager.LoadScene("Level4");
        }
        else
        {
            Debug.Log("All levels completed. Transitioning to end screen.");
            SceneManager.LoadScene("Win"); // Load win screen if all levels are done
        }
    }
}
