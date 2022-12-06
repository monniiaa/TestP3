using UnityEngine;
using System.Collections;
using UnityEngine.UI;
  
public class AutomaticTimer : MonoBehaviour 
{
    public float timeRemaining;
    public bool timeStarter;
    public GameObject tavleInteractableChecker;
    public AudiManagerHouse audioManager;
    public AudioSource audiosource;
    public AudioClip audioclip;
    public GameObject voiceTriggerBox;
  
    void Start()
    {
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
            audioManager.EnqueueAudioClip(audioclip);
            voiceTriggerBox.SetActive(true);
            timeStarter = false;
        }
    }

    public void StartTimer()
    {
    timeStarter = true;
    }
    //public void PlayAlternative()
    //{
    //    audiosource.PlayDelayed(0);
    //}
}