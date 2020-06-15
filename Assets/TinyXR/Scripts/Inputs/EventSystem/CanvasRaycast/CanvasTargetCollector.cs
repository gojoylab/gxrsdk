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
    using System.Collections.Generic;
    using UnityEngine;

    public class CanvasTargetCollector : MonoBehaviour
    {
        private static readonly List<ICanvasRaycastTarget> canvases = new List<ICanvasRaycastTarget>();

        public static void AddTarget(ICanvasRaycastTarget obj)
        {
            if(obj != null)
                canvases.Add(obj);
        }

        public static void RemoveTarget(ICanvasRaycastTarget obj)
        {
            if (obj != null)
                canvases.Remove(obj);
        }

        public static List<ICanvasRaycastTarget> GetCanvases()
        {
            return canvases;
        }
    }

}