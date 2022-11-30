using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using StarterAssets;

public class FeelingsPanel : MonoBehaviour
{
    public GameObject choosePanel;
    public GameObject angryPanel;
    public GameObject nervousPanel;
    public StarterAssetsInputs input;


    public void Start()
    {
        DisablePanels();
        StartCoroutine(Time());
        
    }
    public void DisablePanels()
    {
        choosePanel.SetActive(false);
        angryPanel.SetActive(false);
        nervousPanel.SetActive(false);
    }

    public void CorrectPanel()
    {
       
    }

    public void ChoosePanel()
    {
        DisablePanels();
        choosePanel.SetActive(true);
        input.cursorLocked = false;
        input.cursorInputForLook = false;
        Cursor.visible = true;
    }

    public void AngryPanel()
    {
        DisablePanels();
        angryPanel.SetActive(true);
    }

    public void NervousPanel()
    {
        DisablePanels();
        nervousPanel.SetActive(true);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(5f);
        ChoosePanel();
    }
}
