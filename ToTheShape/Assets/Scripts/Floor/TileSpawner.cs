using System;
using System.Collections.Generic;
using UnityEngine;

namespace Olcay
{
    public class TileSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject tilePrefab;
        [SerializeField] private Transform tileSpawnPoint;
        private List<GameObject> TilesList = new List<GameObject>();

        private void Start()
        {
            SpawnTile();
        }


        private void SpawnTile()
        {
            for (int i = 0; i < 5; i++)
            {
                var tile = Instantiate(tilePrefab, tileSpawnPoint.position, tilePrefab.transform.rotation);
                tileSpawnPoint = tile.transform.GetChild(1).transform;
            }
        }
    }
}

