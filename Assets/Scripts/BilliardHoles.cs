using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardHoles : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("BALL"))
        Destroy(collider.gameObject);
    }
}
