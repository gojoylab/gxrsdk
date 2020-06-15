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
    using UnityEngine.EventSystems;

    public class TXRPointerEventData : PointerEventData
    {
        public readonly TXRPointerRaycaster raycaster;

        public Vector3 position3D;
        public Quaternion rotation;

        public Vector3 position3DDelta;
        public Quaternion rotationDelta;

        public Vector3 pressPosition3D;
        public Quaternion pressRotation;

        public float pressDistance;
        public GameObject pressEnter;
        public bool pressPrecessed;

        public TXRPointerEventData(TXRPointerRaycaster raycaster, EventSystem eventSystem) : base(eventSystem)
        {
            this.raycaster = raycaster;
        }

        public virtual bool GetPress()
        {
            if (raycaster is TXRMultScrPointerRaycaster)
            {
                return MultiScreenController.SystemButtonState.pressing;
            }
            else
            {
                return TXRInput.GetButton(raycaster.RelatedHand, ControllerButton.TRIGGER);
            }
        }

        public virtual bool GetPressDown()
        {
            if (raycaster is TXRMultScrPointerRaycaster)
            {
                return MultiScreenController.SystemButtonState.pressDown;
            }
            else
            {
                return TXRInput.GetButtonDown(raycaster.RelatedHand, ControllerButton.TRIGGER);
            }
        }

        public virtual bool GetPressUp()
        {
            if (raycaster is TXRMultScrPointerRaycaster)
            {
                return MultiScreenController.SystemButtonState.pressUp;
            }
            else
            {
                return TXRInput.GetButtonUp(raycaster.RelatedHand, ControllerButton.TRIGGER);
            }
        }

    }
}