using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IgracSkupljeno : MonoBehaviour
{
    public int BrojBaterija { get; private set; }
    public AudioSource audioSource;

    [System.Serializable]
    public class SkupljenoEvent : UnityEvent<IgracSkupljeno> { }

    public SkupljenoEvent NaPokuljenuBateriju;

    public void BaterijeSkupljene()
    {
        BrojBaterija++;
        NaPokuljenuBateriju.Invoke(this);
    }
}

// dodaj score da radi