using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    //r‰j‰hdys
    public float cubeSize = 0.5f;
    public int cubeInRow = 5;
    public float rajahdysAlue = 5f;
    public float rajahdysVoima = 500f;
    public float rajahdysVoimaYlos = 100f;


    [SerializeField] EnemyAI EnemyAI;
    [SerializeField] GameObject HealthBar;
    public GameObject spark;
  //  public ParticleSystem particleSys;
   
    private HP healthBarCode;
    private int health = 100;
    private void Start()
    {
      //  EnemyAI = GetComponent<EnemyAI>();
       EnemyAI = FindObjectOfType<EnemyAI>().GetComponent<EnemyAI>();
        healthBarCode = GetComponent<HP>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            FindObjectOfType<AudioManager>().Play("osuma");
            Destroy(gameObject, 0.01f);
            Explode();
        }
        if(collision.collider.tag == "Jugebox")
        {
            FindObjectOfType<AudioManager>().Play("taustamusa");
            Destroy(gameObject, 0.01f);
        }
        if (collision.collider.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().Play("maa");
            Destroy(gameObject);
            Explode();
        }
        if (collision.collider.tag == "Pelaaja")
        {
            
            Destroy(gameObject, 0.01f);
        }
        if (collision.collider.tag == "Enemy")
        {
            FindObjectOfType<AudioManager>().Play("osuma");
          EnemyAI.TakeDamage(35);
            Explode();
            
          //  health -= 10;
          //  healthBarCode.SetHealth(health);

            Destroy(gameObject, 0.1f);
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
    private void Explode()
    {
        gameObject.SetActive(false); //laittaa pelaaja objectin pois p‰‰lt‰

        //looppaa 3 kertaa luodakseen 5x5x5 palaa x, y, z coordinaatit
        for (int x = 0; x < cubeInRow; x++)
        {
            for (int y = 0; y < cubeInRow; y++)
            {
                for (int z = 0; z < cubeInRow; z++)
                {
                     LuoPalanen(x, y, z);

                    
                }
            }
        }


        // r‰j‰hdys positio
        Vector3 rajahdysPositio = transform.position;

        // ker‰‰ colliderit r‰j‰dys alueelta
        Collider[] colliders = Physics.OverlapSphere(rajahdysPositio, rajahdysAlue);
        //Lis‰‰ r‰j‰hdys voiman jokaiseen collideriin OverlapSpheren sis‰ll‰
        foreach (Collider kappale in colliders)
        {
            Rigidbody kappaleRB = kappale.GetComponent<Rigidbody>();
            if (kappaleRB != null) //jos rigidbody on olemassa r‰j‰hd‰
            {
                kappaleRB.AddExplosionForce(rajahdysVoima, rajahdysPositio, rajahdysAlue, rajahdysVoimaYlos);
            }
        }
        
    }
    void LuoPalanen(int x, int y, int z)
    {
        // luo palan
        GameObject pala;
        pala = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //asettaa position ja size
        pala.transform.position = transform.position + new Vector3(x * cubeSize, y * cubeSize, z * cubeSize);
        pala.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);
        Destroy(pala, 10f);

        //lis‰t‰‰n rigidbody palasiin
        pala.AddComponent<Rigidbody>();


    }


    

}
