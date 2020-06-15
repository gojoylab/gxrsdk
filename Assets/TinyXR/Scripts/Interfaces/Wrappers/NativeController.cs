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
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using UnityEngine;

    internal partial class NativeController
    {
        private UInt64 m_ControllerHandle = 0;
        private UInt64[] m_StateHandles = new UInt64[TXRInput.MAX_CONTROLLER_STATE_COUNT] { 0, 0 };

        public bool Init()
        {
            TXRDebugger.Log("NativeController start init:");
            int count = GetControllerCount();
            TXRDebugger.Log("__controller count:" + count);
            for (int i = 0; i < count; i++)
            {
                m_StateHandles[i] = 1;
            }
            return true;
        }
        public int GetControllerCount()
        {
            int count = 1;
            return Mathf.Min(count, m_StateHandles.Length);
        }

        public void Pause()
        {
        }

        public void Resume()
        {
        }

        public void Stop()
        {
        }

        public void Destroy()
        {
            Stop();
        }

        public uint GetAvailableFeatures(int controllerIndex)
        {
            uint availableFeature = 0;
            availableFeature = 0x1FE;
            return availableFeature;
        }

        public ControllerType GetControllerType(int controllerIndex)
        {
            ControllerType controllerType = ControllerType.CONTROLLER_TYPE_PHONE;
            return controllerType;
        }

        public void RecenterController(int controllerIndex)
        {
            InputDevice.ResetYaw();
        }

        public void TriggerHapticVibrate(int controllerIndex, Int64 duration, float frequency, float amplitude)
        {
            InputDevice.TriggerHapticVibration(duration, frequency, amplitude);
        }

        public bool UpdateState(int controllerIndex)
        {
             if (m_StateHandles[controllerIndex] == 0)
                return false;
            return true;
        }

        public void DestroyState(int controllerIndex)
        {
            m_StateHandles[controllerIndex] = 0;
        }

        public ControllerConnectionState GetConnectionState(int controllerIndex)
        {
            // ControllerConnectionState state = ControllerConnectionState.CONTROLLER_CONNECTION_STATE_NOT_INITIALIZED;
            ControllerConnectionState state = ControllerConnectionState.CONTROLLER_CONNECTION_STATE_CONNECTED;
            return state;
        }

        public int GetBatteryLevel(int controllerIndex)
        {
            int batteryLevel = 100;
            return batteryLevel;
        }

        public bool IsCharging(int controllerIndex)
        {
            int isCharging = 0;
            return isCharging == 1;
        }

        public Pose GetPose(int controllerIndex)
        {
            Pose controllerPos = Pose.identity;
            controllerPos.rotation = InputDevice.GetRotation();
            return controllerPos;
        }

        public Vector3 GetGyro(int controllerIndex)
        {
            return Vector3.zero;
        }

        public Vector3 GetAccel(int controllerIndex)
        {
            return Vector3.zero;
        }

        public Vector3 GetMag(int controllerIndex)
        {
            return Vector3.zero;
        }

        public uint GetButtonState(int controllerIndex)
        {
            return (uint)((InputDevice.GetTouchButton(InputDevice.TouchButtonType.BUTTON_B) ? ControllerButton.TRIGGER : 0)
            | (InputDevice.GetTouchButton(InputDevice.TouchButtonType.BUTTON_A) ? ControllerButton.HOME : 0) 
            | (InputDevice.GetTouchButton(InputDevice.TouchButtonType.BUTTON_UP) ? ControllerButton.APP : 0));
        }

        public uint GetButtonUp(int controllerIndex)
        {
            return (uint)((InputDevice.GetTouchButtonUp(InputDevice.TouchButtonType.BUTTON_B) ? ControllerButton.TRIGGER : 0)
            | (InputDevice.GetTouchButtonUp(InputDevice.TouchButtonType.BUTTON_A) ? ControllerButton.HOME : 0) 
            | (InputDevice.GetTouchButtonUp(InputDevice.TouchButtonType.BUTTON_UP) ? ControllerButton.APP : 0));
        }

        public uint GetButtonDown(int controllerIndex)
        {
            return (uint)((InputDevice.GetTouchButtonDown(InputDevice.TouchButtonType.BUTTON_B) ? ControllerButton.TRIGGER : 0)
            | (InputDevice.GetTouchButtonDown(InputDevice.TouchButtonType.BUTTON_A) ? ControllerButton.HOME : 0) 
            | (InputDevice.GetTouchButtonDown(InputDevice.TouchButtonType.BUTTON_UP) ? ControllerButton.APP : 0));

        }

        public bool IsTouching(int controllerIndex)
        {
            uint touchState = 0;
            return touchState == 1;
        }

        public bool GetTouchUp(int controllerIndex)
        {
            uint touchUp = 0;
            return touchUp == 1;
        }

        public bool GetTouchDown(int controllerIndex)
        {
            uint touchDown = 0;
            return touchDown == 1;
        }

        public Vector2 GetTouch(int controllerIndex)
        {
            return Vector3.zero;
        }

        public void UpdateHeadPose(Pose hmdPose)
        {
            
        }

        public string GetVersion(int controllerIndex)
        {
            byte[] bytes = new byte[128];
            return System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length);
        }        
    }
}