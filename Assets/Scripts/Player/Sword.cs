using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public GameObject SwordPrefab;
    public GameObject inGameSword;
    public InputManager inputManager;
    public Vector3 swordOffset;
    public BoxCollider2D hitCollider;
    public Animator swordAnim;
    public GameObject damagePopup;
    public float swordDamage = 10f;
    public PlayerManager playerManager;
    public bool isLocked = true;

    public float attackCooldown = 0f;
    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        if(inputManager.currentSkill == InputManager.skills.Sword && isLocked == false)
        {
            if(inGameSword == null)
            {
               inGameSword =  Instantiate(SwordPrefab, Vector3.zero, Quaternion.Euler(new Vector3(0,0,140)));
                swordAnim = inGameSword.GetComponent<Animator>();
                hitCollider = inGameSword.transform.GetChild(1).GetComponent<BoxCollider2D>();
                Cursor.visible = false;
            }
            inGameSword.transform.position = Camera.main.ScreenToWorldPoint(inputManager.MouseAxis) + swordOffset;
            inGameSword.transform.position = new Vector3(inGameSword.transform.position.x, inGameSword.transform.position.y, 0) ;
        }
        else
        {
            if(inGameSword != null)
            {
                Destroy(inGameSword);
                Cursor.visible = true;
            }
        }

        if (inGameSword)
        {
            attackCooldown += Time.deltaTime;
        }
    }


    public void SwingAttack(Collider2D collision)
    {
        var popupObject = Instantiate(damagePopup, inGameSword.transform.position, Quaternion.identity);
        var enemyScript = collision.GetComponent<Enemy>();
        enemyScript.health -= swordDamage;
        popupObject.GetComponent<DamagePopup>().SetText("-" + swordDamage.ToString());
        playerManager.stamina += 2f;
        collision.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();

    }




    public void OnClick()
    {
        if(attackCooldown > 0.5f) { 
            swordAnim.SetTrigger("hit");
            hitCollider.enabled = true;
            attackCooldown = 0f;
        }
    }


    
}
