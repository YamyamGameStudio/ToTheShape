using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alican
{
    public class LeftRightButtonController : MonoBehaviour
    {
        [SerializeField] private GameObject rightButton;
        [SerializeField] private GameObject leftButton;

        private void OnEnable()
        {
            ActivateAndCloseButtonAction.activateButtonPointObserver += ActivateButtons;
            ActivateAndCloseButtonAction.closeButtonPointObserver += CloseButtons;
        }

        private void OnDestroy()
        {
            ActivateAndCloseButtonAction.activateButtonPointObserver -= ActivateButtons;
            ActivateAndCloseButtonAction.closeButtonPointObserver -= CloseButtons;
        }

        public void LeftButton()
        {
            Debug.Log("Left Click");
        }

        public void RightButton()
        {
            Debug.Log("Right Click");
        }


        private void ActivateButtons()
        {
            rightButton.SetActive(true);
            leftButton.SetActive(true);
        }

        private void CloseButtons()
        {
            rightButton.SetActive(false);
            leftButton.SetActive(false);
        }
        
    }
}