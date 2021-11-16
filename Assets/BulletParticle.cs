using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public int damage = 10;
    public GameObject spark;
    public ParticleSystem particleSys;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();
    AudioManager audioManager;

    private void Start()
    {
        audioManager =  FindObjectOfType<AudioManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
          //  FindObjectOfType<AudioManager>();
            particleSys.Play();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        audioManager.Play("orbHit");
        int events = particleSys.GetCollisionEvents(other, colEvents);
        Debug.Log("Hit");
        for ( int i = 0; i< events; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }
        if(other.TryGetComponent(out EnemyAI vihu))
        {
            vihu.TakeDamage(damage);
            vihu.GetComponent<Renderer>().material.color = GetRandomColor();
           

            audioManager.Play("uhh");
            
        }
       


    }
    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

}
