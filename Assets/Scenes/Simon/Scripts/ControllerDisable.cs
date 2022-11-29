using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDisable : MonoBehaviour
{
    CharacterController controller;
    public float controllerEnableTime;
    // Start is called before the first frame update
    void Start()
    {
    controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlDisable()
    {
    
    controller.enabled = false;
    transform.Rotate(0, -177, 0, Space.World);
    StartCoroutine(ControllerEnable());
    Debug.Log("Controls disabled");
    }

    public void FullControlDisable()
    {
    controller.enabled = false;
    }

    IEnumerator ControllerEnable()
    {
    yield return new WaitForSeconds(controllerEnableTime);

    controller.enabled = true;
    }
    
}
