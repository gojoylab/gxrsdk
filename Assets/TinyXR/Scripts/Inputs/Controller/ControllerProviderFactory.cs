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
    using System;

    internal static class ControllerProviderFactory
    {
        public static Type androidControllerProviderType = typeof(TXRControllerProvider);

        public static ControllerProviderBase CreateControllerProvider(ControllerState[] states)
        {
            ControllerProviderBase provider = CreateControllerProvider(androidControllerProviderType, states);
            return provider;
        }

        private static ControllerProviderBase CreateControllerProvider(Type providerType, ControllerState[] states)
        {
            if (providerType != null)
            {
                object parserObj = Activator.CreateInstance(providerType, new object[] { states });
                if (parserObj is ControllerProviderBase)
                    return parserObj as ControllerProviderBase;
            }
            return null;
        }
    }
}