using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public GameObject spark;
    public ParticleSystem particleSys;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            particleSys.Play();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        int events = particleSys.GetCollisionEvents(other, colEvents);
        Debug.Log("Hit");
        for ( int i = 0; i< events; i++)
        {
            Instantiate(spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }
    }
}
