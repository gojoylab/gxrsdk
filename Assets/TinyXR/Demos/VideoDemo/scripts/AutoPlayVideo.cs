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

    /// <summary>Auto play video.</summary>
    /// <remarks>
    /// This script exposes a delay value in seconds to start playing the TexturePlayer component on
    /// the same object.
    /// </remarks>
    [RequireComponent(typeof(GvrVideoPlayerTexture))]
    public class AutoPlayVideo : MonoBehaviour
    {
        /// <summary>
        /// The time in seconds to wait before starting to play the `GvrVideoPlayerTexture`.
        /// </summary>
        public float delay = 2f;

        /// <summary>Whether to loop playing the `GvrVideoPlayerTexture`.</summary>
        public bool loop = false;

        private bool done;
        private float t;
        private GvrVideoPlayerTexture player;

        private void Start()
        {
            t = 0;
            done = false;
            player = GetComponent<GvrVideoPlayerTexture>();
            if (player != null)
            {
                player.Init();
            }
        }

        private void Update()
        {
            if (player == null)
            {
                return;
            }
            else if (player.PlayerState == GvrVideoPlayerTexture.VideoPlayerState.Ended &&
                     done &&
                     loop)
            {
                player.Pause();
                player.CurrentPosition = 0;
                done = false;
                t = 0f;
                return;
            }

            if (done)
            {
                return;
            }

            t += Time.deltaTime;
            if (t >= delay && player != null && player.Play())
            {
                done = true;
            }
        }
    }
}
