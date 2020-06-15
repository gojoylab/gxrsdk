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
    using System.IO;
    using UnityEngine;
    using System.Collections;
    /// <summary>
    ///  Manages AR system state and handles the session lifecycle.
    ///  this class, application can create a session, configure it, start/pause or stop it.
    /// </summary>
    public class TXRSessionManager
    {
        private static TXRSessionManager m_Instance;
        private bool m_IsInitialized = false;
        // private bool m_IsDestroyed = false;

        public static TXRSessionManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new TXRSessionManager();
                }
                return m_Instance;
            }

        }

        /// <summary>
        /// Current lost tracking reason.
        /// </summary>
        // public LostTrackingReason LostTrackingReason
        // {
        //     get
        //     {
        //         if (m_IsInitialized)
        //         {
        //             return NativeAPI.NativeHeadTracking.GetTrackingLostReason();
        //         }
        //         else
        //         {
        //             return LostTrackingReason.INITIALIZING;
        //         }
        //     }
        // }
        private TXRSessionState m_SessionStatus = TXRSessionState.UNINITIALIZED;

        public TXRSessionState SessionStatus
        {
            get { return m_SessionStatus; }
            private set { m_SessionStatus = value; }
        }

        public TXRSessionBehaviour TXRSessionBehaviour { get; private set; }
        public TXRHMDPoseTracker TXRHMDPoseTracker { get; private set; }
        // internal NativeInterface NativeAPI { get; private set; }
        // private TXRRenderer TXRRenderer { get; set; }
        // public TXRVirtualDisplayer VirtualDisplayer { get; set; }

        public bool IsInitialized
        {
            get
            {
                return m_IsInitialized;
            }
        }

        public void CreateSession(TXRSessionBehaviour session)
        {
            if (IsInitialized || null == session)
            {
                return;
            }
            if (null != TXRSessionBehaviour)
            {
                TXRDebugger.LogError("Multiple SessionBehaviour components cannot exist in the scene. " +
                  "Destroying the newest.");
                GameObject.DestroyImmediate(session.gameObject);
                return;
            }

            SessionStatus = TXRSessionState.CREATED;
            TXRSessionBehaviour = session;

            TXRHMDPoseTracker = session.GetComponent<TXRHMDPoseTracker>();

            // So far, we only have 3DoF Tracking
            SetTrackingMode(TXRHMDPoseTracker.TrackingType.TRACKINGTYPE_3DOF);
        }

        public void SetConfiguration(TXRSessionConfig config)
        {
            if (config == null)
            {
                return;
            }
        }

        private void SetTrackingMode(TXRHMDPoseTracker.TrackingType mode)
        {

        }

        public void Recenter()
        {
            if (!m_IsInitialized)
            {
                return;
            }
        }
        
        public static void SetAppSettings(bool useOptimizedRendering)
        {
            Application.targetFrameRate = 240;
            QualitySettings.maxQueuedFrames = -1;
            QualitySettings.vSyncCount = useOptimizedRendering ? 0 : 1;
            Screen.fullScreen = true;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        public void StartSession()
        {
            if (m_IsInitialized)
            {
                return;
            }

            SessionStatus = TXRSessionState.TRACKING;
            m_IsInitialized = true;
        }

        public void DisableSession()
        {
            if (!m_IsInitialized)
            {
                return;
            }

            SessionStatus = TXRSessionState.STOPPED;
        }

        public void ResumeSession()
        {
            if (!m_IsInitialized)
            {
                return;
            }
        }

        public void DestroySession()
        {
            if (!m_IsInitialized)
            {
                return;
            }
        }

    }
}