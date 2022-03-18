using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillText : MonoBehaviour
{
    public void hide()
    {
        StartCoroutine("hideText");
    }


    IEnumerator hideText()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<TextMeshProUGUI>().enabled = false;
    }
}
