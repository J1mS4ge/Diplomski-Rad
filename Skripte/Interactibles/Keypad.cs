using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactible
{
    [SerializeField] private GameObject vrata;
    [SerializeField] private Renderer keypadRenderer;
    [SerializeField] private Color activeColor = Color.green;
    [SerializeField] private Color inactiveColor = Color.red;
    [SerializeField] private AudioClip activationSound; // Assign the audio clip in the Unity Editor

    private bool OtvorenaVrata;
    private bool isActive  = false;
    private AudioSource audioSource;

    private void Start()
    {
        if (keypadRenderer == null)
        {
            Debug.LogError("Keypad Renderer is not assigned!");
            return;
        }

        if (vrata == null)
        {
            Debug.LogError("Vrata GameObject is not assigned!");
            return;
        }

        if (keypadRenderer.material == null)
        {
            Debug.LogError("Keypad Renderer does not have a Material!");
            return;
        }

        keypadRenderer.material.color = inactiveColor; // Set initial color

        // Get the AudioSource component attached to the Keypad GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // If AudioSource component is not found, add it
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    protected override void Interact()
    {
        if (vrata == null)
        {
            Debug.LogError("Vrata GameObject is not assigned!");
            return;
        }

        OtvorenaVrata = !OtvorenaVrata;
        vrata.GetComponent<Animator>().SetBool("OtvorenoJe", OtvorenaVrata);

        // Toggle color
        isActive = !isActive;
        keypadRenderer.material.color = isActive ? activeColor : inactiveColor;

        // Play activation sound
        if (activationSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activationSound);
        }

        Debug.Log("Keypad Interacted!");
    }
}
