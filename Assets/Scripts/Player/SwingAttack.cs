using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAttack : MonoBehaviour
{
    public Sword sword;
    public bool alreadyAttacked = false;
    public GameObject player;
    public AudioSource swingSound;


    private void Awake()
    {
        sword = GameObject.FindGameObjectWithTag("Player").GetComponent<Sword>();
        player = GameObject.FindGameObjectWithTag("Player");
        swingSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var diff = player.transform.position - sword.inGameSword.transform.position;
        Debug.Log(diff);
        if (collision.CompareTag("Enemy") && Mathf.Abs(diff.x) < 3.5f && Mathf.Abs(diff.y) < 3f) { 
        sword.SwingAttack(collision);
            if (!swingSound.isPlaying)
            {
                swingSound.Play();
            }
        }
        alreadyAttacked = true;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        alreadyAttacked = false;
    }
}
