using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;
    public float maxStamina = 100;
    public float stamina = 100;
    public float swordDamage = 10;
    public float fireDamage = 10;
    private InputManager inputManager;
    public GameObject deadEffect;
    public GameObject deadScreen;


    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }
    private void Update()
    {

        health = Mathf.Clamp(health, 0, maxHealth);
        stamina = Mathf.Clamp(stamina, 0, maxStamina);


        if(health == 0)
        {
            inputManager.playerControls.Disable();
            var particle = Instantiate(deadEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(particle, 3f);
            gameObject.SetActive(false);
            deadScreen.SetActive(true);

        }

    }








}
