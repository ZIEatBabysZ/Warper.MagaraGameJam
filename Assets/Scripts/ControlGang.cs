using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGang : MonoBehaviour
{
   

    void Update()
    {
        if (LocationManager.Instance.hasTelekinesis)
        {
            Destroy(gameObject);
        }
    }
}
