using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napadanje : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnCollisionEnter( Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
        Debug.Log("Upucan");
        hitTransform.GetComponent<IgracHP>().PrimljenDMG(10);

    }
    Destroy(gameObject);
    }
}
