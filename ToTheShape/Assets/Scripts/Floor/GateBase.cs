using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBase : MonoBehaviour
{
    public GateTypes gateType;
    public static event Action gateExitObserver;

    private void OnTriggerEnter(Collider other)
    {
        //şuanki gate in type ı ile player ın type ı aynı mı
        //aynıysa +score
        //farklıysa - hp
        if (other.CompareTag("Player"))
        {
            if (other.name==gateType.ToString())
            {
             //+++score
             GameManager.Instance.IncreaseScore(1);
            }
            else
            {
                //--hp
                GameManager.Instance.DecreaseHP();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gateExitObserver?.Invoke();
            GameManager.Instance.IncreasePlayerChangeCount();
        }
        
    }
}
