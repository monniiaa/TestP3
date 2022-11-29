using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject tavleCamera;
    [SerializeField] GameObject posterCamera;
    [SerializeField] GameObject trainCamera;
    [SerializeField] GameObject svarUI;

    public float trainCameraSwitchTime;
    public float posterCameraSwitchTime;
    public float svarUISwitchTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

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
    }


}
