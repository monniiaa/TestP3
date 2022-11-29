using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightControl : MonoBehaviour
{
    public GameObject spotlight;

    public void DisableLight()
    {
        spotlight.SetActive(false);
    }

    public void ActiveLight()
    {
        spotlight.SetActive(true);
    }

    public void LightController()
    {
        /* if ( == true)
        {
            ActiveLight();
        }
        else
        {
            DisableLight();
        }
        */
    }
}
