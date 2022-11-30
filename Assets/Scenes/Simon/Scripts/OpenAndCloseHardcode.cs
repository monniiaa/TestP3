using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseHardcode : MonoBehaviour
{
    public GameObject door;
    public bool isDoorOpen = false;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
    if(other.gameObject.CompareTag("Player"))
        {Debug.Log("Found tag");
        if(Input.GetKeyDown(KeyCode.E))
            {
            Debug.Log("Found key");
            if(isDoorOpen)
                {
                Close();
                isDoorOpen = false;
                Debug.Log("Closed" + isDoorOpen);
                } 
                else if (!isDoorOpen)
                {
                Open();   
                isDoorOpen = true;
                Debug.Log("Opened" + isDoorOpen);
                }
            }
        }
    }

    void Open()
    {
    door.transform.Rotate(0, -90, 0);
    Debug.Log("Opened");

    }

    void Close()
    {
    door.transform.Rotate(0, 90, 0);
    Debug.Log("Closed");
    }

    void OnTriggerEnter(Collider other)
    {
    canvas.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
    canvas.SetActive(false);
    }
}   
