using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehaviour : MonoBehaviour
{
    public float percentageX, percentageY;
    public float playerCalibration = 0.0f;
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
        float halfScreen = percentageX / 2.0f;
        if (x < 0.0f && viewPos.x < playerCalibration + 0.5f - halfScreen)
            return false;
        else if (x > 0.0f && viewPos.x > playerCalibration + 0.5f + halfScreen)
            return false;
        return true;
    }
    public bool CheckYPercentageMargin(float y)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        if (y < 0.0f && viewPos.y < 0.0f + percentageY)
            return false;
        else if (y > 0.0f && viewPos.y > 1.0f - percentageY)
            return false;
        return true;
    }

    public void ForceAspectRatio()
    {
        //Force 16:9 by default
        //TO-DO: Implement!
    }
}
