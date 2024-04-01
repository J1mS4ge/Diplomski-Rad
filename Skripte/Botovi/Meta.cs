using UnityEngine;

public class Meta : MonoBehaviour
{
    public float HP = 50f;
    public ParticleSystem deathEffect;

    public void TakeDMG(float amount)
    {
        HP -= amount;
        if (HP <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Check if a particle effect is assigned
        if (deathEffect != null)
        {
            // Instantiate the particle effect at the current position
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Destroy the game object
        Destroy(gameObject);
    }

    public void Unisti()
    {
        Destroy(gameObject);
    }
}
