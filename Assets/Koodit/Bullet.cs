using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject spark;
    public ParticleSystem particleSys;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("osuma");
            Destroy(gameObject, 0.5f);
        }
        if(collision.collider.tag == "Jugebox")
        {
            FindObjectOfType<AudioManager>().Play("taustamusa");
            Destroy(gameObject, 0.5f);
        }
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().Play("osuma");
            Destroy(gameObject, 0.5f);
        }
        if (collision.collider.tag == "Pelaaja")
        {
            
            Destroy(gameObject, 0.3f);
        }

      

        //if (collision.collider.tag == "Enemy")
        //{
        //    if (collision.TryGetComponent(out EnemyAI vihu))
        //    {
        //        vihu.TakeDamage(damage);
        //    }

        //    FindObjectOfType<AudioManager>().Play("uhh");

        //    Destroy(gameObject, 0.3f);
        //}
       
        if (collision.collider.tag == "Fireball")
        {
            FindObjectOfType<AudioManager>().Play("uhh");
            Destroy(gameObject, 0.3f);
        }

    }
}
