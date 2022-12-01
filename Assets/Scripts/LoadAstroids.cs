using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadAstroids : MonoBehaviour
{
    public string sceneName;
    public int time;
    public Canvas canvas;
    public bool inGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
        if (inGame) canvas.gameObject.SetActive(false);
        StartCoroutine(LoadScene(sceneName, time));
    }


    IEnumerator LoadScene(string name, int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(name);
        if (inGame) canvas.gameObject.SetActive(true);

    }
}
