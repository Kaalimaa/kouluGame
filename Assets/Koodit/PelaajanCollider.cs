using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanCollider : MonoBehaviour
{
   // public GameObject osumaEffect;

    public void OnCollisionEnter(Collision collision)
    {
       if(collision.collider.tag == "Fireball")
        {
            //   Instantiate(osumaEffect, transform.position, transform.rotation);
            //   GameObject.instance.Endgame();
            //  Destroy(gameObject);

            FindObjectOfType<AudioManager>().Play("uhh");

        }
    }
}
