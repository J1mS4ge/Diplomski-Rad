using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputMenadzer : MonoBehaviour
{
    private InputIgrac InputIgrac;
    public InputIgrac.HodanjeActions Hodanje;
    private IgracMotor motor;
    private IgracGleda Gleda;
    // Start is called before the first frame update
    void Awake()
    {
        InputIgrac = new InputIgrac();
        Hodanje = InputIgrac.Hodanje;
        motor = GetComponent<IgracMotor>();
        Hodanje.Skok.performed += ctx => motor.Skok();
        Gleda = GetComponent<IgracGleda>();
    }

    // Update is called once per frame
     void FixedUpdate()
    {
        //pokretanje uz pomoc move action//
        motor.ProcesKretanje(Hodanje.Pokret.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        Gleda.ProcesGleda(Hodanje.Gledanje.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        Hodanje.Enable();
    }
    private void OnDisable()
 {  
    Hodanje.Disable();
 }
}
