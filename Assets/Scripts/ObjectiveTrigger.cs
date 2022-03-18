using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveTrigger : MonoBehaviour
{
    public GameLogic gameLogic;
    public int monsterCount = 8;
    public string MissionName;


    private void Awake()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameLogic>();
    }

    private void Update()
    {
        if(MissionName == "cowboys" && LocationManager.Instance.hasTelekinesis)
        {
            Destroy(gameObject);
        }
        else if(MissionName == "cowboys" && LocationManager.Instance.hasFire)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameLogic.monsterLeft = monsterCount;
            gameLogic.CurrentMission = MissionName;

            Destroy(gameObject);
        }
    }
}
