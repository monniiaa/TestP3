using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableE : MonoBehaviour
{
    public bool pickupChecker;
    public bool inRangeToE;
    public KeyCode interactKey; 
    public UnityEvent interactionActionE; 
    public UnityEvent interactionNearby;
    public UnityEvent interactionNotNearby;
    Collider m_Collider;
    //Collider m_Collider;
    
    // Start is called before the first frame update
    void Start()
    {
    //m_Collider = GetComponent<Collider>();
    m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
    if(inRangeToE)

        {
        if(Input.GetKeyDown(interactKey))
            {
             interactionActionE.Invoke();
             //m_Collider.enabled = !m_Collider.enabled;
             pickupChecker = true;
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
    Destroy(this);
    }

    public void ESelfActivator()
    {
    this.gameObject.SetActive(true);
    }


    public void DestroyObject(GameObject button)
    {
        Destroy(button);
    }

    public void Destroyer(GameObject button)
    {
    Destroy(button);
    }

    public void PickedUp()
    {
    m_Collider.enabled = false;
    }

    public void NotInRangeToE()

    {
    inRangeToE = false;
    }
}


