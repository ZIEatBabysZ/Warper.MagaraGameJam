using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    public TextMeshPro dmgText;
    private void Awake()
    {
        dmgText = GetComponent<TextMeshPro>();
        Destroy(gameObject,2f);
    }
    void Update()
    {
        float moveYSpeed = -1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
    }


    public void SetText(string text)
    {
        dmgText.SetText(text);
    }
}
