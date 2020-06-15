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

    /// <summary>
    /// A tool for log.
    /// </summary>
    public class TXRDebugger
    {
#if UNITY_EDITOR
        public static bool EnableLog = false;
#else
        public static bool EnableLog = true;
#endif

        static public void Log(object message)
        {
            Log(message, null);
        }

        static public void Log(object message, Object context)
        {
            if (EnableLog)
            {
                Debug.Log(message, context);
            }
        }

        static public void LogFormat(string format, params object[] args)
        {
            if (EnableLog)
            {
                Debug.LogFormat(format, args);
            }
        }

        static public void LogError(object message)
        {
            LogError(message, null);
        }

        static public void LogError(object message, Object context)
        {
            if (EnableLog)
            {
                Debug.LogError(message, context);
            }
        }

        static public void LogWarning(object message)
        {
            LogWarning(message, null);
        }

        static public void LogWarning(object message, Object context)
        {
            if (EnableLog)
            {
                Debug.LogWarning(message, context);
            }
        }
    }
}