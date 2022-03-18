using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int monsterLeft = 0;
    public GameObject WaterBlock;
    public GameObject CathedralBlock;
    public GameObject FireBlock;
    public string CurrentMission;
    public GameObject fireRune;
    public bool isRuneSpawned = false;
    public GameObject fireRestrict;
    public Chest chest;
    public GameObject telekinesisTrigger, fireTrigger;



    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0) {


            if (LocationManager.Instance.hasTelekinesis)
            {
                Destroy(telekinesisTrigger);
            }

            if (LocationManager.Instance.hasFire)
            {
                Destroy(fireTrigger);
            }



        if (LocationManager.Instance.hasTelekinesis && FireBlock != null)
        {
            Destroy(FireBlock);
        }
        if(CurrentMission == "skulls" && monsterLeft == 0 && isRuneSpawned == false && CathedralBlock != null)
            {
                Destroy(CathedralBlock);
                fireRune.SetActive(true);
                isRuneSpawned = true;
            }

            if (LocationManager.Instance.hasFire && CathedralBlock != null)
            {
                Destroy(CathedralBlock);
            }




           


                if (CurrentMission == "skulls" && !LocationManager.Instance.hasFire)
                {
                fireRestrict.SetActive(true);
                }
                else
                {
                fireRestrict.SetActive(false);
                }



              


        }

        if (CurrentMission == "demons" && monsterLeft == 0)
        {
            chest.objectiveCompleted = true;
        }


        if (LocationManager.Instance.hasWaterBoots && WaterBlock != null)
        {
            Destroy(WaterBlock);
        }











    }


}
