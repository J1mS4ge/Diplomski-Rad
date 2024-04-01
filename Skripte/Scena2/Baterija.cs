using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baterija : MonoBehaviour
{
    [SerializeField]
    private AudioClip collectedSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.spatialBlend = 1f; // 3D sound
    }

    private void OnTriggerEnter(Collider other)
    {
        IgracSkupljeno igracSkupljeno = other.GetComponent<IgracSkupljeno>();
        if (igracSkupljeno != null)
        {
            igracSkupljeno.BaterijeSkupljene();

            if (collectedSound != null)
            {
                audioSource.PlayOneShot(collectedSound);
                StartCoroutine(DeactivateObjectWithDelay(collectedSound.length)); // Use sound length as delay
            }
        }
    }

    private IEnumerator DeactivateObjectWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
