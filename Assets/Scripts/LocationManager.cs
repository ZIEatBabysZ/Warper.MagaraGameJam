using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationManager : MonoBehaviour
{


    public static LocationManager Instance;
    public Vector2 spawnLocation;
    public Vector2 CameraLocation;
    public bool hasSword;
    public bool hasFire;
    public bool hasTelekinesis;
    public bool isAlreadyStarted = false;
    public bool hasWaterBoots = false;


    private void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   



}
