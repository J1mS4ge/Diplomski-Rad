using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour

{
    public BaseState aktivnoStanje;
    
    
    public void Initialise()
    {
        
        ChangeState(new PatrolState());
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (aktivnoStanje != null)
        {
            aktivnoStanje.Perform();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if (aktivnoStanje != null)
        {
            aktivnoStanje.Exit();
        }

        aktivnoStanje = newState;

        if (aktivnoStanje != null)
        {
            aktivnoStanje.stateMasina = this;
            aktivnoStanje.enemy = GetComponent<Enemy>();
            aktivnoStanje.Enter();
        }
    }
}
