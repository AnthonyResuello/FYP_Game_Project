using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Image progressBarFill1;  // Progress bar for Level 1
    [SerializeField] private Image progressBarFill2;  // Progress bar for Level 2
    [SerializeField] private Image progressBarFill3;  // Progress bar for Level 3
    [SerializeField] private Image progressBarFill4;  // Progress bar for Level 4
    [SerializeField] private GameObject FeedbackDarkOverlay; 

    public GameObject feedbackPanel; // Feedback panel 
    public GameObject feedbackItemPrefab; // Prefab for the feedback 
    public Transform feedbackContentParent; // Parent for the feedback items
    public Button nextLevelButton; 

    public AudioSource backgroundMusic; // Background music 
    public AudioClip feedbackPanelSound; // Sound effect feedback panel
    private AudioSource audioSource; // To play the sound

    private float maxProgress = 1f; 
    private int currentLevel = 1;

    public PlayerHealth playerHealth;
    public NPCHealth npcHealth;
    public QuizManager quizManager;

    void Start()
    {
       
        InitializeLevelProgress(); // Initialize the progress bars when the game starts
        audioSource = gameObject.AddComponent<AudioSource>(); // Set up the audio source

        // Check if the next level button is assigned
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked); 
        }
    }


    //Method to initialize the level progress (progress bars)
    void InitializeLevelProgress()
    {
        // Check if any of the progress bar fill are not assigned 
        if (progressBarFill1 == null || progressBarFill2 == null || progressBarFill3 == null || progressBarFill4 == null)
        {
            return; // Exit the method if any progress bar fill are not assigned 
        }

        // Set the progress of each level in the progress bar 
        currentLevel = ProgressManager.Instance.currentLevel;
        progressBarFill1.fillAmount = (currentLevel >= 1) ? ProgressManager.Instance.level1Progress : 0f;
        progressBarFill2.fillAmount = (currentLevel >= 2) ? ProgressManager.Instance.level2Progress : 0f;
        progressBarFill3.fillAmount = (currentLevel >= 3) ? ProgressManager.Instance.level3Progress : 0f;
        progressBarFill4.fillAmount = (currentLevel >= 4) ? ProgressManager.Instance.level4Progress : 0f;
    }


    // Method to update progress bar based on player and NPC health percentage
    public void UpdateProgress(float playerHealthPercentage, float npcHealthPercentage)
    {
        if (npcHealthPercentage < 0f || npcHealthPercentage > 1f)
        {
            return; // If NPC health percentage is out of range, exit early
        }

        float targetFillAmount = (1f - npcHealthPercentage) * maxProgress;
        currentLevel = ProgressManager.Instance.currentLevel;

        // Update the progress bar for the current level based on NPC health
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

    // Method to show the feedback panel and populate it with feedback data
    public void ShowFeedbackPanel(List<QuizManager.FeedbackData> feedbackList)
    {
        FeedbackDarkOverlay.SetActive(true); 
        feedbackPanel.SetActive(true); 
        feedbackPanel.transform.SetSiblingIndex(feedbackPanel.transform.parent.childCount);

        // Check if background music is playing then pause it
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause();
        }

        // Check if feedback panel sound effect is assigned 
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound);
        }

        // Clear the previous feedback items from the panel
        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }


        GameObject feedbackIntroMessage = Instantiate(feedbackItemPrefab, feedbackContentParent);

        // Feedback title 
        Text questionText = feedbackIntroMessage.transform.Find("QuestionText").GetComponent<Text>();
        questionText.text = "Your Feedback for this level";
        questionText.alignment = TextAnchor.MiddleCenter;  
        questionText.color = new Color(0.180f, 0.180f, 0.180f);
        questionText.fontSize = 48;

        // Incorrect answers to the question
        Text correctAnswerText = feedbackIntroMessage.transform.Find("PlayerAnswerText").GetComponent<Text>();
        correctAnswerText.text = "Here’s feedback for the questions you answered incorrectly.";
        correctAnswerText.alignment = TextAnchor.MiddleCenter;
        correctAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        correctAnswerText.fontSize = 38; 

        // Correct answers to the question
        Text playerAnswerText = feedbackIntroMessage.transform.Find("CorrectAnswerText").GetComponent<Text>();
        playerAnswerText.text = "Review your answers and use this feedback to do better next time!";
        playerAnswerText.alignment = TextAnchor.MiddleCenter;
        playerAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        playerAnswerText.fontSize = 38;  

        playerAnswerText.rectTransform.anchoredPosition = new Vector2(playerAnswerText.rectTransform.anchoredPosition.x, playerAnswerText.rectTransform.anchoredPosition.y - 40f); 

        // Explanation to the questions
        Text explanationText = feedbackIntroMessage.transform.Find("ExplanationText").GetComponent<Text>();
        explanationText.text = "";
        explanationText.alignment = TextAnchor.MiddleCenter;
        explanationText.color = new Color(0.180f, 0.180f, 0.180f);
        explanationText.fontSize = 38;  

        playerAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  
        playerAnswerText.verticalOverflow = VerticalWrapMode.Overflow;  
        correctAnswerText.horizontalOverflow = HorizontalWrapMode.Wrap;  
        correctAnswerText.verticalOverflow = VerticalWrapMode.Overflow;

        // Iterate through the feedback list and display each feedback item
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

        // Check if background music is playing then pause it
        if (backgroundMusic != null && backgroundMusic.isPlaying)
        {
            backgroundMusic.Pause(); // Pause background music
        }

        // Check if feedback panel sound effect is assigned 
        if (feedbackPanelSound != null)
        {
            audioSource.PlayOneShot(feedbackPanelSound); // Play the feedback panel sound effect
        }

        // Clear the previous feedback items
        foreach (Transform child in feedbackContentParent)
        {
            Destroy(child.gameObject);
        }


        // Game over message for the feedback panel
        GameObject gameOverMessage = Instantiate(feedbackItemPrefab, feedbackContentParent);

        // Feedback title 
        Text questionText = gameOverMessage.transform.Find("QuestionText").GetComponent<Text>();
        questionText.text = "Game Over!";
        questionText.alignment = TextAnchor.MiddleCenter;  
        questionText.color = Color.red;
        questionText.fontSize = 52;

        // Incorrect answers to the question
        Text correctAnswerText = gameOverMessage.transform.Find("PlayerAnswerText").GetComponent<Text>();
        correctAnswerText.text = "Don't worry, you'll do better next time!"; 
        correctAnswerText.alignment = TextAnchor.MiddleCenter;
        correctAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        correctAnswerText.fontSize = 38;

        // Correct answers to the question
        Text playerAnswerText = gameOverMessage.transform.Find("CorrectAnswerText").GetComponent<Text>();
        playerAnswerText.text = "Here’s some feedback to help you improve your next attempt!";
        playerAnswerText.alignment = TextAnchor.MiddleCenter;
        playerAnswerText.color = new Color(0.180f, 0.180f, 0.180f);
        playerAnswerText.fontSize = 38;

        // Explanation to the questions
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
  
        SceneManager.LoadScene("GameOver"); // Load the Game Over Scene 
    }



    // Move to the next level when the "Next Level" button is clicked
    public void OnNextLevelButtonClicked()
    {
        FeedbackDarkOverlay.SetActive(false); 
        feedbackPanel.SetActive(false);

        // Check if background music is assigned
        if (backgroundMusic != null)
        {
            backgroundMusic.UnPause(); // Resume the background music
        }

        MoveToNextLevel();
    }



    // Method to move to the next level 
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
            SceneManager.LoadScene("Win"); 
        }
    }
}
