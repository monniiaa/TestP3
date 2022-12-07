using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneAnimator : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera cameraOne;
    [SerializeField]
    private CinemachineVirtualCamera cameraTwo;

    [SerializeField]
    private int time;
    public float asteroidTime;



    private void Start()
    {
        cameraOne.gameObject.SetActive(true);
        StartCoroutine(CameraTransition(time, cameraOne, cameraTwo));
    }


    private void ChangeCamera(CinemachineVirtualCamera initialCam, CinemachineVirtualCamera endCam)
    {
        endCam.gameObject.SetActive(true);
        cameraOne.gameObject.SetActive(false);
        StartCoroutine(AsteroidsStarter());
    }


    IEnumerator CameraTransition(int time,CinemachineVirtualCamera initialcam, CinemachineVirtualCamera endCam)
    {
        yield return new WaitForSeconds(time);
        ChangeCamera(initialcam, endCam);
    }


    IEnumerator AsteroidsStarter()
    {
    yield return new WaitForSeconds(asteroidTime);

    SceneManager.LoadScene("Asteroids");
    }
}
