using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCreation : MonoBehaviour
{

    public Item[] itemArray = new Item[] { };
    public Transform spawnLocation;
    public PlayerManager playerManager;

    private void Awake()
    {
        spawnLocation = GameObject.FindGameObjectWithTag("itemSpawnLocation").transform;
        playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
    }


    public void onCreate(Item item)
    {
        item.InGameItem.GetComponent<SpriteRenderer>().sprite = item.sprite;
        item.InGameItem.GetComponent<InGameItem>().item = item;
        
        GameObject newItem = Instantiate(item.InGameItem, spawnLocation.position, Quaternion.identity);
    }


    public void CreateTrigger(string objectName)
    {
        playerManager.stamina -= 10;
        switch (objectName)
        {
            case "knife":
                onCreate(itemArray[0]);
                return;
            default:
                break;
        }
    }
    



}
