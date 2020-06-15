/****************************************************************************
* Copyright 2020 Gojoy Techonology Limited. All rights reserved.
*                                                                                                                                                          
* This file is part of TinyXRSDK.                                                                                                          
*                                                                                                                                                           
* https://www.gojoylab.com       
* 
*****************************************************************************/
namespace TinyXRSDK.TXRExamples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class SimpleControllerVibration : MonoBehaviour
    {
        public float vibrationTime = 0.06f;
        public InputDevice.TouchButtonType[] vibrationButtons = { InputDevice.TouchButtonType.BUTTON_A, InputDevice.TouchButtonType.BUTTON_B};

        void Update()
        {
            if (vibrationButtons == null || vibrationButtons.Length == 0)
                return;
            for (int i = 0; i < vibrationButtons.Length; i++)
            {
                if (InputDevice.GetTouchButtonDown(vibrationButtons[i]))
                    InputDevice.TriggerHapticVibration(vibrationTime);
            }
        }
    }

}
