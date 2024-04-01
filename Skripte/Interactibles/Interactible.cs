using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    // Start is called before the first frame update
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public void BaseInteract()
    {
       
        if (useEvents)
            GetComponent<EventInterakcija>().NaInterakciju.Invoke();
         Interact();
    }
    protected virtual void Interact()
    {
        
    }
}
