using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public float currentTime;
    public float countdownTime;

    [SerializeField] Text countdownText;
    public bool startCounter = false;
   
    // Start is called before the first frame update
    void Start()
    {
        currentTime = countdownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (startCounter)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("0");

            if (currentTime <= 0)
            {
                currentTime = 0;
                countdownText.text = "";
                startCounter = false;
            }
        }

    }
}
