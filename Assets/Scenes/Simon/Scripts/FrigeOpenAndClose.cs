using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrigeOpenAndClose : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Open()
    {
   
    transform.Rotate(0, 90, 0);
    Debug.Log("Opened");
   
    }

    public void Close()
    {
    transform.Rotate(0, -90, 0);
    Debug.Log("Closed");
    }
}


    

