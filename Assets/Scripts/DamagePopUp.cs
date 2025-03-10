using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagePopUp : MonoBehaviour
{
    public GameObject damageTextPrefab; // Damage Text prefab 
    public Canvas canvas; 


    public void ShowDamage(float damageAmount, Vector3 position)
    {
       
        GameObject damageText = Instantiate(damageTextPrefab, canvas.transform);  // Instantiate the damage text prefab

        // Display the damage taken 
        Text text = damageText.GetComponent<Text>();
        text.text = "-" + damageAmount.ToString();  

        // Set position of the damage text to the Characters
        damageText.transform.position = position;

        // Play the damage popup text animation 
        StartCoroutine(FadeAndMoveUp(damageText, text));
    }


// Coroutine for the damage pop-up animation effect.
    private IEnumerator FadeAndMoveUp(GameObject damageText, Text text)
    {
        float duration = 1.5f; // Duration of the fade and move-up effect
        float elapsedTime = 0f;
    
        Vector3 startPosition = damageText.transform.position; // Start position

        Vector3 targetPosition = startPosition + new Vector3(0, 150, 0);  // Move text upwards

        Color startColor = text.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;

            // Move the text upwards
            damageText.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / duration);

            // Fade the text out
            text.color = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0), elapsedTime / duration);

            yield return null;
        }
        Destroy(damageText); // Destroy the game object
    }
}
