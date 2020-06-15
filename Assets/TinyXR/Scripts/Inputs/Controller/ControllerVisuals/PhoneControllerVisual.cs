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

    public class PhoneControllerVisual : MonoBehaviour, IControllerVisual
    {
        public void DestroySelf()
        {
            if (gameObject)
                Destroy(gameObject);
        }

        public void SetActive(bool isActive)
        {
            if (!gameObject)
                return;
            gameObject.SetActive(isActive);
        }

        public void UpdateVisual(ControllerState state)
        {
            if (!gameObject || !gameObject.activeSelf)
                return;

        }
    }
}