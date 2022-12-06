using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject scenariosPanel;
    public GameObject avatarPanel;
    public GameObject settingsPanel;

    public Button avatar, scenarier, indstillinger, lavEnAvatar, scenarie1, scenarie2;

    // public Animator transition;
    // public float transitionTime = 5f;

    void Start()
    {
        avatar.onClick.AddListener(delegate { ChangePanel("avatar"); });
        scenarier.onClick.AddListener(delegate { ChangePanel("scenarier"); });
        indstillinger.onClick.AddListener(delegate { ChangePanel("indstillinger"); });
        lavEnAvatar.onClick.AddListener(delegate { ChangePanel("lavEnAvatar"); });
        scenarie1.onClick.AddListener(delegate { ChangePanel("scenarie1"); });
        scenarie2.onClick.AddListener(delegate { ChangePanel("scenarie2"); });
    }

    public void DisablePanels()
    {
        mainMenuPanel.SetActive(false);
        scenariosPanel.SetActive(false);
        avatarPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ChangePanel(string panelName)
    {
        switch (panelName)
        {
            case "avatar":
                DisablePanels();
                avatarPanel.SetActive(true);
                break;
            case "scenarier":
                DisablePanels();
                scenariosPanel.SetActive(true);
                break;
            case "indstillinger":
                DisablePanels();
                settingsPanel.SetActive(true);
                break;
            case "lavEnAvatar":
                DisablePanels();
                ChangeScene("FaceCamera");
                break;
            case "scenarie1":
                DisablePanels();
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[0].scenario = "Train scene";
                ChangeScene("Sims Train Scene");
                break;
            case "scenarie2":
                DisablePanels();
                GameObject.Find("CSVWriter").GetComponent<CSVWriter>().myPlayerList.player[1].scenario = "House scene";
                ChangeScene("House scene 1");
                break;
            default:
                Debug.Log("fejl i panels, buttons eller switch statements");
                break;
        }
    }

    public void BackButton()
    {
        DisablePanels();
        mainMenuPanel.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        // StartCoroutine(SceneTransition());

        SceneManager.LoadScene(sceneName);
    }

    /* IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    } */

    public void ExitGame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}

// Code for transition between scenes: Brackeys, 12.01.20, https://www.youtube.com/watch?v=CE9VOZivb3I