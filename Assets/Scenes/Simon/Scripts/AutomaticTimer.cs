using UnityEngine;
using System.Collections;
using UnityEngine.UI;
  
public class AutomaticTimer : MonoBehaviour 
{
    public float timeRemaining;
    public bool timeStarter;
    public GameObject tavleInteractableChecker;
  
    void Update() 
    {
        if(timeStarter)
        {
            if(timeRemaining > 0)
            {
            timeRemaining -= Time.deltaTime;
            }
        }

        if(timeRemaining <= 0)
        {
        tavleInteractableChecker.SetActive(true);
        }
    }

    public void StartTimer()
    {
    timeStarter = true;
    }
}