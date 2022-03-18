using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class informationBox : MonoBehaviour
{
    public void hide()
    {
        StartCoroutine("hideBox");
    }


    IEnumerator hideBox()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
