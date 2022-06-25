using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public static event Action <PlayerTypes>tileFirstPointObserver;
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
        else if (other.CompareTag("CloseButton"))
        {
            //observer bağır
            closeButtonPointObserver?.Invoke();
        }
        else if (other.CompareTag("DestroyTilePoint"))
        {
            destroyTilePointObserver?.Invoke();
        }
        else if (other.CompareTag("TileFirstPoint"))
        {
            tileFirstPointObserver?.Invoke(transform.GetComponent<PlayerSpawner>().playerType);
        }
        
    }
}
