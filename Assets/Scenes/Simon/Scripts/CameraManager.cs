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

    public float trainCameraSwitchTime;
    public float posterCameraSwitchTime;
    public float svarUISwitchTime;
    public StarterAssetsInputs input;


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

        svarUI.SetActive(true);
        input.cursorLocked = false;
        input.cursorInputForLook = false;
        Cursor.lockState = CursorLockMode.None;
        //input.SetCursorVisible(false);
        
    }


}
