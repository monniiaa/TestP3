using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadAstroids : MonoBehaviour
{
    public string sceneName;
    public int time;
    public int time2;
    public Canvas canvas;
    public bool inGame = false;
    public AudioSource audioSource;
    public AudioClip clip;
    public GameObject fadeToBlack;
    // Start is called before the first frame update
    void Start()
    {
        
        if (inGame) canvas.gameObject.SetActive(false);
        StartCoroutine(LoadScene(sceneName, time, time2));
    }


    IEnumerator LoadScene(string name, int time, int time2)
    {
        yield return new WaitForSeconds(time);
        if (inGame) canvas.gameObject.SetActive(true);
        audioSource.Stop();
        audioSource.clip = clip; 
        audioSource.Play();
        fadeToBlack.SetActive(true);
        yield return new WaitForSeconds(time2);
        SceneManager.LoadScene(name);

    }
}
