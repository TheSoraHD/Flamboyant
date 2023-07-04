using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehaviour : MonoBehaviour
{
    public float percentage;
    public float playerCalibration = 0.5f;
    public Camera cam;
    //CinemachineVirtualCamera cam;

    private void Start()
    {
        //cam = GetComponent<CinemachineVirtualCamera>();
        //cam = GetComponent<Camera>();
    }

    public bool CheckXPercentageMargin(float x)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.GetComponent<Renderer>().bounds.center);
        print("uwux");
        print(viewPos.x);
        print(percentage);
        float halfScreen = percentage / 2.0f;
        if (x < 0.0f && viewPos.x < playerCalibration + 0.5f - halfScreen)
            return false;
        else if (x > 0.0f && viewPos.x > playerCalibration + 0.5f + halfScreen)
            return false;
        return true;
    }
    public bool CheckYPercentageMargin()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        print("uwuy");
        print(viewPos.y);
        print(percentage);
        if (viewPos.y < percentage || viewPos.y > percentage)
            return true;
        return true;
    }

    public void ForceAspectRatio()
    {
        //Force 16:9 by default
        //TO-DO: Implement!
    }
}
