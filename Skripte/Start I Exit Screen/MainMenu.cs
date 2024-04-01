using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip ZvukDugmeta; // Dodeli zvuk u Unity Editor
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        if (audio == null)
        {
            audio = gameObject.AddComponent<AudioSource>();
        }
    }

    public void IgrajIgru()
    {
        PlayButtonClickSound();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Izadji()
    {
        PlayButtonClickSound();

        Debug.Log("IZLAZ");
        Application.Quit();
    }

    private void PlayButtonClickSound()
    {
        if (ZvukDugmeta != null)
        {
            audio.PlayOneShot(ZvukDugmeta);
        }
        else
        {
            Debug.LogWarning("Fali audio fajl.");
        }
    }
}
