using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitController : MonoBehaviour
    
{
    public BoxCollider2D boxCollider;
    public GameObject damagePopup;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Enemy")) { 
        var popupObject = Instantiate(damagePopup, transform.parent.transform.position, Quaternion.identity);
        popupObject.GetComponent<DamagePopup>().SetText("-" + 10.ToString());
        var enemyScript = collision.GetComponent<Enemy>();
        collision.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
        }
        boxCollider.enabled = false;

    }
}
