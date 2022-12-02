using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class TrainPanelFirst : MonoBehaviour
{
    public GameObject choosePanel;
    public GameObject angryPanel;
    public GameObject worriedPanel;
    public StarterAssetsInputs input;

    public Button angry, worried, neutral;
    public Button angry1, angry2, angry3, angry4, angry5;
    public Button worried1, worried2, worried3, worried4, worried5;

    public bool angryClicked, worriedClicked, neutralClicked;
    public bool angry1Clicked, angry2Clicked, angry3Clicked, angry4Clicked, angry5Clicked;
    public bool worried1Clicked, worried2Clicked, worried3Clicked, worried4Clicked, worried5Clicked;

    public void Start()
    {
        // StartCoroutine(Time());

        angry.onClick.AddListener(delegate { CheckFeeling("angry"); });
        worried.onClick.AddListener(delegate { CheckFeeling("worried"); });
        neutral.onClick.AddListener(delegate { CheckFeeling("neutral"); });

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
    }

    public void DisablePanels()
    {
        choosePanel.SetActive(false);
        angryPanel.SetActive(false);
        worriedPanel.SetActive(false);
    }

    public void CheckFeeling(string buttonName)
    {
        switch (buttonName)
        {
            case "angry":
                angryClicked = true;
                worriedClicked = false;
                neutralClicked = false;
                break;
            case "worried":
                worriedClicked = true;
                angryClicked = false;
                neutralClicked = false;
                break;
            case "neutral":
                neutralClicked = true;
                angryClicked = false;
                worriedClicked = false;
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
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

    public void FeelingPanel()
    {
        if (angryClicked)
        {
            DisablePanels();
            angryPanel.SetActive(true);
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feeling = "angry";
            Debug.Log("angry panel + next");
        }
        else if (worriedClicked)
        {
            DisablePanels();
            worriedPanel.SetActive(true);
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feeling = "worried";
            Debug.Log("worried panel + next");
        }
        else if (neutralClicked)
        {
            DisablePanels();
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feeling = "neutral";
            ChangeScene("EndScene");
            Debug.Log("neutral panel + next");
        }
    }

    public void AngryAmountPanel()
    {
        if (angry1Clicked)
        {
            DisablePanels();
            ChangeScene("Train Scene 2");
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 1;
            Debug.Log("angry panel + next");
        }
        else if (angry2Clicked)
        {
            DisablePanels();
            ChangeScene("Train Scene 2");
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 2;
            Debug.Log("angry panel + next");
        }
        else if (angry3Clicked)
        {
            DisablePanels();
            ChangeScene("Train Scene 2");
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 3;
            Debug.Log("angry panel + next");
        }
        else if (angry4Clicked)
        {
            DisablePanels();
            ChangeScene("Train Scene 2");
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 4;
            Debug.Log("angry panel + next");
        }
        else if (angry5Clicked)
        {
            DisablePanels();
            ChangeScene("Train Scene 2");
            GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 5;
            Debug.Log("angry panel + next");
        }
    }

    public void WorriedAmountPanel()
    {
        if (worried1Clicked)
            {
                DisablePanels();
                ChangeScene("Train Scene 2");
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 1;
                Debug.Log("worried panel + next");
            }
        else if (worried2Clicked)
            {
                DisablePanels();
                ChangeScene("Train Scene 2");
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 2;
                Debug.Log("worried panel + next");
            }
        else if (worried3Clicked)
            {
                DisablePanels();
                ChangeScene("Train Scene 2");
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 3;
                Debug.Log("worried panel + next");
            }
        else if (worried4Clicked)
            {
                DisablePanels();
                ChangeScene("Train Scene 2");
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 4;
                Debug.Log("worried panel + next");
            }
        else if (worried5Clicked)
            {
                DisablePanels();
                ChangeScene("Train Scene 2");
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].feelingAmountBefore = 5;
                Debug.Log("worried panel + next");
            }
        }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

        /* IEnumerator Time()
        {
            yield return new WaitForSeconds(5f);
            ChoosePanel();
        }
        */
}

