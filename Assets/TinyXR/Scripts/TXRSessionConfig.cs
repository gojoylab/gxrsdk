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
    using UnityEngine.Serialization;

    /// <summary>
    /// A configuration used to track the world.
    /// </summary>
    [CreateAssetMenu(fileName = "TXRCoreSessionConfig", menuName = "TinyXR/SessionConfig", order = 1)]
    public class TXRSessionConfig : ScriptableObject
    {
        // Chooses whether optimized rendering will be used. It can't be changed in runtime.
        [Tooltip("Chooses whether Optimized Rendering will be used. It can't be changed in runtime")]
        [FormerlySerializedAs("Optimized Rendering")]
        public bool OptimizedRendering = true;

        /// <summary>
        /// ValueType check if two TXRSessionConfig objects are equal.
        /// </summary>
        /// <returns>True if the two TXRSessionConfig objects are value-type equal, otherwise false.</returns>
        public override bool Equals(object other)
        {
            TXRSessionConfig otherConfig = other as TXRSessionConfig;
            if (other == null)
            {
                return false;
            }

            if (OptimizedRendering != otherConfig.OptimizedRendering)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Return a hash code for this object.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// ValueType copy from another SessionConfig object into this one.
        /// </summary>
        /// <param name="other"></param>
        public void CopyFrom(TXRSessionConfig other)
        {
            OptimizedRendering = other.OptimizedRendering;
        }
    }
}