using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HousePanelSecond : MonoBehaviour
{
    public GameObject angryPanel;
    public GameObject worriedPanel;
    public GameObject confetti;

    public bool startCounter;
    public float currentTime;
    public float confettiTime;

    public Button angry1, angry2, angry3, angry4, angry5;
    public Button worried1, worried2, worried3, worried4, worried5;

    public bool angry1Clicked, angry2Clicked, angry3Clicked, angry4Clicked, angry5Clicked;
    public bool worried1Clicked, worried2Clicked, worried3Clicked, worried4Clicked, worried5Clicked;

    public AudioClip[] audioClips;
    public float timer;
    public string nextSceneName;
    public AudiManagerHouse audiManager;

    // Start is called before the first frame update
    void Start()
    {
        angry1.onClick.AddListener(delegate { CheckAngryAmount(1); });
        angry2.onClick.AddListener(delegate { CheckAngryAmount(2); });
        angry3.onClick.AddListener(delegate { CheckAngryAmount(3); });
        angry4.onClick.AddListener(delegate { CheckAngryAmount(4); });
        angry5.onClick.AddListener(delegate { CheckAngryAmount(5); });

        worried1.onClick.AddListener(delegate { CheckWorriedAmount(1); });
        worried2.onClick.AddListener(delegate { CheckWorriedAmount(2); });
        worried3.onClick.AddListener(delegate { CheckWorriedAmount(3); });
        worried4.onClick.AddListener(delegate { CheckWorriedAmount(4); });
        worried5.onClick.AddListener(delegate { CheckWorriedAmount(5); });

        if (GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feeling == "angry")
        {
            DisablePanels();
            audiManager.EnqueueAudioClip(audioClips[0]);
            angryPanel.SetActive(true);
        }
        else if (GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feeling == "worried")
        {
            DisablePanels();
            audiManager.EnqueueAudioClip(audioClips[1]);
            worriedPanel.SetActive(true);
        }
    }

    public void DisablePanels()
    {
        angryPanel.SetActive(false);
        worriedPanel.SetActive(false);
    }

    public void CheckAngryAmount(int feelingAmount)
    {
        switch (feelingAmount)
        {
            case 1:
                angry1Clicked = true;
                angry2Clicked = false;
                angry3Clicked = false;
                angry4Clicked = false;
                angry5Clicked = false;
                break;
            case 2:
                angry1Clicked = false;
                angry2Clicked = true;
                angry3Clicked = false;
                angry4Clicked = false;
                angry5Clicked = false;
                break;
            case 3:
                angry1Clicked = false;
                angry2Clicked = false;
                angry3Clicked = true;
                angry4Clicked = false;
                angry5Clicked = false;
                break;
            case 4:
                angry1Clicked = false;
                angry2Clicked = false;
                angry3Clicked = false;
                angry4Clicked = true;
                angry5Clicked = false;
                break;
            case 5:
                angry1Clicked = false;
                angry2Clicked = false;
                angry3Clicked = false;
                angry4Clicked = false;
                angry5Clicked = true;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void CheckWorriedAmount(int feelingAmount)
    {
        switch (feelingAmount)
        {
            case 1:
                worried1Clicked = true;
                worried2Clicked = false;
                worried3Clicked = false;
                worried4Clicked = false;
                worried5Clicked = false;
                break;
            case 2:
                worried1Clicked = false;
                worried2Clicked = true;
                worried3Clicked = false;
                worried4Clicked = false;
                worried5Clicked = false;
                break;
            case 3:
                worried1Clicked = false;
                worried2Clicked = false;
                worried3Clicked = true;
                worried4Clicked = false;
                worried5Clicked = false;
                break;
            case 4:
                worried1Clicked = false;
                worried2Clicked = false;
                worried3Clicked = false;
                worried4Clicked = true;
                worried5Clicked = false;
                break;
            case 5:
                worried1Clicked = false;
                worried2Clicked = false;
                worried3Clicked = false;
                worried4Clicked = false;
                worried5Clicked = true;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void AngryAmountPanel()
    {
        if (angry1Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 1;
            Debug.Log("angry panel + next");
        }
        else if (angry2Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 2;
            Debug.Log("angry panel + next");
        }
        else if (angry3Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 3;
            Debug.Log("angry panel + next");
        }
        else if (angry4Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 4;
            Debug.Log("angry panel + next");
        }
        else if (angry5Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 5;
            Debug.Log("angry panel + next");
        }
    }

    public void WorriedAmountPanel()
    {
        if (worried1Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 1;
            Debug.Log("worried panel + next");
        }
        else if (worried2Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 2;
            Debug.Log("worried panel + next");
        }
        else if (worried3Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 3;
            Debug.Log("worried panel + next");
        }
        else if (worried4Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 4;
            Debug.Log("worried panel + next");
        }
        else if (worried5Clicked)
        {
            audiManager.EnqueueAudioClip(audioClips[3]);
            DisablePanels();
            StartCoroutine(ConfettiSwitch());
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].feelingAmountAfter = 5;
            Debug.Log("worried panel + next");
        }
    }

    IEnumerator ConfettiSwitch()
    {
        confetti.SetActive(true);
        audiManager.EnqueueAudioClip(audioClips[2]);
        yield return new WaitForSeconds(confettiTime);

        SceneManager.LoadScene(nextSceneName);
    }

    public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

