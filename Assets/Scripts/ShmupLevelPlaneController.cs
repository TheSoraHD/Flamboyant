using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class ShmupLevelPlaneController : MonoBehaviour
{
    private SplineAnimate[] m_splineAnimate;

    private void Start()
    {
        m_splineAnimate = GetComponents<SplineAnimate>();
    }

    private void Update()
    {
        if (m_splineAnimate[0].IsPlaying == false)
        {
            m_splineAnimate[1].Play();
        }
    }

}
