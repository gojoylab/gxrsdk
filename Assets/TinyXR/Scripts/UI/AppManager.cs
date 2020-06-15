/****************************************************************************
* Copyright 2020 Gojoy Techonology Limited. All rights reserved.
*                                                                                                                                                          
* This file is part of TinyXRSDK.                                                                                                          
*                                                                                                                                                           
* https://www.gojoylab.com       
* 
*****************************************************************************/
namespace TinyXRSDK
{
    using UnityEngine;
    [DisallowMultipleComponent]
    public class AppManager : MonoBehaviour
    {
        private float m_LastClickTime = 0;
        private int m_CumulativeClickNum = 0;
        private bool m_IsProfilerOpened = false;
        private const int triggerClickCount = 3;

        private void OnEnable()
        {
            // TXRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.HOME, OnHomeButtonClick);
            // TXRInput.AddClickListener(ControllerHandEnum.Left, ControllerButton.HOME, OnHomeButtonClick);
            TXRInput.AddClickListener(ControllerHandEnum.Right, ControllerButton.APP, OnAppButtonClick);
            TXRInput.AddClickListener(ControllerHandEnum.Left, ControllerButton.APP, OnAppButtonClick);
        }

        private void OnDisable()
        {
            // TXRInput.RemoveClickListener(ControllerHandEnum.Right, ControllerButton.HOME, OnHomeButtonClick);
            // TXRInput.RemoveClickListener(ControllerHandEnum.Left, ControllerButton.HOME, OnHomeButtonClick);
            TXRInput.RemoveClickListener(ControllerHandEnum.Right, ControllerButton.APP, OnAppButtonClick);
            TXRInput.RemoveClickListener(ControllerHandEnum.Left, ControllerButton.APP, OnAppButtonClick);
        }

        private void Update()
        {
#if UNITY_EDITOR
            if (Input.GetKeyDown(KeyCode.Escape))
                QuitApplication();
#endif
        }

        // private void OnHomeButtonClick()
        // {
        //     TXRHomeMenu.Toggle();
        // }

        private void OnAppButtonClick()
        {
            TXRHomeMenu.Toggle();
            // TXRHomeMenu.Hide();
        }

        public static void QuitApplication()
        {
            InputDevice.QuitApp();
        }
    }
}