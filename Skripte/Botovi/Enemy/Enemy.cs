using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{   
    private StateMachine stateMasina;
    private NavMeshAgent agent;
    public NavMeshAgent Agent{ get => agent;}
    [SerializeField]
    private string trenutnoStanje;
    public Path put;
    private GameObject igrac;
    public GameObject Igrac {get => igrac;}
    [Header("FOV Bota")]
    public float sightDistance = 20f;
    public float FOV = 80;
    [Header("Oruzije")]
    public Transform cev;
    [Range(0.1f, 10f)]
    public float brzinaPucanja;
    // Start is called before the first frame update
    void Start()
    {
       stateMasina = GetComponent<StateMachine>();
       agent = GetComponent<NavMeshAgent>();
       stateMasina.Initialise(); 
       igrac = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MozeVidetiIgraca();
        trenutnoStanje = stateMasina.aktivnoStanje.ToString();
    }
    public bool MozeVidetiIgraca()
{
    if (igrac != null)
    {
        
        Vector3 targetDirection = igrac.transform.position - transform.position;

       
        float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);

        
        if (angleToPlayer <= FOV / 2f) 
        {
            
            Ray ray = new Ray(transform.position, targetDirection);

            
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, sightDistance))
            {
                if (hitInfo.transform.gameObject == igrac)
                {
                    
                    return true;
                }
            }
        }
    }

    
    return false;
}

}
