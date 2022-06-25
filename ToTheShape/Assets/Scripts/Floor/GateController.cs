using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GateController : MonoBehaviour
{
    [SerializeField] private List<GateModel> gateList = new List<GateModel>();

    private Dictionary<GateTypes, MeshFilter> gateDictionary;


    [SerializeField] private Transform rightGateTransform;
    [SerializeField] private Transform leftGateTransform;
    
    private MeshFilter rightGateMeshFilter => rightGateTransform.gameObject.GetComponent<MeshFilter>();
    private MeshFilter leftGateMeshFilter => leftGateTransform.gameObject.GetComponent<MeshFilter>();

    private bool isPlayerTypeGateSpawned;
    private GateTypes firstGateType, secondGateType;

    private void OnEnable()
    {
        PlayerActions.tileFirstPointObserver += SpawnGate;
    }

    private void OnDestroy()
    {
        PlayerActions.tileFirstPointObserver -= SpawnGate;
    }

    private void Start()
    {
        gateDictionary = new Dictionary<GateTypes, MeshFilter>();
        for (int i = 0; i < gateList.Count; i++)
        {
            gateDictionary.Add(gateList[i].gateType,gateList[i].gateMeshFilter);
        }
        SpawnGate(PlayerTypes.Cylinder);
    }

    private void SpawnGate(PlayerTypes playerType)
    {
        isPlayerTypeGateSpawned = false;
        //gateleri spawn edeceğimiz yer.
        MeshFilter firstChoosenMeshFilter;
        MeshFilter secondChoosenMeshFilter;
        /*GateTypes firstGateType;
        GateTypes secondGateType;*/
        var randomSide = Random.value;
        if (randomSide<0.5f)
        {
            firstChoosenMeshFilter = leftGateMeshFilter;
            secondChoosenMeshFilter = rightGateMeshFilter;
        }
        else
        {
            firstChoosenMeshFilter = rightGateMeshFilter;
            secondChoosenMeshFilter = leftGateMeshFilter;
        }
        
        
        
        
        var randomFirstGateIndex=Random.Range(0,gateDictionary.Count);
        firstChoosenMeshFilter.sharedMesh = gateList[randomFirstGateIndex].gateMeshFilter.sharedMesh;
        firstGateType = gateList[randomFirstGateIndex].gateType;
        

        if (firstGateType.ToString() == playerType.ToString())
        {
            while (true)
            {
                var randomSecondGateIndex=Random.Range(0,gateDictionary.Count);
                if (gateList[randomSecondGateIndex].gateType == firstGateType)
                {
                    return;
                }
                else
                {
                    secondChoosenMeshFilter.sharedMesh = gateList[randomSecondGateIndex].gateMeshFilter.sharedMesh;
                    secondGateType = gateList[randomSecondGateIndex].gateType;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < gateList.Count; i++)
            {
                if (gateList[i].gateType.ToString() == playerType.ToString())
                {
                    secondChoosenMeshFilter.sharedMesh = gateList[i].gateMeshFilter.sharedMesh;
                    secondGateType = gateList[i].gateType;
                    break;
                }
            }
            
        }

        firstChoosenMeshFilter.gameObject.GetComponent<GateBase>().gateType = firstGateType;
        secondChoosenMeshFilter.gameObject.GetComponent<GateBase>().gateType = secondGateType;

    }
}



[Serializable]
public class GateModel
{
    public GateTypes gateType;
    public MeshFilter gateMeshFilter;
}
public enum GateTypes
{
    Cone,
    Cube,
    Cylinder,
    Ellipse,
    Hexagon,
    Sphere
}
