using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarTimer : MonoBehaviour
{
    public float avatarTimeRemaining;
    CharacterController controller;
    public bool controllerEnabled;

    void Start() 
    {
        controller = GetComponent<CharacterController>();   
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
            controllerEnabled = true;
            }
        }
}
}
