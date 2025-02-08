using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
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


        audioSource = gameObject.AddComponent<AudioSource>();

    
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
        feedbackPanel.transform.SetSiblingIndex(feedbackPanel.transform.parent.childCount); 


        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

 
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound);
        }
        else
        {
            Debug.LogError("Feedback panel sound is not assigned!");
        }

    
        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }


        GameObject feedbackIntroMessage = Instantiate(feedbackItemPrefab, feedbackContentParent);

      
        Text questionText = feedbackIntroMessage.transform.Find("QuestionText").GetComponent<Text>();
        questionText.text = "Your Feedback for this level";
        questionText.alignment = TextAnchor.MiddleCenter;  
        questionText.color = new Color(0.180f, 0.180f, 0.180f);
        questionText.fontSize = 48;  

   
        Text correctAnswerText = feedbackIntroMessage.transform.Find("PlayerAnswerText").GetComponent<Text>();
        correctAnswerText.text = "Here’s feedback for the questions you answered incorrectly.";
        correctAnswerText.alignment = TextAnchor.MiddleCenter;
        correctAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        correctAnswerText.fontSize = 38; 

        Text playerAnswerText = feedbackIntroMessage.transform.Find("CorrectAnswerText").GetComponent<Text>();
        playerAnswerText.text = "Review your answers and use this feedback to do better next time!";
        playerAnswerText.alignment = TextAnchor.MiddleCenter;
        playerAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        playerAnswerText.fontSize = 38;  

        playerAnswerText.rectTransform.anchoredPosition = new Vector2(playerAnswerText.rectTransform.anchoredPosition.x, playerAnswerText.rectTransform.anchoredPosition.y - 40f); 

        Text explanationText = feedbackIntroMessage.transform.Find("ExplanationText").GetComponent<Text>();
        explanationText.text = "";
        explanationText.alignment = TextAnchor.MiddleCenter;
        explanationText.color = new Color(0.180f, 0.180f, 0.180f);
        explanationText.fontSize = 38;  

        playerAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  
        playerAnswerText.verticalOverflow = VerticalWrapMode.Overflow;  
        correctAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  
        correctAnswerText.verticalOverflow = VerticalWrapMode.Overflow; 

    
        foreach (var feedback in feedbackList)
        {
            GameObject feedbackItem = Instantiate(feedbackItemPrefab, feedbackContentParent);
            feedbackItem.transform.Find("QuestionText").GetComponent<Text>().text = "Question: " + feedback.questionText;
            feedbackItem.transform.Find("CorrectAnswerText").GetComponent<Text>().text = "Correct Answer: " + feedback.correctAnswer;
            feedbackItem.transform.Find("PlayerAnswerText").GetComponent<Text>().text = "Your Answer: " + feedback.playerAnswer;
            feedbackItem.transform.Find("ExplanationText").GetComponent<Text>().text = "Explanation: " + feedback.explanation;
        }

 
        nextLevelButton.gameObject.SetActive(true);
    }


    // Show the feedback panel for Game Over (when player dies)
    public void ShowFeedbackPanelOnGameOver()
    {
   
        FeedbackDarkOverlay.SetActive(true);
        feedbackPanel.SetActive(true);

        feedbackPanel.transform.SetSiblingIndex(feedbackPanel.transform.parent.childCount);


        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

 
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound);
        }


        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }


        // Game over message for the feedback panel
        GameObject gameOverMessage = Instantiate(feedbackItemPrefab, feedbackContentParent);

        Text questionText = gameOverMessage.transform.Find("QuestionText").GetComponent<Text>();
        questionText.text = "Game Over!";
        questionText.alignment = TextAnchor.MiddleCenter;  
        questionText.color = Color.red;
        questionText.fontSize = 52;  

        Text correctAnswerText = gameOverMessage.transform.Find("PlayerAnswerText").GetComponent<Text>();
        correctAnswerText.text = "Don't worry, you'll do better next time!"; 
        correctAnswerText.alignment = TextAnchor.MiddleCenter;
        correctAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        correctAnswerText.fontSize = 38; 

        Text playerAnswerText = gameOverMessage.transform.Find("CorrectAnswerText").GetComponent<Text>();
        playerAnswerText.text = "Here’s some feedback to help you improve your next attempt!";
        playerAnswerText.alignment = TextAnchor.MiddleCenter;
        playerAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        playerAnswerText.fontSize = 38;  

        Text explanationText = gameOverMessage.transform.Find("ExplanationText").GetComponent<Text>();
        explanationText.text = "";
        explanationText.alignment = TextAnchor.MiddleCenter;
        explanationText.color = new Color(0.180f, 0.180f, 0.180f);
        explanationText.fontSize = 38;  

        playerAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  
        playerAnswerText.verticalOverflow = VerticalWrapMode.Overflow;  
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

      
        nextLevelButton.gameObject.SetActive(true);

    
        nextLevelButton.onClick.RemoveAllListeners();
        nextLevelButton.onClick.AddListener(RestartLevel); 
    }


    public void RestartLevel()
    {
  
        SceneManager.LoadScene("GameOver"); 
    }

    // Function to move to the next level when the button is clicked
    public void OnNextLevelButtonClicked()
    {
        FeedbackDarkOverlay.SetActive(false); 
        feedbackPanel.SetActive(false); 

    
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
            SceneManager.LoadScene("Win"); 
        }
    }
}
