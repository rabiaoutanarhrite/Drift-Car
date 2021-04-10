using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public GameObject explodeVfx;
    public GameObject carBody;

    private EnemyFollowMe enemyFollow;

    private void Start()
    {
        enemyFollow = gameObject.GetComponent<EnemyFollowMe>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            explodeVfx.SetActive(true);
            carBody.SetActive(false);
            enemyFollow.enabled = false;

            StartCoroutine(Disapear());
        }
    }

    IEnumerator Disapear()
    {
        yield return new WaitForSeconds(3f);

        Destroy(this.gameObject);
    }
}
