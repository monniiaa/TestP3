using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class CanvasActivator : MonoBehaviour
{
    public GameObject interactionPanel;
    public GameObject mobilUI;
    public float mobilSamtaleTimer;
    public StarterAssetsInputs input;

    CharacterController controller;
    PlayerInput playerInput;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activator(GameObject panel)
    {
        panel.SetActive(true);

    }
    public void Disactivator(GameObject panel)
    {
        panel.SetActive(false);

    }
    public void MobilActivator()
    {
    mobilUI.SetActive(true);
    StartCoroutine(MobilSamtaleTimer());
    }

    IEnumerator MobilSamtaleTimer()
    {
    yield return new WaitForSeconds(mobilSamtaleTimer);

    mobilUI.SetActive(false);
    }

    public void CanvasDisactivate(GameObject panel)
    {
        panel.SetActive(false);
        input.cursorLocked = true;
        input.cursorInputForLook = true;

    }

    public void CanvasActivate(GameObject panel)
    {
        panel.SetActive(true);
        input.cursorLocked = false;
        input.cursorInputForLook = false;
        controller.enabled = false;
        playerInput.enabled = false;
    }
}
