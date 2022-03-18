using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRestrict : MonoBehaviour
{
    GameLogic gameLogic;

    private void Awake()
    {
        gameLogic = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameLogic>();
    }


    private void Update()
    {
        if(gameLogic.CurrentMission == "skulls" && !LocationManager.Instance.hasFire)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
