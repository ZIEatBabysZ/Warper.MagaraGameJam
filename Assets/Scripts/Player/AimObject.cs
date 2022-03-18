using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimObject : MonoBehaviour
{
    private InputManager inputManager;
    public RaycastHit2D hit;
    private void Awake()
    {
        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>(); 
    }

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(inputManager.MouseAxis);
        hit = Physics2D.Raycast(transform.position, mousePos - transform.position, 500f);

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if(hit.point != Vector2.zero) { 
        Debug.DrawRay(transform.position, hit.point - (Vector2)transform.position);
        }
    }
}
