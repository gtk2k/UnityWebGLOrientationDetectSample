using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fullScreenSupportLabel;
    [SerializeField] private TextMeshProUGUI orientationLabel;

    public Button fullScreenButton;
    public Button exitFullScreenButton;
    public Button lockButton;
    public Button unlockButton;

    void Start()
    {
        MobileOrientationDetector.OnOrientationChange += (angle) =>
        {
            if(angle == -999)
            {
                fullScreenSupportLabel.text = "FullScreen is not support";
                if(fullScreenButton != null)
                {
                    fullScreenButton.enabled = false;
                }
                return;
            }
            Debug.Log($"Angle: {angle}");
            orientationLabel.text = $"Angle: {angle}";
        };

        fullScreenButton.onClick.AddListener(() =>
        {

            MobileOrientationDetector.FullScreen();
        });
        /*
        
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
        Debug.Log("F");*/

        MobileOrientationDetector.Init();

    }
}
