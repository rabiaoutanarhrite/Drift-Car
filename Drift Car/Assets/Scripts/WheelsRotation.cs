using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotation : MonoBehaviour
{
    public float rotSpeed = 300 ;

    void Update()
    {
        
        transform.Rotate(rotSpeed * Time.deltaTime, 0, 0);
      
    }
}
