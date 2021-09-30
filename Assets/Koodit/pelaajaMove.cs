using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelaajaMove : MonoBehaviour
{
    public Rigidbody r;
    public float maxspeed;
    public float jumpForce;
    public bool canJump;
  
    private void FixedUpdate()
    {
        UpdateHorizontalMove();
        ClampOnMaxSpeed();
        Jump();
    }

    // liikkuminen eteen ja taaksepäin
    void UpdateHorizontalMove()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
            if (r.velocity.z < maxspeed)
            {
                r.AddForce(r.transform.forward * maxspeed, ForceMode.VelocityChange);
                
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (r.velocity.z > -maxspeed)
            {
                r.AddForce(r.transform.forward * -maxspeed, ForceMode.VelocityChange);
            }
        }
    }


    //Voiman pysäytys
    void ClampOnMaxSpeed()
    {
        if (!Input.GetKey(KeyCode.W))
        {
            if (r.velocity.z > 0f)
            {
                r.AddForce(r.transform.forward * -r.velocity.z, ForceMode.VelocityChange);
            }
        }
        if (!Input.GetKey(KeyCode.S))
        {
            if (r.velocity.z < 0f)
            {
                r.AddForce(r.transform.forward * -r.velocity.z, ForceMode.VelocityChange);
            }
        }



        if (r.velocity.z > maxspeed)
        {
            r.AddForce(r.transform.forward * -(r.velocity.z - maxspeed), ForceMode.VelocityChange);
        }
        if (r.velocity.z < -maxspeed)
        {
            r.AddForce(r.transform.forward * -(r.velocity.z + maxspeed), ForceMode.VelocityChange);
        }
    }
    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            r.AddForce(r.transform.up * jumpForce);
            canJump = false;
        }
        else
        {
            canJump = true;
        }
    }

}
