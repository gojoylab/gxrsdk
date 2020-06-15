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

    public class TXRHomeMenu : MonoBehaviour
    {
        public Button confirmBtn;
        public Button cancelBtn;

        private static TXRHomeMenu m_Instance;
        private static bool m_IsShowing = false;
        private static string m_MenuPrefabPath = "TXRUI/TXRHomeMenu";

        void Start()
        {
            confirmBtn.onClick.AddListener(OnComfirmButtonClick);
            cancelBtn.onClick.AddListener(OnCancelButtonClick);
        }

        void Update()
        {
            if (m_IsShowing && TXRInput.RaycastMode == RaycastModeEnum.Laser)
                FollowCamera();
        }

        private void OnComfirmButtonClick()
        {
            Hide();
            AppManager.QuitApplication();
        }

        private void OnCancelButtonClick()
        {
            Hide();
        }

        private void FollowCamera()
        {
            if (m_Instance && Camera.main)
            {
                m_Instance.transform.position = Camera.main.transform.position;
                m_Instance.transform.rotation = Camera.main.transform.rotation;
            }
        }

        private static void CreateMenu()
        {
            GameObject menuPrefab = Resources.Load<GameObject>(m_MenuPrefabPath);
            if (menuPrefab == null)
            {
                Debug.LogError("Can not find prefab: " + m_MenuPrefabPath);
                return;
            }
            GameObject menuGo = Instantiate(menuPrefab);
            m_Instance = menuGo.GetComponent<TXRHomeMenu>();
            if (m_Instance)
                DontDestroyOnLoad(menuGo);
            else
                Destroy(menuGo);
        }

        public static void Toggle()
        {
            if (m_IsShowing)
                Hide();
            else
                Show();
        }

        public static void Show()
        {
            if (m_Instance == null)
                CreateMenu();
            if (m_Instance)
            {
                m_Instance.gameObject.SetActive(true);
                m_IsShowing = true;
                if(TXRInput.RaycastMode == RaycastModeEnum.Gaze)
                    m_Instance.FollowCamera();
            }
        }

        public static void Hide()
        {
            if (m_Instance)
            {
                m_Instance.gameObject.SetActive(false);
                m_IsShowing = false;
            }
        }
    }
}