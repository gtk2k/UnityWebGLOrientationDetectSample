using AOT;
using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

public class MobileOrientationDetector : MonoBehaviour
{
    public delegate void dlgOrientationChange(int angle);
    public static event dlgOrientationChange OnOrientationChange;
    
    [DllImport("__Internal")]
    private static extern int JS_OrientationDetectorLib_Init(Action<int> eventHandler);

    [DllImport("__Internal")]
    private static extern int JS_OrientationDetectorLib_GetOrientation();

    [DllImport("__Internal")]
    private static extern void JS_OrientationDetectorLib_FullScreen();
    
    [DllImport("__Internal")]
    private static extern void JS_OrientationDetectorLib_ExitFullScreen();

    [DllImport("__Internal")]
    private static extern void JS_OrientationDetectorLib_Lock();

    [DllImport("__Internal")]
    private static extern void JS_OrientationDetectorLib_Unlock();


    [MonoPInvokeCallback(typeof(Action<int>))]
    private static void onOrientationChange (int angle)
    {
        OnOrientationChange.Invoke(angle);
    }

    public static void Init()
    {
        var res = JS_OrientationDetectorLib_Init(onOrientationChange);
        if (res == -1)
        {
            throw new Exception("This device does not support Screen Orientation API");
        }
    }

    public static int GetOrientation()
    {
        var angle = JS_OrientationDetectorLib_GetOrientation();
        return angle;
    }

    public static void FullScreen()
    {
        JS_OrientationDetectorLib_FullScreen();
    }

    public static void ExitFullScreen()
    {
        JS_OrientationDetectorLib_ExitFullScreen();
    }

    public static void ScreenLock()
    {
        JS_OrientationDetectorLib_Lock();
    }

    public static void ScreenUnlock()
    {
        JS_OrientationDetectorLib_Unlock();
    }
}
