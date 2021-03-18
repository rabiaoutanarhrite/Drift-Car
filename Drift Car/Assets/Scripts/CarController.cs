using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float moveInput;
    private float turnInput;


    public float fwdSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    public Rigidbody sphereRB;

    void Start()
    {
        sphereRB.transform.parent = null;
    }

  
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        moveInput *= moveInput > 0 ? fwdSpeed : reverseSpeed;

        transform.position = sphereRB.transform.position;

        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo:Space.World);
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
