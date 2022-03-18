using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100;
    public Rigidbody2D rb;
    public float alpha = 1f;
    public GameObject healthBar;
    public GameObject player;
    public GameObject enemyObject;
    public SpriteRenderer EnemySprite;
    public GameObject deadParticle;
    public bool isDead = false;
    public bool inRange = false;
    public GameObject bullet;
    public bool inFireRange = false;
    public bool isRangedCharacter = false;
    public float moveSpeed = 3f;
    public float bulletSpeed = 5f;
    public Animator anim;
    public float shotCooldown = 0f;
    public float shotCooldownLimit = 3f;
    public float Horizontal;
    public float Vertical;
    public Vector3 directionValue;
    public GameLogic gameLogic;
    public string enemyType;


    private void Awake()
    {
        EnemySprite = transform.parent.GetComponent<SpriteRenderer>();
        gameLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameLogic>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyObject = transform.parent.gameObject;
        anim = transform.parent.GetComponent<Animator>();
    }

    private void Update()
    {
  
            FollowPlayer();

        directionValue = (enemyObject.transform.position - player.transform.position).normalized;
        // Debug.Log(directionValue);
        Horizontal = directionValue.x;
        Vertical = directionValue.y;

      

        if (health <= 0)
        {

            if(isDead == false)
            {
                isDead = true;
                if(gameLogic.monsterLeft > 0)
                {
                    gameLogic.monsterLeft--;
                }
                var particleEffect = Instantiate(deadParticle, transform.parent.transform.position, Quaternion.identity);
                Destroy(particleEffect, 2f);
                Destroy(transform.parent.gameObject);
            }

        }

        
        healthBar.transform.localScale = Vector3.Lerp(healthBar.transform.localScale, new Vector3(health / 100, healthBar.transform.localScale.y,1), Time.fixedDeltaTime);
    }



    void FollowPlayer()
    {
        if (!inFireRange && inRange) {
            if (anim != null) anim.enabled = true;
            Vector2 newPosition = Vector2.MoveTowards(enemyObject.transform.position, player.transform.position, Time.fixedDeltaTime * moveSpeed);
            enemyObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
            if (anim != null)
            {
                if(enemyType == "cowboy") { 
                anim.SetBool("firing", false);
                anim.SetBool("walking", true);
                }
                anim.SetFloat("Horizontal", Horizontal);
                anim.SetFloat("Vertical", Vertical);
            }
            // enemyObject.transform.position = Vector3.Lerp(enemyObject.transform.position, player.transform.position, moveSpeed * Time.fixedDeltaTime);
        }
        else if(inFireRange)
        {
            if(anim != null && enemyType != "boss") anim.enabled = false;

            if (isRangedCharacter)
            {
                ShootAtPlayer();

            }
            else
            {
               if(enemyType == "skull") anim.SetBool("rage", true);
                Vector2 newPosition = Vector2.MoveTowards(enemyObject.transform.position, player.transform.position, Time.fixedDeltaTime * moveSpeed);
                enemyObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
            }

           if(anim != null) { 
                if(enemyType == "cowboy") { 
            anim.SetBool("firing", true);
            anim.SetBool("walking", false);
                }
            }
        }
        else
        {
            if(anim != null) { 
                if(enemyType == "cowboy") { 
            anim.SetBool("firing", false);
            anim.SetBool("walking", false);
                }
                if (enemyType == "skull") anim.SetBool("rage", false);
            }

        }
    }


    void ShootAtPlayer()
    {
        shotCooldown += Time.fixedDeltaTime;
        if(shotCooldown > shotCooldownLimit) { 
        var newBullet = Instantiate(bullet, enemyObject.transform.position, Quaternion.identity);
            newBullet.transform.right = enemyObject.transform.position - player.transform.position;
        newBullet.GetComponent<Rigidbody2D>().AddForce((enemyObject.transform.position - player.transform.position) * -bulletSpeed);
        shotCooldown = 0f;
        }
    }


   

}
