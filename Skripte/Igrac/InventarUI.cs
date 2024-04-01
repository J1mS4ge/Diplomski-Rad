using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventarUI : MonoBehaviour
{
    private TextMeshProUGUI baterijaTxt;

    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color belowMaxColor = Color.red;
    [SerializeField] private Color maxColor = Color.green;
    [SerializeField] private AudioClip soundEffect;
    private AudioSource audioSource;

    void Start()
    {
        baterijaTxt = GetComponent<TextMeshProUGUI>();
        audioSource = GetComponent<AudioSource>();
    }

    public void UpdateBaterijaTxt(IgracSkupljeno igracSkupljeno)
    {
        baterijaTxt.text = igracSkupljeno.BrojBaterija.ToString();

        // Check if BrojBaterija reaches 10
        if (igracSkupljeno.BrojBaterija >= 10)
        {
            // Change text color to green
            baterijaTxt.color = maxColor;

            // Play sound effect
            if (soundEffect != null && audioSource != null)
            {
                audioSource.PlayOneShot(soundEffect);
            }
        }
        else
        {
            // Change text color to red
            baterijaTxt.color = belowMaxColor;
        }
    }
}
