using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chest : MonoBehaviour
{

    public string password = "312";
    public GameObject passwordScreen;
    public GameObject hud;
    public InputField input1, input2, input3;
    public SpriteRenderer spriteRenderer;
    public Sprite openChestSprite;
    public GameObject telekinesisRune;
    public bool alreadyInteracted = false;
    public bool hasInput = true;
    public GameObject missionInfo;
    public bool objectiveCompleted = false;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Interact()
    {
        if(alreadyInteracted == false) {
            if (hasInput) {
                Cursor.visible = true;
        passwordScreen.SetActive(true);
       // hud.SetActive(false);
            }
            else
            {
                if (objectiveCompleted)
                {
                    alreadyInteracted = true;
                    LocationManager.Instance.hasWaterBoots = true;
                    missionInfo.GetComponent<TextMeshProUGUI>().text = "You got water boots. You can walk on water now.";
                    missionInfo.SetActive(true);
                    missionInfo.GetComponent<informationBox>().hide();
                    spriteRenderer.sprite = openChestSprite;
                }
            }
        }
    }

    private void Start()
    {
        if (hasInput) { 
        alreadyInteracted = LocationManager.Instance.hasTelekinesis;
        }
        

    }

    private void Update()
    {
        if (alreadyInteracted) { 
        spriteRenderer.sprite = openChestSprite;
        }
    }


    public void confirmInput()
    {
        if(input1 != null && input2 != null && input3 != null){ 
        string pass = input1.text + input2.text + input3.text;
        if(pass == password)
        {
                alreadyInteracted = true;
                gameObject.layer = 0;
                passwordScreen.SetActive(false);
                hud.SetActive(true);

                spriteRenderer.sprite = openChestSprite;
                telekinesisRune.SetActive(true);
                telekinesisRune.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
                telekinesisRune.GetComponent<SpriteRenderer>().sortingOrder = 0;

            }
        else
        {
                missionInfo.GetComponent<TextMeshProUGUI>().text = "Tip: House lights are looking shiny.";
                missionInfo.SetActive(true);
                missionInfo.GetComponent<informationBox>().hide();
        }
        }

    }


    public void closeScreen()
    {
        passwordScreen.SetActive(false);
        hud.SetActive(true);
    }
}
