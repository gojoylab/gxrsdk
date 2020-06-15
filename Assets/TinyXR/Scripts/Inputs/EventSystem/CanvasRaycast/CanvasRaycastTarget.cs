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
    using UnityEngine.EventSystems;

    public interface ICanvasRaycastTarget
    {
        Canvas canvas { get; }
        bool enabled { get; }
        bool ignoreReversedGraphics { get; }
    }

    /// <summary>
    /// The class enables an UGUI Canvas and its children to be interactive with TXRInput raycasters.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    [DisallowMultipleComponent]
    public class CanvasRaycastTarget : UIBehaviour, ICanvasRaycastTarget
    {
        private Canvas m_canvas;
        [SerializeField]
        private bool m_IgnoreReversedGraphics = true;

        public virtual Canvas canvas { get { return m_canvas ?? (m_canvas = GetComponent<Canvas>()); } }
        public bool ignoreReversedGraphics { get { return m_IgnoreReversedGraphics; } set { m_IgnoreReversedGraphics = value; } }

        protected override void OnEnable()
        {
            Debug.Log("OnEnable");
            base.OnEnable();
            CanvasTargetCollector.AddTarget(this);
        }

        protected override void OnDisable()
        {
            Debug.Log("OnDisable");
            base.OnDisable();
            CanvasTargetCollector.RemoveTarget(this);
        }
    }

}