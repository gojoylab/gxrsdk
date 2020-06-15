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

    public class TXRHMDPoseTracker : MonoBehaviour
    {
        public enum TrackingType
        {
            /**
            * Rotation only
            */
            TRACKINGTYPE_3DOF = 1,

            /**
            * Position and Rotation
            */
            TRACKINGTYPE_6DOF = 0
        }

        [SerializeField]
        public TrackingType trackingType;

        // Virtual cameras for rendering
        [SerializeField]
        public Camera leftRenderCamera;

        [SerializeField]
        public Camera rightRenderCamera;

        private int m_LeftCullingMask;
        private int m_RightCullingMask;

        private bool isInited;

        void Init()
        {
            //var eyeposFromHead = PoseDevice.EyePosFromHead;
            //leftRenderCamera.transform.localPosition = eyeposFromHead.LEyePose.position;
            //leftRenderCamera.transform.localRotation = eyeposFromHead.LEyePose.rotation;
            //rightRenderCamera.transform.localPosition = eyeposFromHead.REyePose.position;
            //rightRenderCamera.transform.localRotation = eyeposFromHead.REyePose.rotation;

            //leftRenderCamera.transform.localPosition.Set(-0.005f, 0.0f, 0.0f);
            //rightRenderCamera.transform.localPosition.Set(0.005f, 0.0f, 0.0f);
            isInited = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (!isInited)
            {
                Init();
            }

            // Check key event
            if (InputDevice.GetTouchButton(InputDevice.TouchButtonType.BUTTON_A))
            {
               PoseDevice.ResetYaw();
            }

            UpdatePose();
        }

        private void UpdatePose()
        {
            Pose pose = Pose.identity;

            PoseDevice.GetHeadPoseByTime(ref pose);

            transform.localRotation = pose.rotation;
        }
    }
}