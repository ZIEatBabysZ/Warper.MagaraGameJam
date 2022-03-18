using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekinesis : MonoBehaviour
{

    public Movement movementScript;
    public InGameItem itemScript;
    public InputManager playerControls;
    public Vector2 startPos, endPos;
    public bool isControllingObject = false;
    public bool shootStatus = false;
    public LayerMask ignoreLayers;
    public bool isLocked = true;





    private void Awake()
    {
        movementScript = GetComponent<Movement>();
        playerControls = GetComponent<InputManager>();
    }


    private void Update()
    {
        if (isLocked == true) return; 
        if (playerControls.isDragging && itemScript)
        {
            itemScript.OnDrag(transform.position);
        }

        if(playerControls.currentSkill != InputManager.skills.TelekinesisSkill)
        {
            isControllingObject = false;
            playerControls.isDragging = false;
            itemScript = null;
        }
    }


    public void OnClickStarted()
    {
        if (isLocked == true) return;

        if (isControllingObject)
        {
            isControllingObject = false;
            playerControls.isDragging = false;
            itemScript = null;
        }
        else { 



        startPos = Camera.main.ScreenToWorldPoint(movementScript.MouseAxis);
        RaycastHit2D[] mouseHits = Physics2D.RaycastAll(startPos, Vector2.zero);
            Transform itemTransform = null;

        foreach(RaycastHit2D hit in mouseHits)
            {
                if (hit.transform.CompareTag("Item"))
                {
                    itemTransform = hit.transform;
                    break;
                }
            }
        
           
        if (itemTransform && isControllingObject == false)
        {
            itemScript = itemTransform.GetComponent<InGameItem>();
            if (itemScript) {
                    Debug.Log(itemScript.name);
            itemScript.anim.enabled = false;
            isControllingObject = true;
            playerControls.isDragging = true;
            }
        }

        }

    }



    public void Shoot()
    {
       

        if (itemScript && isControllingObject == true && playerControls.isDragging == true)
        {
            isControllingObject = false;
            playerControls.isDragging = false;
            endPos = Camera.main.ScreenToWorldPoint(movementScript.MouseAxis);
            itemScript.OnDragEnded((Vector2)transform.position - endPos, (Vector3)endPos - transform.position);
            itemScript = null;
            shootStatus = true;
        }
    
    }

}
