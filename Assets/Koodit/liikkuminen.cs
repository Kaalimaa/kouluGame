using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liikkuminen : MonoBehaviour
{




    private float MoveX, MoveZ;
    //sd is movement speed
    public float sd;
    public float JumpForce;
    public bool IsGrounded;
    public Rigidbody rb;
 
    
    
   // private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }
    
    
   
    void FixedUpdate()
    {
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");
        rb.MovePosition(transform.position + (transform.forward * MoveZ * sd / 2) + (transform.right * MoveX * sd / 2));
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.MovePosition(transform.position + (transform.forward * MoveZ * sd * Time.deltaTime) + (transform.right * MoveX * sd));
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = new Vector3(0f, JumpForce, 0f);
        }
    }

    void OnCollisionStay()
    {
        IsGrounded = true;
    }
    void OnCollisionExit()
    {
        IsGrounded = false;
    }
}

