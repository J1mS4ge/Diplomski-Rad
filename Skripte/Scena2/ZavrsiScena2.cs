using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZavrsiScena2 : MonoBehaviour
{
    [SerializeField] private GameObject triggerObject;
    private IgracSkupljeno igracSkupljeno;

    void Start()
    {
        // Find the IgracSkupljeno component in the scene
        igracSkupljeno = FindObjectOfType<IgracSkupljeno>();

        if (igracSkupljeno == null)
        {
            Debug.LogError("IgracSkupljeno component not found in the scene!");
        }
        else
        {
            // Subscribe to the event
            igracSkupljeno.NaPokuljenuBateriju.AddListener(OnBatteryCollected);
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event
        if (igracSkupljeno != null)
        {
            igracSkupljeno.NaPokuljenuBateriju.RemoveListener(OnBatteryCollected);
        }
    }

    private void OnBatteryCollected(IgracSkupljeno igracSkupljeno)
    {
        Debug.Log("Battery collected. BrojBaterija: " + igracSkupljeno.BrojBaterija);

        if (igracSkupljeno.BrojBaterija >= 10)
        {
            Debug.Log("Initiating scene change from OnBatteryCollected.");
            // Check if triggerObject is set
            if (triggerObject != null)
            {
                Debug.Log("Triggering scene change.");
                // Simulate a trigger enter event to initiate scene change
                OnTriggerEntered(triggerObject.GetComponent<Collider>());
            }
            else
            {
                Debug.LogError("Trigger object not set. Please assign a GameObject in the Unity Editor.");
            }
        }
    }

    private void OnTriggerEntered(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone.");

            // Check if the player's BrojBaterija is >= 10
            IgracSkupljeno playerIgracSkupljeno = other.GetComponent<IgracSkupljeno>();
            if (playerIgracSkupljeno != null && playerIgracSkupljeno.BrojBaterija >= 10)
            {
                Debug.Log("Player has enough batteries. Initiating scene change.");
                ChangeScene();
            }
        }
    }

    private void ChangeScene()
    {
        Debug.Log("Changing scene...");
        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
