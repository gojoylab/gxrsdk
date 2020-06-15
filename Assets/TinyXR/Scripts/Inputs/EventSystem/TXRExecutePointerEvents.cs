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

    /// @cond EXCLUDE_FROM_DOXYGEN
    public class TXRExecutePointerEvents
    {

        public static readonly ExecuteEvents.EventFunction<IEventSystemHandler> PressEnterHandler = ExecuteEnter;
        private static void ExecuteEnter(IEventSystemHandler handler, BaseEventData eventData)
        {

        }

        public static readonly ExecuteEvents.EventFunction<IEventSystemHandler> PressExitHandler = ExecuteExit;
        private static void ExecuteExit(IEventSystemHandler handler, BaseEventData eventData)
        {

        }
    }
}