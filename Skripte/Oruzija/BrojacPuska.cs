using UnityEngine;
using TMPro;

public class BrojacPuska : MonoBehaviour
{
    public TextMeshProUGUI municijaText; // Reference to the TextMeshProUGUI component
    public Puska puska; // Reference to the Puska script

    void Start()
    {
        // Get the TextMeshProUGUI component attached to the UI GameObject
        municijaText = GetComponent<TextMeshProUGUI>();

        // Check if Puska is active and set the reference accordingly
        if (puska.enabled)
        {
            UpdateMunicijaText(puska.trenutnaMunicija);
        }
    }

    void Update()
    {
        // Check if Puska is active and update the municijaText accordingly
        if (puska.enabled)
        {
            UpdateMunicijaText(puska.trenutnaMunicija);
        }
    }

    // Update the municijaText with the provided municijaCount
    void UpdateMunicijaText(int municijaCount)
    {
        municijaText.text = "[" + municijaCount.ToString() + " / 30 ]";
    }
}
