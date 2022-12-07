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
    [SerializeField] GameObject avatarCamera;
    [SerializeField] Transform avatarCamera2;
    [SerializeField] Transform roomate;


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
        yield return new WaitForSeconds(svarUISwitchTime);

        avatarCamera.SetActive(true);
        avatar.transform.LookAt(avatarCamera2);
        avatar.transform.eulerAngles = new Vector3(0,avatar.transform.eulerAngles.y,0);
        yield return new WaitForSeconds(2);
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

    

    yield return new WaitForSeconds(confrontationTime);
    
    avatar.transform.LookAt(roomate);
    avatar.transform.eulerAngles = new Vector3(0,avatar.transform.eulerAngles.y,0);
    
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
