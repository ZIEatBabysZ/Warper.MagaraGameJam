using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameItem : MonoBehaviour
{
    public Item item;
    public Telekinesis telekinesis;
    public Rigidbody2D rb;
    public AimObject aimObject;
    private InputManager inputManager;
    public float throwSpeed;
    public float dragSpeed;
    public Vector2 forceOffset;
    public GameObject damageNotifier;
    public Animator anim;
    public bool attacked = false;

    private void Awake()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
        telekinesis = GameObject.FindGameObjectWithTag("Player").GetComponent<Telekinesis>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    public void OnDrag(Vector2 playerPosition)
    {
        Vector2 Difference = playerPosition - (Vector2)transform.position;
        if(Mathf.Abs(Difference.x) > 4 || Mathf.Abs(Difference.y) > 4)
        {
            inputManager.isDragging = false;
            telekinesis.isControllingObject = false;
            telekinesis.itemScript = null;
        }
        else { 
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(inputManager.MouseAxis.x, inputManager.MouseAxis.y, 0));
        transform.position = new Vector3(transform.position.x , transform.position.y, 0);
        }

    }


    public void OnDragEnded(Vector2 Force, Vector3 Direction)
    {
        rb.AddForce(Force * throwSpeed);
        transform.up = Direction;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && attacked == false && telekinesis.shootStatus)
        {
            anim.enabled = true;
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.health -= item.damage;
            rb.velocity = Vector2.zero;
            damageNotifier.GetComponent<TextMeshPro>().text = " -" + item.damage.ToString();
            var popup = Instantiate(damageNotifier, collision.transform.position, Quaternion.identity);
            anim.SetTrigger("Hit");
            enemyScript.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
            Destroy(popup, 1);
            attacked = true;
           
        }
        else
        {
            if (attacked == false && collision.CompareTag("Building"))
            { 
            anim.enabled = true;
            anim.SetTrigger("Hit");
            rb.velocity = Vector2.zero;
            attacked = true;
            }
        }
        telekinesis.shootStatus = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
    }







}
