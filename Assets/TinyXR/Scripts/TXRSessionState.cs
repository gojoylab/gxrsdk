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
    public enum TXRSessionState
    {
        UNINITIALIZED = 0,

        CREATED,

        TRACKING,

        PAUSED,

        STOPPED,

        LOSTTRACKING
    }
}