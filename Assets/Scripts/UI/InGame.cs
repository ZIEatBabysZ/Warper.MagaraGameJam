using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    public GameObject createItemWrapper;
    public GameObject player;
    public Movement movementScript;
    public InputManager inputManager;
    public GameObject test;
    public GameObject[] borders;
   // private bool canMove = true;


    void Awake()
    {
        movementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        player = GameObject.FindGameObjectWithTag("Player");
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();
    }
    

    void Update()
    {
        /* Vector3 middle = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
       RaycastHit2D hit = Physics2D.Raycast(middle, Vector2.zero);
       if (hit)
       {
           if(hit.transform == null || !hit.transform.CompareTag("Building"))
           {
               return;
           }
           test = hit.transform.gameObject;
           test.SetActive(false);
       }
       else
       {
           if (hit.transform == null) return;
           test.SetActive(true);
       }
        */

        if (inputManager.fire.isLocked)
        {
            borders[1].transform.parent.gameObject.SetActive(false);
        }
        if (inputManager.telekinesis.isLocked)
        {
            borders[2].transform.parent.gameObject.SetActive(false);
        }
        if (inputManager.sword.isLocked)
        {
            borders[0].transform.parent.gameObject.SetActive(false);
        }


        if (!inputManager.fire.isLocked)
        {
            borders[1].transform.parent.gameObject.SetActive(true);
        }
        if (!inputManager.telekinesis.isLocked)
        {
            borders[2].transform.parent.gameObject.SetActive(true);
        }
        if (!inputManager.sword.isLocked)
        {
            borders[0].transform.parent.gameObject.SetActive(true);
        }





        switch (inputManager.currentSkill)
        {
            case InputManager.skills.Sword:
                borders[0].SetActive(true);
                borders[1].SetActive(false);
                borders[2].SetActive(false);
                break;
            case InputManager.skills.FireSkill:
                borders[0].SetActive(false);
                borders[1].SetActive(true);
                borders[2].SetActive(false);
                break;
            case InputManager.skills.TelekinesisSkill:
                borders[0].SetActive(false);
                borders[1].SetActive(false);
                borders[2].SetActive(true);
                break;
            default:
                break;
        }
        /*
         if (Input.GetKeyDown(KeyCode.Tab))
         {
             if (createItemWrapper.activeSelf)
             {
                 createItemWrapper.SetActive(false);
                 canMove = true;
             }
             else
             {
                 createItemWrapper.SetActive(true);
                 canMove = false;
             }
             movementScript.setCanMovement(canMove);
         }
        */
    }
}
