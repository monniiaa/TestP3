using UnityEngine;
using System.Collections;
using UnityEngine.UI;
  
public class AutomaticTimer : MonoBehaviour 
{
    public float timeRemaining;
    public bool timeStarter;
    public GameObject tavleInteractableChecker;
    public AudioManager audioManager;
  
    void Start()
    {
        audioManager = AudioManager.instance;
    }
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
        audioManager.PlaySound(6, audioManager.narratorSource); 
            timeStarter = false;
        }
    }

    public void StartTimer()
    {
    timeStarter = true;
    }
}