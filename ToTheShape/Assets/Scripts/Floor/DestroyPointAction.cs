using System;
using Olcay;
using UnityEngine;

public class DestroyPointAction : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(DestroyTileRoutine),3f);
        }
    }

    private void DestroyTileRoutine()
    {
        TileSpawner.Instance.DestroyTilePointAction();
    }
}
