using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableOpenAndClose : MonoBehaviour
{
    public bool pickupChecker;
    public bool inRangeToE;
    public KeyCode interactKey; 
    public UnityEvent interactionActionOpener; 
    public UnityEvent interactionActionCloser; 
    public UnityEvent interactionNearby;
    public UnityEvent interactionNotNearby;
    public bool isDoorOpen;
    //Collider m_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
    //m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    if(!isDoorOpen)
    {
    if(inRangeToE)

        {
        if(Input.GetKeyDown(interactKey))
            {
             interactionActionOpener.Invoke();
             isDoorOpen = true;
             pickupChecker = true;
            }
        }
    }

    if(isDoorOpen)
    {
    if(inRangeToE)

        {
        if(Input.GetKeyDown(interactKey))
            {
             interactionActionCloser.Invoke();
             isDoorOpen = false;
             pickupChecker = true;
            }
        }
    }
    
       if(!pickupChecker)
       {
        if(inRangeToE)
        {
            {
             interactionNearby.Invoke();
            }
            
        }
        }
        if(!inRangeToE)
        {
        interactionNotNearby.Invoke();
        }
    }
    
    

    private void OnTriggerEnter(Collider collision)
    {
    if(collision.gameObject.CompareTag("Player"))
        {
        inRangeToE = true;
        Debug.Log("You're in range, ma friend");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
    if(collision.gameObject.CompareTag("Player"))
        {
        inRangeToE = false;
        Debug.Log("You're not in range, ma friend");
        }
    }

    public void SelfDestroyer()
    {
    Destroy(this.gameObject);
    }

    public void ESelfActivator()
    {
    this.gameObject.SetActive(true);
    }
}


