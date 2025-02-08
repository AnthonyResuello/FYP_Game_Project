using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagePopUp : MonoBehaviour
{
    public GameObject damageTextPrefab; // Reference to the prefab of the damage text
    public Canvas canvas; // Reference to the Canvas in the scene

    public void ShowDamage(float damageAmount, Vector3 position)
    {
        // Instantiate the damage text prefab
        GameObject damageText = Instantiate(damageTextPrefab, canvas.transform);

        // Set the text to display the damage amount with a minus sign
        Text text = damageText.GetComponent<Text>();
        text.text = "-" + damageAmount.ToString();  // Add "-" before the damage value

        // Position the damage text above the character's position
        damageText.transform.position = position;

        // Start the fade and move-up animation
        StartCoroutine(FadeAndMoveUp(damageText, text));
    }


    private IEnumerator FadeAndMoveUp(GameObject damageText, Text text)
    {
        float duration = 1.5f; // Duration of the fade and move-up effect
        float elapsedTime = 0f;

        // Initial position
        Vector3 startPosition = damageText.transform.position;

        // Target position (move upwards)
        Vector3 targetPosition = startPosition + new Vector3(0, 150, 0);

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

        // Destroy the damage text object after the animation is complete
        Destroy(damageText);
    }
}
