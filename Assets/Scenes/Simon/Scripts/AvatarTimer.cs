using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarTimer : MonoBehaviour
{
    public float avatarTimeRemaining;
    CharacterController controller;
    Animator avatarAnimator;
    PlayerInput playerInput;

    
    public bool controllerEnabled;

    void Start() 
    {
        controller = GetComponent<CharacterController>();   
        avatarAnimator = GetComponent<Animator>();
        playerInput = GetComponent <PlayerInput>();
    }
    void Update() 
    {
        if(avatarTimeRemaining > 0)
            {
            avatarTimeRemaining -= Time.deltaTime;
            }

        if(avatarTimeRemaining <= 0)
        {
            if(!controllerEnabled)
            {
            controller.enabled = true;
            avatarAnimator.enabled = true;
            playerInput.enabled = true;
            controllerEnabled = true;
            }
        }
}
}
