using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DestroyBehaviour : MonoBehaviour
{

    public GameObject FX;
    public float secondsToDeactivate;
    public bool selfDestroy;

    public void DestroyObject()
    {
        CreateFX();
        Destroy(this.gameObject);
    }

    public void Deactivate()
    {
        CreateFX();
        this.gameObject.SetActive(false);
    }

    public void StartDeactivation()
    {
        if (this.gameObject.activeInHierarchy)
            StartCoroutine(DeactivateAfterSeconds());
    }

    private IEnumerator DeactivateAfterSeconds()
    {
        float s = 0;
        while (s < secondsToDeactivate)
        {
            s = s + Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        this.gameObject.SetActive(false);
    }

    private void CreateFX()
    {
        if (FX != null)
        {
            if (FX.GetComponent<ParticleSystem>() != null)
            {
                GameObject ps = Instantiate(FX, transform.position, Quaternion.identity);
                ps.GetComponent<ParticleSystem>().Play();
            }
        }
    }


    private void OnEnable()
    {
        if(selfDestroy)
        {
            StartDeactivation();
        }
    }

}
