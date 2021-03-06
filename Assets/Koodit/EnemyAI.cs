using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int maxH = 100;
    public int nytH;
    public HP hp;

    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //partoling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
    {
        nytH = maxH;
        hp.SetMaxHealth(maxH);
    }

    private void Awake()
    {
        player = GameObject.Find("PELAAJA").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        //Cheak for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

       
    }
  
   

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
          agent.SetDestination(walkPoint);

        //et?syys k?vely pisteeseen
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //k?vely piste saavutettu
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

    }
    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    
    private void AttackPlayer()
    {
        //varmistaa ett? vihollinen ei liiku
        agent.SetDestination(transform.position);

        //vihollinen katsoo pelaajaa p?in
        transform.LookAt(player);
        if (!alreadyAttacked)
        {//Attack koodi tulee t?h?n
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 38f, ForceMode.Impulse);
            rb.AddForce(transform.up * 1f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    public void TakeDamage(int damage)
    {
        nytH -= damage;
        hp.SetHealth(nytH);
        if (nytH <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
        
    }
    private void DestroyEnemy()
    {
        
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "bullet")
        {
            GetComponent<Renderer>().material.color = GetRandomColor();
        }
      
        
    }
    public void RandomColorM()
    {
        GetRandomColor();
    }

    private Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

}
