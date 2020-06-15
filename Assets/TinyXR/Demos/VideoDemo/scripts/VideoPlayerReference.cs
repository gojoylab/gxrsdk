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
    using UnityEngine;

    /// <summary>
    /// A data class which finds and stores reference information for `GvrVideoPlayerTexture`
    /// instances.
    /// </summary>
    public class VideoPlayerReference : MonoBehaviour
    {
        /// <summary>The `GvrVideoPlayerTexture` instance this object refers to.</summary>
        public GvrVideoPlayerTexture player;

        private void Awake()
        {
#if !UNITY_5_2
            GetComponentInChildren<VideoControlsManager>(true).Player = player;
#else
            GetComponentInChildren<VideoControlsManager>().Player = player;
#endif
        }
    }
}