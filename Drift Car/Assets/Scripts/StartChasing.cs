using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChasing : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyFirstMove>().enabled = false;
            other.gameObject.GetComponent<EnemyFollowMe>().enabled = true;
        }
    }
}
