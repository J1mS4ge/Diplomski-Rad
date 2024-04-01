using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distanca = 3f;
    [SerializeField]
    private LayerMask mask;
    private IgracUI playerUI;
    private InputMenadzer inputMenadzer;
    // Start is called before the first frame update
    public RaycastHit hitInfo;
    void Start()
    {
        cam = GetComponent<IgracGleda>().kamera;
        playerUI = GetComponent<IgracUI>();
        inputMenadzer = GetComponent<InputMenadzer>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distanca);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distanca, mask))
            {
                if(hitInfo.collider.GetComponent<Interactible>() != null)
                 {
                    Interactible interaktivna = hitInfo.collider.GetComponent<Interactible>();
                    playerUI.UpdateText(interaktivna.promptMessage);

                    if (inputMenadzer.Hodanje.Interakcija.triggered)
                        {   
                            
                            interaktivna.BaseInteract();
                        }
                 }
            }
    }
}
