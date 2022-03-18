using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{

    public float speed = 0;
    public InputManager playerControls;
    private Vector2 MovementAxis;
    [HideInInspector]
    public Vector2 MouseAxis;
    public bool canMove = true;
    public Sprite[] sprites = new Sprite[] { };
    public SpriteRenderer sRenderer;
    public Animator anim;
    public AudioSource walkSound;
    
 

private void Awake()
    {
        playerControls = GetComponent<InputManager>();
        sRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>(); 
        walkSound = GetComponent<AudioSource>();
    }
   



    // Update is called once per frame
    void Update()
    {
        MovementAxis = playerControls.MovementAxis;
        MouseAxis = playerControls.MouseAxis;
        

        if(MovementAxis.x == 0 && MovementAxis.y == 0) { 
            mouseRotation();
        }
       

    }

    private void FixedUpdate()
    {
        Move();
    }


 


    public void Move()
    {
    if (canMove)
    {
        Vector3 newPosition = new Vector3(MovementAxis.x, MovementAxis.y) * speed * Time.fixedDeltaTime;
        transform.position = transform.position + newPosition;
            var movementValue = Mathf.Abs(MovementAxis.x) + Mathf.Abs(MovementAxis.y);
            if (movementValue > 0 ) {
                if(!walkSound.isPlaying){ 
                walkSound.Play();
                }
                anim.enabled = true;
                anim.SetFloat("Movement", movementValue);
                anim.SetFloat("Horizontal", MovementAxis.x);
                anim.SetFloat("Vertical", MovementAxis.y);
            }
            else
            {
                if (walkSound.isPlaying)
                {
                    walkSound.Stop();
                }
            }
        }
    }


    public void setCanMovement(bool move)
    {
        canMove = move;
    }

    
    public void mouseRotation()
    {
        anim.enabled = false;

        if (MouseAxis.y < Screen.height / 2 + 40 && MouseAxis.y > Screen.height / 2 - 40)
        {
            if (MouseAxis.x < Screen.width / 2)
            {
                sRenderer.sprite = sprites[6];
            }
            else
            {
                sRenderer.sprite = sprites[7];
            }
        }

        else if (MouseAxis.y >= Screen.height / 2 + 40)
        {
            if (MouseAxis.x < 460)
            {
                sRenderer.sprite = sprites[4];
            }
            else if (MouseAxis.x >= 550)
            {
                sRenderer.sprite = sprites[5];
            }
            else
            {
                sRenderer.sprite = sprites[0];

            }
        }
        else
        {

            if (MouseAxis.x < 460)
            {
                sRenderer.sprite = sprites[2];
            }
            else if (MouseAxis.x >= 550)
            {
                sRenderer.sprite = sprites[3];
            }
            else
            {
                sRenderer.sprite = sprites[1];

            }
        }
    }



    




    /* public void movementRotation()
     {
         // Left - Right
         if (MovementAxis.y == 0 && Mathf.Abs(MovementAxis.x) > 0)
         {
             if (MovementAxis.x < 0)
             {
                 sRenderer.sprite = sprites[6];
             }
             else
             {
                 sRenderer.sprite = sprites[7];
             }
         }

         // TOP

         else if (MovementAxis.y > 0)
         {
             // TOP LEFT
             if (MovementAxis.x < 0)
             {
                 sRenderer.sprite = sprites[4];
             }
             // TOP RIGHT
             else if (MovementAxis.x > 0)
             {
                 sRenderer.sprite = sprites[5];
             }

             // TOP
             else if(MovementAxis.y == 1)
             {
                 sRenderer.sprite = sprites[0];

             } 
         }

         // BOTTOM
         else
         {
             // BOTTOM LEFT
             if (MovementAxis.x < 0)
             {
                 sRenderer.sprite = sprites[2];
             }
             // BOTTOM RIGHT
             else if (MovementAxis.x > 0)
             {
                 sRenderer.sprite = sprites[3];
             }
             // BOTTOM

             else if(MovementAxis.y == -1)
             {
                 sRenderer.sprite = sprites[1];

             }

         }
     }






     */

}





