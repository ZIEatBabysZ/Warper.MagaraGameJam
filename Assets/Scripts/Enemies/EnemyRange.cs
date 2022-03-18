using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerHittable"))
        {
            transform.parent.GetChild(0).GetComponent<Enemy>().inFireRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerHittable"))
        {
            transform.parent.GetChild(0).GetComponent<Enemy>().inFireRange = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.parent.GetChild(0).GetComponent<Enemy>().inFireRange = false;
    }
}
