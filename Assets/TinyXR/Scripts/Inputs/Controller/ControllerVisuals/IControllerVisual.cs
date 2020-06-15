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

    /// <summary>
    /// The interface contains methods for controller to update virtual controller visuals, 
    /// and to show the feed back of user interactivation.
    /// </summary>
    public interface IControllerVisual
    {
        void SetActive(bool isActive);
        void UpdateVisual(ControllerState state);
        void DestroySelf();
    }
}