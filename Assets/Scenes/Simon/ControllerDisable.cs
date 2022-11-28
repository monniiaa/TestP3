using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDisable : MonoBehaviour
{
    CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ControlDisable()
    {
    controller = GetComponent<CharacterController>();
    controller.enabled = false;
    transform.Rotate(0, -177, 0, Space.World);

    }
}
