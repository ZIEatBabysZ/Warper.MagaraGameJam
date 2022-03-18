using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public InputManager inputManager;
    public GameObject firePrefab;
    public GameObject flameThrowerPrefab;
    public GameObject inGameFlameThrower;
    public LayerMask ignoreLayer;
    public GameObject damagePopup;
    public AudioSource fireSound;
    public float fireDmg = 3f;
    public float DamageCooldown = 0f;
    public float StaminaCooldown = 0f;
    public float staminaConsume = 2f;
    public bool isLocked = true;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }
    public void OnClickStarted()
    {
        inputManager.isHoldingDown = true;
        if (inGameFlameThrower != null && inputManager.playerManager.stamina >= staminaConsume)
        {
            inGameFlameThrower.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            if (!fireSound.isPlaying)
            {
                fireSound.Play();
            }
        }
    }


    private void Update()
    {
        DamageCooldown += Time.fixedDeltaTime;
        StaminaCooldown += Time.fixedDeltaTime;

        if (inputManager.currentSkill == InputManager.skills.FireSkill && inGameFlameThrower != null && inputManager.playerManager.stamina >= staminaConsume)
        {
            if (inputManager.isHoldingDown)
            {
                if (StaminaCooldown > 2f)
                {
                    inputManager.playerManager.stamina -= staminaConsume;
                    StaminaCooldown = 0f;
                }

                inGameFlameThrower.transform.position = Camera.main.ScreenToWorldPoint(inputManager.MouseAxis);
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(inputManager.MouseAxis);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit)
                {
                    if (hit.transform.childCount < 1) return;
                    if (hit.transform.GetChild(0).CompareTag("Enemy"))
                    {

                        Enemy enemyScript = hit.transform.GetChild(0).GetComponent<Enemy>();
                        if (DamageCooldown > 2f)
                        {
                            enemyScript.health -= fireDmg;
                            var dmgPopup = Instantiate(damagePopup, hit.point, Quaternion.identity);
                            dmgPopup.GetComponent<DamagePopup>().SetText("-" + fireDmg.ToString());
                            DamageCooldown = 0f;
                        }
                    }

                }
            }
        }
    }

    private void FixedUpdate()
    {
        DrawFire();

        if (inputManager.currentSkill == InputManager.skills.FireSkill && inGameFlameThrower == null && isLocked == false)
        {
            inGameFlameThrower = Instantiate(flameThrowerPrefab, Vector3.zero, Quaternion.identity);
            fireSound = inGameFlameThrower.GetComponent<AudioSource>();

        }
        else if(inputManager.currentSkill == InputManager.skills.FireSkill && isLocked == false)
        {
            Flamethrower();
        }
       
    }


    public void Flamethrower()
    {
        if (!inputManager.isHoldingDown)
        {
            inGameFlameThrower.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
            if (fireSound.isPlaying)
            {
                fireSound.Stop();
            }
        }
        else if (inputManager.isHoldingDown)
        {

        }
    }


    public void DrawFire()
    {
        /*
        if (inputManager.isHoldingDown)
        {
            if (DrawingCooldown > 0.3f)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(inputManager.MouseAxis);
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, mousePos, 500f);
                if (hit)
                {
                    if (!hit.transform.CompareTag("Building"))
                    {
                        Vector3 itemPos = new Vector3(mousePos.x, mousePos.y, 0);
                        Instantiate(firePrefab, itemPos, Quaternion.identity);
                        DrawingCooldown = 0f;
                    }
                }

            }
        }
        */
    }


 
}
