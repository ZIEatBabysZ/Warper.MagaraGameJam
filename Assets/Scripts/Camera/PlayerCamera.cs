using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public float camSpeed;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y,-10);
        transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), newPosition, camSpeed * Time.fixedDeltaTime);
    }
}
