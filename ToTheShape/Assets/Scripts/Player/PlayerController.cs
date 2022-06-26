using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Alican
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

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
            if (!GameManager.Instance.isGameFail)
            {
                PlayerMovement();
            }
            
        }

        private void PlayerMovement()
        {
            //transform.Translate(Vector3.forward*Time.deltaTime*hiz);
            transform.position += (Vector3.forward * Time.deltaTime * speed);
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