using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject explodeVfx;
    public GameObject carBody;

    public GameObject[] enemyCars;

    private float moveInput;
    private float turnInput;


    public float fwdSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    public bool moveCar = true;

    public Rigidbody sphereRB;

    public FixedTouchField rightTouch;
    public FixedTouchField leftTouch;

    void Start()
    {
        sphereRB.transform.parent = null;

    }

  
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        

        transform.position = sphereRB.transform.position;
        if(moveCar)
        {
            if (rightTouch.Pressed)
            {
                float newRotation = turnSpeed * Time.deltaTime;
                transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
            }

            if (leftTouch.Pressed)
            {
                float newRotation = -turnSpeed * Time.deltaTime;
                transform.Rotate(xAngle: 0, yAngle: newRotation, zAngle: 0, relativeTo: Space.World);
            }

        }
        
    }

    private void FixedUpdate()
    {
        if(moveCar)
        {
            sphereRB.AddForce(transform.forward * fwdSpeed, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            
            explodeVfx.SetActive(true);
            carBody.SetActive(false);
            moveCar = false;

            Debug.Log("HHHHH");

            this.gameObject.tag = "IgnoreMe";
        }
        

    }
}
