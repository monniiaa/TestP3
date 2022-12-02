using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    public bool pickedUp;
    public GameObject whatCanIPickup;
    public GameObject playerRightHand;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUpObject()
    {
    if(!pickedUp)
    {
    whatCanIPickup.transform.SetParent(playerRightHand.transform);
    whatCanIPickup.transform.localScale= new Vector3(2f, 2f, 2f);
    whatCanIPickup.transform.localPosition = new Vector3(0.19f, 0.15f, -0.28f);
    pickedUp = true;
    }
    
    Debug.Log("Picking up");
    }

    public void TrashObject()
    {
    if(pickedUp)
        {
        Destroy(whatCanIPickup);
        Debug.Log("Destroyed");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
    if(other.CompareTag("PickableObject"))
        {
        whatCanIPickup = other.gameObject;
        Debug.Log("pleeeeease virk" + other.gameObject.name);
        }
    }
}
