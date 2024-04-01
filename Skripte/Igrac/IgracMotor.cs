using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracMotor : MonoBehaviour
{
    private CharacterController kontroler;
    private Vector3 IgracBrzina;
    public float brzina = 5f;
    public float SkokVisina = 1.2f;
    private bool isGrounded;
    public float gravitacija = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        kontroler = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = kontroler.isGrounded;
    }
    public void ProcesKretanje(Vector2 input)
    {
        Vector3 pokretSmer = Vector3.zero;
        pokretSmer.x = input.x;
        pokretSmer.z = input.y;
        kontroler.Move(transform.TransformDirection(pokretSmer) * brzina * Time.deltaTime);
        IgracBrzina.y += gravitacija * Time.deltaTime;
        if (isGrounded && IgracBrzina.y < 0)
            IgracBrzina.y = -2f;
        kontroler.Move(IgracBrzina * Time.deltaTime);
        
    }

    public void Skok()
     {
        if (isGrounded)
        {
            IgracBrzina.y = Mathf.Sqrt(SkokVisina * -3.0f * gravitacija);
        }
     } 
}
