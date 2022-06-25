using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private List<DoorModel> doorList = new List<DoorModel>();

    private Dictionary<DoorTypes, MeshFilter> doorDictionary;

    private DoorTypes doorType;
    
    private MeshFilter meshFilter => gameObject.GetComponent<MeshFilter>();
}


[Serializable]
public class DoorModel
{
    public DoorTypes doorType;
    public MeshFilter doorMeshFilter;
}
public enum DoorTypes
{
    Cone,
    Cube,
    Cylinder,
    Ellipse,
    Hexagon,
    Sphere
}
