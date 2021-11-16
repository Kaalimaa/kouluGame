using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liikkumisAnimaatio : MonoBehaviour
{
    Animator juoksuAnim;

    // Start is called before the first frame update
    void Start()
    {
        juoksuAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            juoksuAnim.SetTrigger("isRunning");
          
        }
       else if (Input.GetKey(KeyCode.L))
        {
            juoksuAnim.SetTrigger("isR" );
            
        }
        else if (Input.GetKey(KeyCode.J))
        {
            juoksuAnim.SetTrigger("isL");
           
        }
         else
        {
            
            juoksuAnim.SetTrigger("idle");
        }
    }

    private void FixedUpdate()
    {
        
    }
}
