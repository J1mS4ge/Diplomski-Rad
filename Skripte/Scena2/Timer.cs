using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 180f;

    [SerializeField] TextMeshProUGUI dobrojavanje;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        dobrojavanje.text = currentTime.ToString("F2");

        // Change color based on the countdown value
        if (currentTime <= 120 && currentTime > 60)
        {
            dobrojavanje.color = Color.yellow;
        }
        else if (currentTime <= 60 && currentTime >= 0)
        {
            dobrojavanje.color = Color.red;
        }

        // Load the "Smrt" scene when the countdown reaches 0
        if (currentTime < 0)
        {
            SceneManager.LoadScene("Smrt");
        }
    }
}
