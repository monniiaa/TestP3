using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasActivator : MonoBehaviour
{
    public GameObject interactionPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activator(GameObject panel)
    {
        panel.SetActive(true);
    }
    public void Disactivator(GameObject panel)
    {
        panel.SetActive(false);

    }
}
