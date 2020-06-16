# Gojoylab TinyXR SDK for Unity

Use Unity to build a augmented reality apps for Android with gojoylab glass.

Currently, only support Android platform. other platform will available soon.

Copyright (c) 2020 Gojoylab Inc. All rights reserved.

## Downloads

The latest `TinyXR_*.unitypackage`, `xrcore-service-release_*.apk` and release notes
are available from the
[releases](//github.com/gojoylab/tinyxr-unity-sdk/releases)
page.

You can also clone and use the `gojoylab/tinyxr-unity-sdk` git repository
directly in a Unity project.


## Getting Started

#### Hardware Checklist
- An Android mobile phone device (with Gyroscope).
- A pair of gojoylab glass, set the glass into 3D mode

> NOTE:
> Currently SDK won't support 2D - 3D switch dynamically.

#### Software Checklist
- The TinyXR SDK for Unity requires
[Unity 2018.2.X or higher](//unity3d.com/get-unity/download) with Android Build Support. 
> NOTE: Lts version [2019.4.0f1](//unity3d.com/get-unity/download) is strongly recommended.
- Download `TinyXR_*.unitypackage` and `xrcore-service-release_*.apk` from [releases](//github.com/gojoylab/tinyxr-unity-sdk/releases)
page.
- install `xrcore-service-release_*.apk` on your mobile device.

## Creating a Unity Project
- Open Unity and create a new 3D project.
- File > Build Settings... > Platform choose Android > Switch Platform
- SetPlayer Settings > Other Settings > Scritping Runtime Version to .net 4.x Equivalent
- Import TinyXRSDK for Unity
  - Select Assets > Import Package > Custom Package.
  - Select the `TinyXR_0.9.1.unitypackage` that you downloaded.
  - In the Importing Package dialog, make sure that all package options are selected and click Import.
  - Drag `TXRCameraRig` and `TXRInput` prefab to the scenes and delete `Main Camera`.
  - Select TinyXRSDK > PreprocessBuildForAndroid.
  - Select TinyXRSDK > Project Tips to check your player settins.

Now you can create what you want.

## Demos

In this SDK, we provide two demos.

- Input - Interact
- VideoDemo

### Input - Interact, Your First Sample App
Find the `Input - ainteract` sample app in the Unity Project window by selecting Assets > TinyXR > Demos > Input-Interact.
#### Configure Build Settings
- Go to File > Build Settings.
- Select Android and click Switch Platform.
- In the Build Settings window, click Player Settings.
- In the Inspector window, configure player settings as follows:

Setting | Value
---|---
Player Settings > Resolution and Presentation > Default Orientation | Portrait
Player Settings > Other Settings > Auto Graphics API | false
Player Settings > Other Settings > Graphics APIs | OpenGLES3
Player Settings > Other Settings > Package Name	Create a unique app ID using a Java package name format. | For example, use com.tinyxr.input
Player Settings > Other Settings > Minimum API Level | Android 8.0 or higher
Player Settings > Other Settings > Target API Level | Android 8.0 or higher
Player Settings > Other Settings > Write Permission | External(SDCard)
Player Settings > Other Settings > Allow 'unsafe' code | true
Project Settings > Quality > V Sync Count | Don't Sync

#### Build and Run
- In the Unity Build Settings window, click Build. Install your app through Android Debug Bridge (adb) after the build is successful.
- Disconnect the computing unit with your PC, and then connect it to the glasses.
- If it is the first time you connect the glass to mobile device, you need to authrize usb permission to xrcore service.
- If it is the first time you run this app, you need to authrize the app permission
- Launch the app, you can use mobile device as a controller. `HOME` key for recenter, `APP` key to appear exit app Window. `TRIGGER` key to select object, hold `TRIGGER` and move the device for drag moving objects