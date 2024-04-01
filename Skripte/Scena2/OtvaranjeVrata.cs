using UnityEngine;

public class DestroyWhenBatteryFull : MonoBehaviour
{
    private IgracSkupljeno igracSkupljeno;

    void Start()
    {
        // Find the IgracSkupljeno component in the scene
        igracSkupljeno = FindObjectOfType<IgracSkupljeno>();

        if (igracSkupljeno == null)
        {
            Debug.LogError("IgracSkupljeno componenta nema!");
        }
        else
        {
            
            igracSkupljeno.NaPokuljenuBateriju.AddListener(OnBatteryCollected);
        }
    }

    private void OnDestroy()
    {
        
        if (igracSkupljeno != null)
        {
            igracSkupljeno.NaPokuljenuBateriju.RemoveListener(OnBatteryCollected);
        }
    }

    private void OnBatteryCollected(IgracSkupljeno igracSkupljeno)
    {
        if (igracSkupljeno.BrojBaterija >= 10)
        {
           
            Destroy(gameObject);
        }
    }
}
