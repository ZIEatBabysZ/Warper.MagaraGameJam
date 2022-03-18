using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{

    public int sceneIndex;
    public GameObject player;
    public GameLogic gameLogic;
    public bool setLastPosition = false;
    public bool isObjectiveOriented = false;
    public LocationManager locationManager;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameLogic>();
        locationManager = GameObject.FindGameObjectWithTag("LocationManager").GetComponent<LocationManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isObjectiveOriented)
        {
            if(gameLogic.monsterLeft != 0)
            {
                return;
            }
        }


        if (collision.transform.CompareTag("Player"))
        {
            if (setLastPosition)
            {
                LocationManager.Instance.spawnLocation = player.transform.position;
                LocationManager.Instance.CameraLocation = Camera.main.transform.position;
            }
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
