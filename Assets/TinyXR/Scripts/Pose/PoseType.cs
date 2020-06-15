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

    /**
    * @brief Eye pose data.
    */
    public struct EyePoseData
    {
        /**
        * Left eye pose.
        */
        public Pose LEyePose;

        /**
        * Right eye pose.
        */
        public Pose REyePose;
    }

    /**
    * @brief Eye project matrix.
    */
    public struct EyeProjectMatrixData
    {
        /**
        * Left eye projectmatrix.
        */
        public Matrix4x4 LEyeMatrix;

        /**
        * Right eye projectmatrix.
        */
        public Matrix4x4 REyeMatrix;

        /**
        * RGB eye projectmatrix.
        */
        public Matrix4x4 RGBEyeMatrix;
    }
}