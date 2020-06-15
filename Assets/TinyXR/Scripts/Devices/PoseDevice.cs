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
    using System;
    using UnityEngine;

    public class PoseDevice : MonoBehaviour
    {
        private static AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        private static AndroidJavaObject mJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");

        private static float mResetYaw = 0.0f;

        public static EyePoseData EyePosFromHead
        {
            get
            {
                EyePoseData eyePosFromHead;

                // todo, to get pose from native
                eyePosFromHead.LEyePose = Pose.identity;
                eyePosFromHead.REyePose = Pose.identity;
                return eyePosFromHead;
            }
        }

        public static bool GetHeadPoseByTime(ref Pose pose, UInt64 timestamp = 0, UInt64 predict = 0)
        {
            float[] eulerAngles = mJavaObject.Call<float[]>("getEulerAngles");
            pose.rotation = Quaternion.Euler(eulerAngles[0], eulerAngles[1] + mResetYaw, eulerAngles[2]);
            
            return true;
        }


        public static void ResetYaw()
        {
            float[] eulerAngles = mJavaObject.Call<float[]>("getEulerAngles");
            mResetYaw = -eulerAngles[1];

            InputDevice.ResetYaw();
        }

        public static float GetResetYaw()
        {
            return mResetYaw;
        }
    }
}