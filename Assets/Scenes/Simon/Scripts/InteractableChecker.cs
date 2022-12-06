using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableChecker : MonoBehaviour
{
    public bool antiLooper;
    public bool secondAntiLooper;
    public bool inRange;
    public bool metroInRange;
    public UnityEvent interactionAction; 
    public UnityEvent secondInteractionAction;
    public UnityEvent thirdInteractionAction;
    public AudioSource audiosource;
    public AudioClip audioclip;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
   {

    if(inRange)
        {
        if(antiLooper == false)
            {
            interactionAction.Invoke();
            thirdInteractionAction.Invoke();
            antiLooper = true;
            }
        }
        
    
    if(metroInRange)
        {
        if(secondAntiLooper == false)
            {
            secondInteractionAction.Invoke();
            secondAntiLooper = true;
            }
        }
   }

    private void OnTriggerEnter(Collider collision)
    {
    if(collision.gameObject.CompareTag("Player"))
        {
        inRange = true;
        Debug.Log("You're in range, ma friend");
        }
    if(collision.gameObject.CompareTag("Metro"))
        {
        metroInRange = true;
        Debug.Log("Metro in range, ma friend");
        }
    }   

    public void SelfActivator()
    {
    this.gameObject.SetActive(true);
    
    
    }

    public void SelfDeactivator()
    {
    this.gameObject.SetActive(false);
    }
}
