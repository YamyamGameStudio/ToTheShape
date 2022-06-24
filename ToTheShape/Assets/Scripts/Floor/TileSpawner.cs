using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Olcay
{
    public class TileSpawner : MonoSingleton<TileSpawner>
    {
        [SerializeField] private GameObject tilePrefab;
        [SerializeField] private Transform tileSpawnPoint;
        private List<GameObject> tilesList = new List<GameObject>();

        private void Start()
        {
            SpawnTile(5);
        }

        //object pool ile değişecek
        private void SpawnTile(int count)
        {
            
            for (int i = 0; i < count; i++)
            {
                var tile = Instantiate(tilePrefab, tileSpawnPoint.position, tilePrefab.transform.rotation);
                tileSpawnPoint = tile.transform.GetChild(1).transform;
                tilesList.Add(tile);
            }
        }

        //object pool ile değişecek
        public void DestroyTilePointAction()
        {
            var firstTile=tilesList.First();
            tilesList.Remove(firstTile);
            Destroy(firstTile);
            
            SpawnTile(1);
        }
    }
}

