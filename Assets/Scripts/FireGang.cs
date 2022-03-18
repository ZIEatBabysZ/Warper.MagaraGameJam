using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGang : MonoBehaviour
{
    private void Update()
    {
        if (LocationManager.Instance.hasFire)
        {
            Destroy(gameObject);
        }
    }
}
