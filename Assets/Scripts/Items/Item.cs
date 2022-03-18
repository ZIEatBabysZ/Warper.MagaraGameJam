using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Item", menuName = "Items/CreateItem", order = 1)]
public class Item : ScriptableObject
{
    public string itemName;
    public float damage;
    public Sprite sprite;
    public GameObject InGameItem;

   

}
