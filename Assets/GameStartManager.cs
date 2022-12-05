using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStartManager : MonoBehaviour
{
    public bool startCounter = true;
    public float currentTime;

    CharacterController controller;
    PlayerInput playerInput;
    public GameObject canvas;


    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        canvas.SetActive(true);
        controller.enabled = false;
        playerInput.enabled = false;

    }

    void Update()
    {
        if (startCounter)
        {
            currentTime -= 1 * Time.deltaTime;

            if (currentTime <= 0)
            {
                Debug.Log("enabled");
                currentTime = 0;
                canvas.SetActive(false);
                controller.enabled = true;
                playerInput.enabled = true;
                startCounter = false;
            }
        }

    }
}
