using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public projectileGun aseKoodi;
    public Rigidbody r;
    public BoxCollider col;
    public Transform pelaaja, gunContainer, fpsCam;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull; //varmistaa kantaako jo asetta
    //static pit‰‰ arvon samana kaikissa koodeissa

    // Update is called once per frame
    private void Start()
    {
        //Setup
        if (!equipped)
        {
            aseKoodi.enabled = false;
            r.isKinematic = false;
            col.isTrigger = false;

            Debug.LogFormat("Eqipped pist‰s olla FALSE:" + equipped);
        //    slotFull = false;

        }
        if (equipped)
        {
            aseKoodi.enabled = true;
            r.isKinematic = true;
            col.isTrigger = true;
            
            slotFull = true;
            Debug.LogFormat("Eqipped pits‰ olla True:" + equipped);
        }
    }
    void Update()
    {
        Vector3 etaisyysPelaajaan = pelaaja.position - transform.position;
        if(!equipped && etaisyysPelaajaan.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
        {
            PickUp();
            Debug.LogFormat("suorittaa PickUp metodin");
        }

        if (equipped && Input.GetKeyDown(KeyCode.G)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon achild of the camera and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //laittaa Rigidbody kinematic ja boxCollider trigger
        r.isKinematic = true;
        col.isTrigger = true;

        aseKoodi.enabled = true;
    }
    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Set parent to null
        transform.SetParent(null);

        //laittaa Rigidbody kinematic ja boxCollider trigger
        r.isKinematic = false;
        col.isTrigger = false;

        //gun carries momentum of the player
        r.velocity = pelaaja.GetComponent<Rigidbody>().velocity;

        //AddForce 
        r.AddForce(fpsCam.forward * dropForwardForce, ForceMode.Impulse);
        r.AddForce(fpsCam.up * dropUpwardForce, ForceMode.Impulse);

        //add random rotation
        float random = Random.Range(-1f, 1f);
        r.AddTorque(new Vector3(random, random, random) * 10);


        aseKoodi.enabled = false;
    }
   

    
}
