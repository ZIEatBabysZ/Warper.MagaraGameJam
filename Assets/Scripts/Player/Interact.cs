using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject interactText;
    public GameObject interactObject;

    private void Awake()
    {
        interactText = GameObject.FindGameObjectWithTag("InteractText");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactObject = collision.gameObject;
        if (collision.transform.CompareTag("InteractableSword"))
        {
            interactText.GetComponent<TextMeshPro>().enabled = true;
          
        }

        if (collision.transform.CompareTag("InteractableFire"))
        {
            interactText.GetComponent<TextMeshPro>().enabled = true;
           
        }

        if (collision.transform.CompareTag("InteractableTelekinesis"))
        {
            interactText.GetComponent<TextMeshPro>().enabled = true;

        }

        if (collision.transform.CompareTag("Chest"))
        {
            interactText.GetComponent<TextMeshPro>().enabled = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (interactText != null)
        {
            interactText.GetComponent<TextMeshPro>().enabled = false;
        }
        interactObject = null;
    }


    public void interact()
    {
        if (interactObject == null) return;

        if(interactObject.transform.tag == "InteractableSword")
        {
            interactObject.GetComponent<InteractableSword>().Interact();
        }

        else if (interactObject.transform.tag == "InteractableFire")
        {
            interactObject.GetComponent<InteractableFire>().Interact();
        }
        else if (interactObject.transform.tag == "InteractableTelekinesis")
        {
            interactObject.GetComponent<InteractableTelekinesis>().Interact();
        }

        else if (interactObject.transform.tag == "Chest")
        {
            interactObject.GetComponent<Chest>().Interact();
        }
    }
}
