using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AvatarMenuManager : MonoBehaviour
{
    public GameObject bodyPanel;
    public GameObject clothesPanel;


    public void DisablePanels()
    {
        bodyPanel.SetActive(false);
        clothesPanel.SetActive(false);
    }

    public void BodyPanel()
    {
        DisablePanels();
        bodyPanel.SetActive(true);
    }

    public void ClothesPanel()
    {
        DisablePanels();
        clothesPanel.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}