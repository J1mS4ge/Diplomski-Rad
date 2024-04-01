using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 25f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            IgracHP playerHealth = other.GetComponent<IgracHP>(); 
            if (playerHealth != null)
            {
                playerHealth.PrimljenDMG(damageAmount); 
            }
        }
    }
}
