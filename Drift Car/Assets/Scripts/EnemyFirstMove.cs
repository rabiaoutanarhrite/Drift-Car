using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFirstMove : MonoBehaviour
{
    public float speed = 100;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
    }
}
