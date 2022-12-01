using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneAnimator : MonoBehaviour
{
    [SerializeField]
    private Camera[] cinematicCameras;

    private void ChangeCamera(Camera initialCam, Camera endCam)
    {
        endCam.gameObject.SetActive(true);
        initialCam.gameObject.SetActive(false);
    }
}
