using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : MonoSingleton<PlayerSpawner>
{
    [SerializeField] private List<PlayerModel> playerList = new List<PlayerModel>();

    private Dictionary<PlayerTypes, MeshFilter> playerDictionary;

    public PlayerTypes playerType;
    private MeshFilter meshFilter => gameObject.GetComponent<MeshFilter>();
    // Start is called before the first frame update
    void Start()
    {
        playerDictionary = new Dictionary<PlayerTypes, MeshFilter>();
        for (int i = 0; i < playerList.Count; i++)
        {
            playerDictionary.Add(playerList[i].playerType,playerList[i].playerMeshFilter);
        }

        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        var randomPlayerIndex=Random.Range(0,playerDictionary.Count);
        meshFilter.sharedMesh = playerList[randomPlayerIndex].playerMeshFilter.sharedMesh;
        playerType = playerList[randomPlayerIndex].playerType;
        gameObject.name = playerType.ToString();
    }
}







[Serializable]
public class PlayerModel
{
    public PlayerTypes playerType;
    public MeshFilter playerMeshFilter;
}

public enum PlayerTypes
{
    Cone,
    Cube,
    Cylinder,
    Ellipse,
    Hexagon,
    Sphere
}