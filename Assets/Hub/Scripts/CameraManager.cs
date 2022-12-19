using System;
using System.Collections;
using UnityEngine;

public class CameraManager: MonoBehaviour
{
    public Camera XRCamera, NonXRCamera;
    public GameObject mike;

    void Start()
    {
        ((IntroductionManager)IntroductionManager.Instance).OnIntroStart += StartIntroCamera;
        ((IntroductionManager)IntroductionManager.Instance).OnTutorialStart += StartTutorialCamera;
    }


    void StartIntroCamera()
    {
        mike.SetActive(false);
        XRCamera.enabled = false;
        NonXRCamera.enabled = true;
    }

    void StartTutorialCamera()
    {
        mike.SetActive(true);
        XRCamera.enabled = true;
        NonXRCamera.enabled = false;
    }
    
}
