using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenClose : MonoBehaviour
{
    [SerializeField]
    private GameObject translateObject;
    public GameObject controlDoor;
    public GameObject controlFood;
    private bool _isOpen = false;
    [SerializeField]
    private bool rotate;

    bool _inRange;

    [SerializeField]
    private Vector3 translation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = true;
            //TODO:Activate canvas
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = false;
            //TODO:Activate canvas
        }
    }
    void Rotate(Vector3 translation)
    {
        translateObject.transform.Rotate(translation);
    }

    void Translate(Vector3 translation)
    {
        translateObject.transform.Translate(translation);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && _inRange)
        {
            if (_isOpen && rotate)
            {
                _isOpen = false;
                Rotate(translation);
                
                
            }
            else if (_isOpen && !rotate)
            {
                _isOpen = false;
                Translate(-translation);
            }
            else if (!_isOpen && rotate)
            {
                _isOpen = true;
                Rotate(-translation);
                controlDoor.SetActive(false);
                controlFood.SetActive(true);
            }
            else if (!_isOpen && !rotate)
            {
                _isOpen =true;
                Translate(translation);
            }
        }
    }

}