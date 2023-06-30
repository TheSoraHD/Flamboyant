using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBehaviour : MonoBehaviour
{
    public float percentage;
    public Camera cam;
    //CinemachineVirtualCamera cam;

    private void Start()
    {
        //cam = GetComponent<CinemachineVirtualCamera>();
        //cam = GetComponent<Camera>();
    }

    public bool CheckXPercentageMargin()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);
        print("uwux");
        print(viewPos.x);
        print(percentage);
        if (viewPos.x < percentage || viewPos.x > percentage)
            return true;
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
