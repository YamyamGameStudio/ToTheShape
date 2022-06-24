using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float hiz = 5f;

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            //transform.Translate(Vector3.forward*Time.deltaTime*hiz);
            transform.position += (Vector3.forward * Time.deltaTime * hiz);
        }
    }
}