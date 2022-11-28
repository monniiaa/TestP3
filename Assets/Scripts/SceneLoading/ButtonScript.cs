using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    public void LoadSceneByIndex(int index)
    {
        ManageScenes.LoadScene(index);
    }

    public void LoadSceneByName(string name)
    {
        ManageScenes.LoadScene(name);
    }
}
