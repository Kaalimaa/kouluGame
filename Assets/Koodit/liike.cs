using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liike : MonoBehaviour



{
    private float MoveX, MoveZ;
    //sd is movement speed
    public float sd;
    public float JumpForce;
    public bool IsGrounded;
    public Rigidbody rb;
    //ms is mouse speed
    public int ms;
    public Transform cam;
    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * ms * 10 * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ms * 10 * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        this.gameObject.transform.Rotate(Vector3.up * mouseX);

   
        MoveX = Input.GetAxis("Horizontal");
        MoveZ = Input.GetAxis("Vertical");
        rb.MovePosition(transform.position + (transform.forward * MoveZ * sd / 4) + (transform.right * MoveX * sd / 4));
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.MovePosition(transform.position + (transform.forward * MoveZ * sd) + (transform.right * MoveX * sd));
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

