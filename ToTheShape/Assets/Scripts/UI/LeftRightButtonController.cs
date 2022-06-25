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

        public static event Action<ButtonState> buttonClosedObserver;

        private void OnEnable()
        {
            PlayerActions.activateButtonPointObserver += ActivateButtons;
            PlayerActions.closeButtonPointObserver += CloseButtons;
            PlayerActions.destroyTilePointObserver += ResetButtonState;
        }

        private void OnDestroy()
        {
            PlayerActions.activateButtonPointObserver -= ActivateButtons;
            PlayerActions.closeButtonPointObserver -= CloseButtons;
            PlayerActions.destroyTilePointObserver -= ResetButtonState;

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
            buttonClosedObserver?.Invoke(buttonState);
        }
        
    }

    public enum ButtonState
    {
        Left,
        Right,
        Mid
    }
}