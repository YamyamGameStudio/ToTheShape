using System;
using UnityEngine;
using UnityEngine.UI;

public class ActivateAndCloseButtonAction : MonoBehaviour
{
    public static event Action activateButtonPointObserver;
    public static event Action closeButtonPointObserver;
    public static event Action destroyTilePointObserver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ActivateButton"))
        {
           //observer bağır
           activateButtonPointObserver?.Invoke();
        }

        if (other.CompareTag("CloseButton"))
        {
            //observer bağır
            closeButtonPointObserver?.Invoke();
        }

        if (other.CompareTag("DestroyTilePoint"))
        {
            destroyTilePointObserver?.Invoke();
        }
    }
}
