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
    /// <summary>
    /// Operate AR system state and handles the senssion lifecycle for application layer.
    /// </summary>
    public class TXRSessionBehaviour : SingletonBehaviour<TXRSessionBehaviour>
    {
        /// <summary>
        /// The SessioonConfig of TXRSenssion.
        /// </summary>
        [Tooltip("A scriptable object specifying the TXRSDK session configuration")]
        public TXRSessionConfig SessioonConfig;

        new void Awake()
        {
            base.Awake();
            if (isDirty) return;
            #if !UNITY_EDITOR
            TXRDebugger.EnableLog = Debug.isDebugBuild;
            #endif
            TXRDebugger.Log("[TXRSessionBehaviour Awake: CreateSession]");
            TXRSessionManager.Instance.CreateSession(this);
        }

        // Start is called before the first frame update
        void Start()
        {
            TXRSessionManager.Instance.StartSession();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                TXRSessionManager.Instance.DisableSession();
            }
            else
            {
                TXRSessionManager.Instance.ResumeSession();
            }
        }

        void onDisabled()
        {
            TXRSessionManager.Instance.DisableSession();
        }

        void onDestroy()
        {
            TXRSessionManager.Instance.DestroySession();
        }
    }
}
