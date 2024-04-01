using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracGleda : MonoBehaviour
{
    public Camera kamera;
    private float xRotation = 0f;
    public float xSensitivity = 20f;
    public float ySensitivity = 20f;
    public void ProcesGleda(Vector2 input) 
    {
        float misX = input.x;
        float misY = input.y;
        //racunanje rotacije kamere
        xRotation -= (misY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);
        kamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        // rotacija igraca
        transform.Rotate(Vector3.up * (misX * Time.deltaTime) * xSensitivity);
    }
   
}