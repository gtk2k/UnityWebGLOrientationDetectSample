using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text txt;
    public Button fullScreenButton;
    public Button exitFullScreenButton;
    public Button lockButton;
    public Button unlockButton;

    void Start()
    {
        MobileOrientationDetector.OnOrientationChange += (angle) =>
        {
            Debug.Log($"Angle: {angle}");
            txt.text = $"Angle: {angle}";
        };
        Debug.Log("A");

        fullScreenButton.onClick.AddListener(() =>
        {
            MobileOrientationDetector.FullScreen();
        });
        Debug.Log("C");

        exitFullScreenButton.onClick.AddListener(() =>
        {
            MobileOrientationDetector.ExitFullScreen();
        });
        Debug.Log("D");

        lockButton.onClick.AddListener(() =>
        {
            MobileOrientationDetector.ScreenLock();
        });
        Debug.Log("E");

        unlockButton.onClick.AddListener(() =>
        {
            MobileOrientationDetector.ScreenUnlock();
        });
        Debug.Log("F");

        MobileOrientationDetector.Init();
        Debug.Log("G");

    }
}
