using UnityEngine;
using System.Collections;

public class Puska : MonoBehaviour
{
    public float dmg = 13f;
    public float daljina = 100f;
    public float udarSila = 30f;
    public float brzinaPucanja = 15f;

    public int maxMunicija = 30;
    public int trenutnaMunicija;
    public float VremePunjnenje = 1f;
    private bool Puni = false;

    public Animator animator;
    public Camera camera;
    public ParticleSystem bljesak;

    private AudioSource audio; // Removed 'AudioSource' to avoid confusion with Unity's 'AudioSource'
    public AudioClip buttonClickSound; // Added AudioClip for the button click sound
    private float VremePucanja = 0f;

    void Start()
    {
        if (trenutnaMunicija == -1)
            trenutnaMunicija = maxMunicija;

        audio = GetComponent<AudioSource>();
        if (audio == null)
        {
            audio = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnEnable()
    {
        Puni = false;
        animator.SetBool("Punjenje", false);
    }

    void Update()
    {
        if (Puni)
            return;

        if (trenutnaMunicija <= 0)
        {
            StartCoroutine(Punjnenje());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= VremePucanja)
        {
            VremePucanja = Time.time + 4f / brzinaPucanja;
            Pucanje();
            PlayButtonClickSound();
        }

        // Check if the "R" key is pressed to trigger reloading
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Punjnenje());
        }
    }

    void Pucanje()
    {
        trenutnaMunicija--;
        bljesak.Play();

        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, daljina))
        {
            Debug.Log(hit.transform.name);
            Meta meta = hit.transform.GetComponent<Meta>();
            if (meta != null)
            {
                meta.TakeDMG(dmg);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * udarSila);
            }
        }
    }

    IEnumerator Punjnenje()
    {
        Puni = true;
        animator.SetBool("Punjenje", true);

        Debug.Log("Punjnenje....");
        yield return new WaitForSeconds(VremePunjnenje);

        animator.SetBool("Punjenje", false);
        trenutnaMunicija = maxMunicija;
        Puni = false;
    }

    void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audio.PlayOneShot(buttonClickSound);
        }
        else
        {
            Debug.LogWarning("No sound effect assigned to the buttonClickSound variable.");
        }
    }
}
