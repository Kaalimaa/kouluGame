using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelaajahit : MonoBehaviour
{
    public int maxH=100;
        public int currentHealth;
    public HP hp;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxH;
        hp.SetMaxHealth(maxH);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            TakeDamage(-10);
        }
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hp.SetHealth(currentHealth);
    }
}
