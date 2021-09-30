using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("osuma");
        }
        if(collision.collider.tag == "Jugebox")
        {
            FindObjectOfType<AudioManager>().Play("taustamusa");
        }
    }
}
