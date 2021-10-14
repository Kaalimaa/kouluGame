using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Jahtaa : MonoBehaviour
{
   // public BulletParticle bulletPart;

    private NavMeshAgent agent;
    public Transform kohde;
    //public Animator anima;
    public int huomaaEtaisyydella = 25;
    private void Start()
    {
     //   anima = GetComponent<Animator>();
        agent = this.GetComponent<NavMeshAgent>();
     //   bulletPart = FindObjectOfType<BulletParticle>();
        //lähtee kohti kohdetta
       // agent.SetDestination(kohde.position);
    }
   

    void Update()
    {
        if(Vector3.Distance(kohde.position, this.transform.position) < huomaaEtaisyydella)
        {
            Vector3 suunta = kohde.position - this.transform.position;
            suunta.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(suunta), 0.1f);
            
            if(suunta.magnitude > 2.5f)
            {
                this.transform.Translate(0, 0, 3f * Time.deltaTime);
                //anima.SetBool("isWalking", true);
                //anima.SetBool("isAttacking", false);
            }
            //else anima.SetBool("isWalking", false);
            //anima.SetBool("isAttacking", true);

        }
       //else anima.SetBool("isWalking", true);
                
       
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            GetComponent<Renderer>().material.color = GetRandomColor();
        }
        if (collision.collider.tag == "orb")
        {
            GetComponent<Renderer>().material.color = GetRandomColor();
        }
    }
    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.TryGetComponent(out BulletParticle bullet))
    //    {
    //       // vihu.TakeDamage(damage);
    //    }
    //}
    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }
}
