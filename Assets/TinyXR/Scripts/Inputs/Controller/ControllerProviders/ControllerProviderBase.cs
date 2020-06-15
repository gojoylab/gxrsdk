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

    public abstract class ControllerProviderBase
    {
        protected ControllerState[] states;
        public bool Inited { get; protected set; }

        public ControllerProviderBase(ControllerState[] states)
        {
            this.states = states;
        }

        public abstract int ControllerCount { get; }

        public abstract void OnPause();

        public abstract void OnResume();

        public abstract void Update();

        public abstract void OnDestroy();

        public virtual void TriggerHapticVibration(int controllerIndex, float durationSeconds = 0.1f, float frequency = 200f, float amplitude = 0.8f) { }

    }
}