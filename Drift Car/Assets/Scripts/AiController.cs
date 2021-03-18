using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AiController : MonoBehaviour
{
    NavMeshAgent myNavMeshAgent;
    public Transform player;

    private float moveInput;
    private float turnInput;


    public float fwdSpeed;
    public float reverseSpeed;
    public float turnSpeed;

    public Rigidbody sphereRB;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();

        sphereRB.transform.parent = null;
    }


    void Update()
    {
        
        myNavMeshAgent.SetDestination(player.position);
    }

    private void FixedUpdate()
    {
        sphereRB.AddForce(transform.forward , ForceMode.Acceleration);
    }
}
