using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject scenariosPanel;
    public GameObject avatarPanel;
    public GameObject settingsPanel;

    public Animator transition;
    public float transitionTime = 5f;

    public void DisablePanels()
    {
        mainMenuPanel.SetActive(false);
        scenariosPanel.SetActive(false);
        avatarPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void AvatarPanel()
    {
        DisablePanels();
        avatarPanel.SetActive(true);
    }

    public void ScenariosPanel()
    {
        DisablePanels();
        scenariosPanel.SetActive(true);
    }

    public void SettingsPanel()
    {
        DisablePanels();
        settingsPanel.SetActive(true);
    }

    public void MainMenuPanel()
    {
        DisablePanels();
        mainMenuPanel.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(SceneTransition());

        SceneManager.LoadScene(sceneName);
    }

    IEnumerator SceneTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }

    public void ExitGame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}

// Code for transition between scenes: Brackeys, 12.01.20, https://www.youtube.com/watch?v=CE9VOZivb3I