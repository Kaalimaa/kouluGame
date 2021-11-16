using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KolPerPelaajaController : MonoBehaviour
{
    public float speed = 3;
   public float run = 2;
    // Start is called before the first frame update
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            run = 3;
        }
        else run = 1;
        PelaajaLiike();
    }

    private void PelaajaLiike()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 pelaajanLiike = new Vector3(hor, 0, ver) * speed *run * Time.deltaTime;
        transform.Translate(pelaajanLiike, Space.Self);
    }

}
