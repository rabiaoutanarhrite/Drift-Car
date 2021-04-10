using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowMe : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPos;
    [SerializeField]
    private GameObject player;
    public float moveSpeed = 5f;
    private float rotateSpeed = 8f;
    private Rigidbody rb;
    private Vector3 movement;

    private Transform target;


     void Start()
    {
        
        spawnPos = GameObject.FindGameObjectWithTag("Respawn");

        rb = this.GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Vector3 pointTarget = transform.position - spawnPos.transform.position;
            pointTarget.Normalize();

            float value = Vector3.Cross(pointTarget, transform.forward).y;

            rb.angularVelocity = rotateSpeed * value * new Vector3(0, 1, 0);
            rb.velocity = transform.forward * moveSpeed;
        }
        
        else
        {
             Vector3 pointTarget = transform.position - player.transform.position;
             pointTarget.Normalize();

             float value = Vector3.Cross(pointTarget, transform.forward).y;

             rb.angularVelocity = rotateSpeed * value * new Vector3(0, 1, 0);
             rb.velocity = transform.forward * moveSpeed;
        }




    }
}
