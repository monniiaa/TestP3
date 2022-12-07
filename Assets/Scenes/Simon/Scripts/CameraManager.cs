using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject tavleCamera;
    [SerializeField] GameObject posterCamera;
    [SerializeField] GameObject trainCamera;
    [SerializeField] GameObject svarUI;
    [SerializeField] GameObject vaskCam;
    [SerializeField] GameObject confrontationCam;
    [SerializeField] GameObject OverTheShoulderCam;
    [SerializeField] GameObject skuffeCam;
    [SerializeField] GameObject avatar;
    [SerializeField] GameObject feelingsCam;
    [SerializeField] Transform roommate;

    public float trainCameraSwitchTime;
    public float posterCameraSwitchTime;
    public float svarUISwitchTime;
    public StarterAssetsInputs input;

    public float vaskTime;
    public float confrontationTime;
    public float OverTheShoulderTime;
    public float skuffeCamTime;


    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void TavleCameraEnable()
    {
    tavleCamera.SetActive(true);
    StartCoroutine(SvarUIActivator());
    }
    
    public void PosterCameraEnable()
    {
    posterCamera.SetActive(true);
    StartCoroutine(PosterCameraCancel());
    
    }
    public void TrainCameraEnable()
    {
    trainCamera.SetActive(true);
    StartCoroutine(TrainCameraCancel());
    }

    IEnumerator TrainCameraCancel()
    {
        Debug.Log("Jeg tæller");
        yield return new WaitForSeconds(trainCameraSwitchTime);

        trainCamera.SetActive(false);
    }

    IEnumerator PosterCameraCancel()
    {
        Debug.Log("Jeg tæller");
        yield return new WaitForSeconds(posterCameraSwitchTime);

        posterCamera.SetActive(false);
    }

    IEnumerator SvarUIActivator()
    {
        Debug.Log("Jeg tæller");
        yield return new WaitForSeconds(svarUISwitchTime);
        feelingsCam.SetActive(true);
        svarUI.SetActive(true);
        input.cursorLocked = false;
        input.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        //input.SetCursorVisible(false);
        
    }

    public void VaskToConfrontation()
    {
    vaskCam.SetActive(true);
    StartCoroutine(Confrontation());
    }

    IEnumerator Confrontation()
    {
        yield return new WaitForSeconds(vaskTime);

        confrontationCam.SetActive(true);

        avatar.transform.LookAt(roommate);

        yield return new WaitForSeconds(confrontationTime);

        OverTheShoulderCam.SetActive(true);

        yield return new WaitForSeconds(OverTheShoulderTime);

        svarUI.SetActive(true);

    }

    public void SkuffeCam()
    {
    skuffeCam.SetActive(true);
    StartCoroutine(SkuffeTimer());
    Debug.Log("skuffeCam Enabled");
    }

    IEnumerator SkuffeTimer()
    {

    yield return new WaitForSeconds(skuffeCamTime);

    skuffeCam.SetActive(false);
    }

}
