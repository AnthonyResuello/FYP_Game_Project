using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    public Text questionText; // Reference to the UI text element for displaying the question
    public Button[] answerButtons; // Buttons for answers
    public PlayerHealth playerHealth; // Reference to PlayerHealth script
    public NPCHealth npcHealth; // Reference to NPCHealth script
    public LevelManager levelManager; // Reference to LevelManager script

    private List<Question> currentQuestions; // List to hold the current set of questions
    private int currentQuestionIndex = 0; // Index to track the current question

    // Feedback data for incorrect answers
    private List<FeedbackData> feedbackList = new List<FeedbackData>();

    // Struct to store feedback data
    public struct FeedbackData
    {
        public string questionText;
        public string correctAnswer;
        public string playerAnswer;
        public string explanation;

        public FeedbackData(string question, string correct, string player, string explanation)
        {
            this.questionText = question;
            this.correctAnswer = correct;
            this.playerAnswer = player;
            this.explanation = explanation;
        }
    }

    void Start()
    {
        // Load the selected language and current level
        string selectedLanguage = PlayerPrefs.GetString("SelectedLanguage", "Java");
        int currentLevel = ProgressManager.Instance.currentLevel; // Get the current level from ProgressManager

        // Get the questions for the selected language and current level
        currentQuestions = QuestionManager.Instance.GetQuestionsForLanguageAndLevel(selectedLanguage, currentLevel);

        // Display the first question
        DisplayNextQuestion();
    }

    // Method to display the next question
    void DisplayNextQuestion()
    {
        if (currentQuestionIndex < currentQuestions.Count)
        {
            Question currentQuestion = currentQuestions[currentQuestionIndex]; // Get the current question

            questionText.text = currentQuestion.questionText; // Set the question text

            // Reset and populate the answer buttons with the possible answers for this question
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].onClick.RemoveAllListeners(); // Clear any existing listeners

                if (i < currentQuestion.possibleAnswers.Length)
                {
                    answerButtons[i].gameObject.SetActive(true); // Ensure the button is active
                    answerButtons[i].GetComponentInChildren<Text>().text = currentQuestion.possibleAnswers[i];

                    // Add listener to each button based on the answer index
                    int answerIndex = i;
                    answerButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex));
                }
                else
                {
                    answerButtons[i].gameObject.SetActive(false); // Hide any unused buttons
                }
            }

            currentQuestionIndex++; // Move to the next question
        }
        else
        {
            Debug.Log("No more questions in this language.");
            // Send feedback list to LevelManager
            levelManager.ShowFeedbackPanel(feedbackList);
        }
    }

    // Method to check the answer selected by the user
    void CheckAnswer(int selectedAnswerIndex)
    {
        Question currentQuestion = currentQuestions[currentQuestionIndex - 1];

        if (selectedAnswerIndex == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct answer!");
            npcHealth.TakeDamage(10f);   // Apply damage to the NPC
        }
        else
        {
            Debug.Log("Wrong answer!");
            playerHealth.TakeDamage(10f); // Apply damage to the player

            // Save feedback for incorrect answers
            feedbackList.Add(new FeedbackData(
                currentQuestion.questionText,
                currentQuestion.possibleAnswers[currentQuestion.correctAnswerIndex],
                currentQuestion.possibleAnswers[selectedAnswerIndex],
                currentQuestion.explanation
            ));
        }

        // Update progress bars based on both the player's and NPC's health percentages
        levelManager.UpdateProgress(playerHealth.GetHealthPercentage(), npcHealth.GetHealthPercentage());

        // Move to the next question after checking the answer
        DisplayNextQuestion();
    }

    // New method to get the feedback list for a specific level
    public List<FeedbackData> GetLevelFeedback(int level)
    {
        // You can filter feedback based on the level if necessary
        // For now, we return all feedback collected so far
        return feedbackList;
    }
}
