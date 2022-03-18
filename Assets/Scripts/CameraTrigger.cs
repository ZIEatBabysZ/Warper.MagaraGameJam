using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public float targetSize = 20f;
    public bool trigger = false;
    public bool isCompleted = false;
    public float zoomOutSpeed = 2f;
    public bool isZoomIn = false;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && trigger == false)
        {
            trigger = true;
        }
    }


    private void FixedUpdate()
    {
        if (trigger && !isCompleted)
        {
            Camera.main.GetComponent<Camera>().orthographicSize = Mathf.Lerp(Camera.main.GetComponent<Camera>().orthographicSize, targetSize, Time.fixedDeltaTime * zoomOutSpeed);
        }
        if (isZoomIn)
        {
            if (trigger && Camera.main.GetComponent<Camera>().orthographicSize < targetSize + 0.5)
            {
                isCompleted = true;
            }
        }
        else { 
        if(trigger && Camera.main.GetComponent<Camera>().orthographicSize > targetSize - 0.5)
        {
            isCompleted = true;
        }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
        isCompleted = false;
    }
}
