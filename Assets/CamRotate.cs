using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    public float rotateSpeed =1;
    public Transform Target, Pelaaja;
    float mouseX, mouseY;
    // Start is called before the first frame update
    void LateUpdate()
    {
        CamControl();
    }

    private void CamControl()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotateSpeed;
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);
        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Pelaaja.rotation = Quaternion.Euler(0, mouseX, 0);
    }
}
