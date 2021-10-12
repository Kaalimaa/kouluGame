using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public Transform leijumisPiste;
    public float laukaisuNopeus;

    GameObject kohde;
    Rigidbody kohteenRig;

    public float aseenKantama=12f;

    bool vet‰‰;
    bool laukaisee;


    public Camera cam;
  
    void Start()
    {
        cam = Camera.main;
    }

   
    void Update()
    {
        // veto nappi
        if (Input.GetKeyDown(KeyCode.R))
            vet‰‰ = true;
        else if (Input.GetKeyUp(KeyCode.R))
            vet‰‰ = false;
        //heitt‰‰ oikealla hiiren napilla
        if (vet‰‰)
        {
            if (Input.GetButtonDown("Fire2"))
                laukaisee = true;
        }
            
    }
    private void FixedUpdate()
    {
        if (vet‰‰)
        {
            Vet‰‰();
        }
        else if (!vet‰‰)
        {
            Vapauta();
        }
        if (laukaisee)
            Heita();
        
    }

    //metodi joka vet‰‰ esineit‰
    private void Vet‰‰()
    {
        RaycastHit hit;
        if(kohde == null)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, aseenKantama))
            {
                if (hit.transform.tag == "VoiOttaa")
              { 
                kohde = hit.transform.gameObject;
                kohteenRig = kohde.GetComponent<Rigidbody>();
                kohde.transform.position = Vector3.MoveTowards(kohde.transform.position, leijumisPiste.position, 0.3f);
                kohteenRig.useGravity = false;
              }
            }


        }
        else
        {
            kohde.transform.position = Vector3.MoveTowards(kohde.transform.position, leijumisPiste.position, 0.3f);
        }
    }
    //metodi joka vapauttaa objectin
    private void Vapauta()
    {
        if(kohde != null)
        {
            kohteenRig.useGravity = true;
            kohde = null;
        }
     
    }
    private void Heita()
    {
        if (kohteenRig != null)
        {
            kohteenRig.useGravity = true;
            kohteenRig.AddForce(leijumisPiste.transform.forward * laukaisuNopeus, ForceMode.Impulse);
            kohde = null;
            laukaisee = false;
        }

    }
}
