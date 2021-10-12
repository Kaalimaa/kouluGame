using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelaajanHauliLuoti : MonoBehaviour
{
    // Start is called before the first frame update
    public int damage = 10;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<EnemyAI>().TakeDamage(damage);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
