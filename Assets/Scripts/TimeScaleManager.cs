using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleManager : MonoBehaviour
{
    // Constants for normal and slow-motion that cna be changed in the inspector
    public float slowTimeScale = 0.1f;
    public float normalTimeScale = 1.0f;

    // Reference right hand
    public Transform rightHandReference;

    // Threshold for detecting hand movement
    public float movementThreshold = 0.01f;

    // Previous position of the right hand
    private Vector3 previousHandPosition;

    void Start()
    {
        // Initialize the previous position to the current position at the start
        if (rightHandReference != null)
        {
            previousHandPosition = rightHandReference.position;
        }
    }

    void Update()
    {
        // Ensure the hand is assigned
        if (rightHandReference != null)
        {
            // Calculate the distance moved by the hand since the last frame
            float distanceMoved = Vector3.Distance(rightHandReference.position, previousHandPosition);

            // Update the previous hand position for the next frame
            previousHandPosition = rightHandReference.position;

            // If the movement is above the threshold, set time to normal; otherwise, slow it down
            if (distanceMoved > movementThreshold)
            {
                // Set time to normal
                Time.timeScale = normalTimeScale;
            }
            else
            {
                // Slow down time
                Time.timeScale = slowTimeScale;
            }

            // To keep physics calculations stable when time is slowed down
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}