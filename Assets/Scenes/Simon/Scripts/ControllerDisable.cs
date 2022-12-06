using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerDisable : MonoBehaviour
{
    CharacterController controller;
    Animator avatarAnimator;
    PlayerInput playerInput;
    public GameObject skuffeCam;
    public float controllerShortEnableTime;
    public float controllerLongEnableTime;
    public float controllerMediumEnableTime;
    // Start is called before the first frame update
    void Start()
    {
    controller = GetComponent<CharacterController>();
    avatarAnimator = GetComponent<Animator>();
    playerInput = GetComponent <PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlShortDisable()
    {
    
    controller.enabled = false;
    playerInput.enabled = false;
    //transform.Rotate(0, -177, 0, Space.World);
    StartCoroutine(ControllerShortEnable());
    Debug.Log("Controls disabled");
    }

    public void FullControlDisable()
    {
        controller.enabled = false;
        playerInput.enabled = false;
    }

    IEnumerator ControllerShortEnable()
    {
    yield return new WaitForSeconds(controllerShortEnableTime);

    controller.enabled = true;
    playerInput.enabled = true;
    }

    IEnumerator ControllerMediumEnable()
    {
    yield return new WaitForSeconds(controllerMediumEnableTime);

    controller.enabled = true;
    playerInput.enabled = true;
    }

    public void ControlMediumDisable()
    {
    controller.enabled = false;
    //avatarAnimator.enabled = false;
    playerInput.enabled = false;


    StartCoroutine(ControllerMediumEnable());
    }
    
    public void ControlLongDisable()
    {
    controller.enabled = false;
    //avatarAnimator.enabled = false;
    playerInput.enabled = false;


    StartCoroutine(ControllerLongEnable());
    }
    IEnumerator ControllerLongEnable()
    {
    yield return new WaitForSeconds(controllerLongEnableTime);

    controller.enabled = true;
    //avatarAnimator.enabled = true;
    playerInput.enabled = true;
    }
}
