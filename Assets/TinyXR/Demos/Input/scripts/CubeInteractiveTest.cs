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
    using UnityEngine.EventSystems;

    public class CubeInteractiveTest : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler,IDragHandler,IEndDragHandler
    {
        private MeshRenderer m_MeshRender;
        float dx;
        float dy;
        Vector3 newPos;

        void Awake()
        {
            m_MeshRender = transform.GetComponent<MeshRenderer>();
            newPos = Vector3.zero;
        }

        void Update()
        {
            //get controller rotation, and set the value to the cube transform
            transform.rotation = TXRInput.GetRotation();
        }

        //when pointer click, set the cube color to random color
        public void OnPointerClick(PointerEventData eventData)
        {
            m_MeshRender.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        //when pointer hover, set the cube color to green
        public void OnPointerEnter(PointerEventData eventData)
        {
            m_MeshRender.material.color = Color.green;
        }

        //when pointer exit hover, set the cube color to white
        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                Debug.Log("AlphaBAO: dragging");
                return;
            }
            m_MeshRender.material.color = Color.white;
        }

        public void OnBeginDrag (PointerEventData eventData)
        {
            dx = eventData.pointerPressRaycast.worldPosition.x - transform.position.x;
            dy = eventData.pointerPressRaycast.worldPosition.y - transform.position.y;
            Debug.Log("AlphaBAO: onbegindrag + dx = " + dx + ", dy = " + dy);
            Debug.Log("AlphaBAO: onbegindrag eventData.pointerPressRaycast.worldPosition = " + eventData.pointerPressRaycast.worldPosition);
            Debug.Log("AlphaBAO: onbegindrag transform.position = " + transform.position);
        }
        
        public void OnDrag (PointerEventData eventData)
        {
            newPos.x = eventData.pointerCurrentRaycast.worldPosition.x - dx;
            newPos.y = eventData.pointerCurrentRaycast.worldPosition.y - dy;
            newPos.z = transform.position.z;
            if (eventData.pointerCurrentRaycast.worldPosition.x == 0 || eventData.pointerCurrentRaycast.worldPosition.y == 0)
            {
                newPos.x = eventData.delta.x;
                newPos.y = eventData.delta.y;
                transform.Translate (newPos * Time.deltaTime);
                Debug.Log("AlphaBAO: OnDrag return");
                return;
            }
            transform.position = newPos;
            Debug.Log("AlphaBAO: OnDrag newPos = " + newPos);
        }
        public void OnEndDrag (PointerEventData eventData)
        {
            Debug.Log ("OnEndDrag");
        }
    }
}