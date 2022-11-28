using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject tavleCamera;
    [SerializeField] GameObject posterCamera;

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
    }
    
    public void PosterCameraEnable()
    {
    posterCamera.SetActive(true);
    }

}
