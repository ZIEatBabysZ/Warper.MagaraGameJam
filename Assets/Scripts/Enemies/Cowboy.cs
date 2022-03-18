using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    public Sprite[] sprites;
    public Enemy enemy;


    private void Awake()
    {
        enemy = transform.GetChild(0).GetComponent<Enemy>();
    }

    private void Update()
    {
        /* if (!enemy.inFireRange) return;

        if (enemy.Vertical < 0)
        {
            // TOP SPRITE
            enemy.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if(enemy.Vertical > 0)
        {
            // BOTTOM SPRITE
            enemy.GetComponent<SpriteRenderer>().sprite = sprites[1];
        } */
    } 
}
