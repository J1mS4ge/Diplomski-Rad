using UnityEngine;
using TMPro;

public class BrojacPistolj : MonoBehaviour
{
    public TextMeshProUGUI municijaText; // Reference to the TextMeshProUGUI component
    public Pistolj pistolj; // Reference to the Pistolj script

    void Start()
    {
        // Get the TextMeshProUGUI component attached to the UI GameObject
        municijaText = GetComponent<TextMeshProUGUI>();

        // Check if Pistolj is active and set the reference accordingly
        if (pistolj.enabled)
        {
            UpdateMunicijaText(pistolj.trenutnaMunicija);
        }
    }

    void Update()
    {
        // Check if Pistolj is active and update the municijaText accordingly
        if (pistolj.enabled)
        {
            UpdateMunicijaText(pistolj.trenutnaMunicija);
        }
    }

    // Update the municijaText with the provided municijaCount
    void UpdateMunicijaText(int municijaCount)
    {
        municijaText.text = "[" + municijaCount.ToString() + " / 10 ]";
    }
}
