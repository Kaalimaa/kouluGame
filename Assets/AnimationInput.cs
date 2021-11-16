using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationInput : MonoBehaviour
{
    Animator anim;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalkB");
        isRunningHash = Animator.StringToHash("isRunB");
    }

    // Update is called once per frame
    void Update()
    {
        bool isJuoksee = anim.GetBool(isRunningHash);
        bool isKavelee = anim.GetBool(isWalkingHash);
        bool eteenpainPainettu = Input.GetKey(KeyCode.W);
        bool juoksePainettu = Input.GetKey(KeyCode.LeftShift);

        if (isKavelee && !eteenpainPainettu)
        {
            anim.SetBool(isWalkingHash, false);

        }
        if (!isKavelee && eteenpainPainettu)
        {
            anim.SetBool(isWalkingHash, true);

        }
        if (isKavelee && !eteenpainPainettu) //lopeta kävely
        {
            anim.SetBool(isRunningHash, false);

        }
         if(!isJuoksee && ( eteenpainPainettu && juoksePainettu))
        {
            anim.SetBool(isRunningHash, true);
        }
         if (isJuoksee && (!eteenpainPainettu || !juoksePainettu))
        {
            anim.SetBool(isRunningHash, false);
        }

        //else
        //{
        //    anim.SetTrigger("idle");

        //}
        //if (Input.GetKey(KeyCode.I))
        //{
        //    anim.SetTrigger("isWalking");

        //}
        //else if (Input.GetKey(KeyCode.LeftShift) )
        //{
        //    anim.SetTrigger("isRunning");


        //}


        //else
        //{
        //    anim.SetTrigger("idle");

        //}


    }
}
