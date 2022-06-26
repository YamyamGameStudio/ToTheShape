using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyPlaneMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private void Update()
    {
        SkyPlaneForwardMovement();
    }
    private void SkyPlaneForwardMovement()
    {
        //transform.Translate(Vector3.forward*Time.deltaTime*hiz);
        transform.position += (Vector3.forward * Time.deltaTime * speed);
    }
    
}
