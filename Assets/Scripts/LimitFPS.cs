using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int targetFPS = 60; // Set the desired FPS here

    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = targetFPS;
        // Optional: Adjust the quality settings to make sure VSync is off

    }

    void Update()
    {
        // Dynamically limit the FPS (if you want to adjust in real-time)
        if (Application.targetFrameRate != targetFPS)
        {
            Application.targetFrameRate = targetFPS;
        }
    }
}
