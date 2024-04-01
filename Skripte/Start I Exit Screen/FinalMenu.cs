using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    public AudioClip ZvukDugmeta; 
    private AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        if (audio == null)
        {
            audio = gameObject.AddComponent<AudioSource>();
        }
    }

    public void IgrajPonovo()
    {
        PlayButtonClickSound();
        SceneManager.LoadScene("LevelPrvi");
    }

    public void IzlazIzIgre()
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
