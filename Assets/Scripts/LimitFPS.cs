using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    public int targetFPS = 60; // Set the desired FPS here

    void Start()
    {
        // Set the target frame rate once when the game starts
        Application.targetFrameRate = targetFPS;
    }
}
