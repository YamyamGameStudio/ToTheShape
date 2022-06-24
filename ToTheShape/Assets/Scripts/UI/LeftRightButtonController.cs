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
        private ButtonState buttonState = ButtonState.Mid;

        private void OnEnable()
        {
            ActivateAndCloseButtonAction.activateButtonPointObserver += ActivateButtons;
            ActivateAndCloseButtonAction.closeButtonPointObserver += CloseButtons;
            ActivateAndCloseButtonAction.destroyTilePointObserver += ResetButtonState;
        }

        private void OnDestroy()
        {
            ActivateAndCloseButtonAction.activateButtonPointObserver -= ActivateButtons;
            ActivateAndCloseButtonAction.closeButtonPointObserver -= CloseButtons;
            ActivateAndCloseButtonAction.destroyTilePointObserver -= ResetButtonState;

        }

        public void LeftButton()
        {
            buttonState = ButtonState.Left;
        }

        public void RightButton()
        {
            buttonState = ButtonState.Right;
        }

        private void ResetButtonState()
        {
            buttonState = ButtonState.Mid;
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

    public enum ButtonState
    {
        Left,
        Right,
        Mid
    }
}