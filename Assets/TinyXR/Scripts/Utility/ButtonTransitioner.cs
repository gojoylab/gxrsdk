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
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    public class ButtonTransitioner : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public Color32 m_NormalColor = Color.grey;
    public Color32 m_HoverColor = Color.white;
    public Color32 m_DownColor = Color.red;

    private Image m_Image = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("ButtonTransitioner: OnPointerClick");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ButtonTransitioner: OnPointerDown");
        m_Image.color = m_DownColor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ButtonTransitioner: OnPointerEnter");
        m_Image.color = m_HoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("ButtonTransitioner: OnPointerExit");
        m_Image.color = m_NormalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("ButtonTransitioner: OnPointerUp");
        m_Image.color = m_HoverColor;
    }

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        m_Image.color = m_NormalColor;
    }
}

}