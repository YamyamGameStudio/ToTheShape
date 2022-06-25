using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Alican
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float hiz = 5f;

        private void OnEnable()
        {
            GateBase.gateExitObserver += ResetSidePosition;
            ButtonController.buttonClosedObserver += SideMovement;
        }

        private void OnDestroy()
        {
            GateBase.gateExitObserver -= ResetSidePosition;
            ButtonController.buttonClosedObserver -= SideMovement;
        }

        private void Update()
        {
            PlayerMovement();
        }

        private void PlayerMovement()
        {
            //transform.Translate(Vector3.forward*Time.deltaTime*hiz);
            transform.position += (Vector3.forward * Time.deltaTime * hiz);
        }

        private void SideMovement(ButtonState buttonState)
        {
            if (buttonState == ButtonState.Left)
            {
                transform.DOMoveX(-3f, 2f);
            }
            else if (buttonState == ButtonState.Right)
            {
                transform.DOMoveX(3f, 2f);
            }
        }

        private void ResetSidePosition()
        {
            transform.DOMoveX(0f, 1f);
        }
    }
}