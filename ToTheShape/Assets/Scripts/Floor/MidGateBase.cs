using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidGateBase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.DecreaseHP();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.IncreasePlayerChangeCount();
        }
        
    }
}
