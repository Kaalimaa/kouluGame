using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihollinen : MonoBehaviour
{
    public int Hp =100;
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp < 0)
            Destroy(gameObject);
    }
    
}
