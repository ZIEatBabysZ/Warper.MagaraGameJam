using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bulletImpact;
    public float dmg = 10f;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PlayerHittable"))
        {
            PlayerManager playerManager = collision.transform.parent.GetComponent<PlayerManager>();
            collision.transform.parent.GetChild(6).GetComponent<ParticleSystem>().Play();
            var impactEffect = Instantiate(bulletImpact, transform.position, Quaternion.identity);
            Destroy(impactEffect, 2f);
            playerManager.health -= dmg;
            Destroy(gameObject);

        }
    }
}
