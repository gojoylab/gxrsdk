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
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GazeTracker : MonoBehaviour
    {
        [SerializeField]
        private TXRPointerRaycaster m_Raycaster;
        private bool m_IsEnabled;

        private Transform CameraCenter
        {
            get
            {
                return TXRInput.CameraCenter;
            }
        }

        private void Start()
        {
            OnControllerStatesUpdated();
        }

        private void OnEnable()
        {
            TXRInput.OnControllerStatesUpdated += OnControllerStatesUpdated;
        }

        private void OnDisable()
        {
            TXRInput.OnControllerStatesUpdated -= OnControllerStatesUpdated;
        }

        private void OnControllerStatesUpdated()
        {
            UpdateTracker();
        }

        private void UpdateTracker()
        {
            if (CameraCenter == null)
                return;
            m_IsEnabled = TXRInput.RaycastMode == RaycastModeEnum.Gaze;
            m_Raycaster.gameObject.SetActive(m_IsEnabled);
            if (m_IsEnabled)
            {
                transform.position = CameraCenter.position;
                transform.rotation = CameraCenter.rotation;
            }
        }
    }
}