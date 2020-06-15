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
    using System.Collections.Generic;
    using System;
    using UnityEngine;

    public interface ButtonEventCallback
    {
        void OnButtonEvent(InputDevice.TouchButtonType button, InputDevice.TouchButtonEvent buttonEvent);
     
    }

    public class InputDevice : MonoBehaviour
    {
        private static AndroidJavaClass mAndroidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        private static AndroidJavaObject mJavaObject = mAndroidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
        private static List<ButtonEventCallback> mButtonEventCallbacks = new List<ButtonEventCallback>();

        private static float mResetYaw = 0.0f;

        private static bool m_HapticVibrationEnabled = true;

        public enum TouchButtonType
        {
            BUTTON_HOME = 0x00000001,
            BUTTON_BACK = 0x00000002,
            BUTTON_LEFT = 0x00000004,
            BUTTON_RIGHT = 0x00000008,
            BUTTON_UP = 0x00000010,
            BUTTON_DOWN = 0x00000020,
            BUTTON_A = 0x00000040,
            BUTTON_B = 0x00000080
        }

        public enum TouchButtonEvent
        {
            BUTTON_EVENT_DOWN = 1,
            BUTTON_EVENT_UP = 2,
            BUTTON_EVENT_CLICK = 3
        }

        /// <summary>
        /// Determine whether enable haptic vibration.
        /// </summary>
        public static bool HapticVibrationEnabled { get { return m_HapticVibrationEnabled; } set { m_HapticVibrationEnabled = value; } }


        public static bool GetControllerPoseByTime(ref Pose pose, UInt64 timestamp = 0, UInt64 predict = 0)
        {
            float[] eulerAngles = mJavaObject.Call<float[]>("getMobileEulerAngles");
            // float[] eulerAnglesHead = mJavaObject.Call<float[]>("getEulerAngles");
            pose.rotation = Quaternion.Euler(eulerAngles[0], eulerAngles[1] + mResetYaw, eulerAngles[2]);

            //pose.rotation = Quaternion.Euler(eulerAngles[0], eulerAngles[1], eulerAngles[2]);

            return true;
        }

        public static bool GetTouchButton(TouchButtonType type)
        {
            int keyCode = mJavaObject.Call<int>("getButtonPressed");

            if (((int)type & keyCode) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetTouchButtonDown(TouchButtonType type)
        {
            int keyCode = mJavaObject.Call<int>("getButtonDown");

            if (((int)type & keyCode) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetTouchButtonUp(TouchButtonType type)
        {
            int keyCode = mJavaObject.Call<int>("getButtonUp");
            
            if (((int)type & keyCode) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void RegisterButtonEvent(ButtonEventCallback callback)
        {
            //mButtonEventCallbacks.Add(callback);
        }

        public static void UnRegisterButtonEvent(ButtonEventCallback callback)
        {
            //mButtonEventCallbacks.Remove(callback);
        }
        
        public void OnButtonPressed(int button)
        {
            mButtonEventCallbacks.ForEach(o =>
            {
                o.OnButtonEvent((TouchButtonType)button, TouchButtonEvent.BUTTON_EVENT_CLICK);
            });

            Debug.Log("InputDevice: OnButtonPressed, key is " + button);
        }

        public void OnButtonActionDown(int button)
        {
            mButtonEventCallbacks.ForEach(o =>
            {
                o.OnButtonEvent((TouchButtonType)button, TouchButtonEvent.BUTTON_EVENT_DOWN);
            });
            Debug.Log("InputDevice: OnButtonActionDown, key is " + button);
        }

        public void OnButtonActionUp(int button)
        {
            mButtonEventCallbacks.ForEach(o =>
            {
                Debug.Log("InputDevice: OnButtonActionUp, key is ------------ " + button);
                o.OnButtonEvent((TouchButtonType)button, TouchButtonEvent.BUTTON_EVENT_UP);
            });
            Debug.Log("InputDevice: OnButtonActionUp, key is " + button);
        }

        public static void ResetYaw()
        {
            float[] eulerAngles = mJavaObject.Call<float[]>("getMobileEulerAngles");
            float[] eulerAnglesHead = mJavaObject.Call<float[]>("getEulerAngles");
            float headResetYaw = PoseDevice.GetResetYaw();

            mResetYaw = eulerAnglesHead[1] + headResetYaw - eulerAngles[1];
        }

        /// <summary>
        /// Returns the current rotation of the domain controller
        /// </summary>
        public static Quaternion GetRotation()
        {
            float[] eulerAngles = mJavaObject.Call<float[]>("getMobileEulerAngles");
            return Quaternion.Euler(eulerAngles[0], eulerAngles[1] + mResetYaw, eulerAngles[2]);
        }

        /// <summary>
        /// Trigger vibration of a certain handedness controller
        /// </summary>
        public static void TriggerHapticVibration(float durationSeconds = 0.1f, float frequency = 200f, float amplitude = 0.8f)
        {
            if (!HapticVibrationEnabled)
                return;
            PhoneVibrateTool.TriggerVibrate(durationSeconds);
        }

        /// <summary>
        /// Quit the app.
        /// </summary>
        public static void QuitApp()
        {
            Debug.Log("Start To Quit Application...");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            ForceKill();
#endif
        }

        /// <summary>
        /// Force kill the app.
        /// </summary>
        public static void ForceKill(bool needrelease = true)
        {
            Debug.Log("Start To kill Application...");
            if (needrelease)
            {
                TXRSessionManager.Instance.DestroySession();
            }
#if UNITY_ANDROID && !UNITY_EDITOR
            if (mJavaObject != null)
            {
                mJavaObject.Call("finish");
            }
            CallAndroidkillProcess();
#endif
        }

        private static void CallAndroidkillProcess()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            AndroidJNI.AttachCurrentThread();
            AndroidJavaClass processClass = new AndroidJavaClass("android.os.Process");
            int myPid = processClass.CallStatic<int>("myPid");
            processClass.CallStatic("killProcess", myPid);
#endif
        }
    }
}