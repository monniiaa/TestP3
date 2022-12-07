using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnable : MonoBehaviour
{
    public float enableTime;
    public GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ParticlesEnable()
    {
        StartCoroutine(ParticleTimer());
    }

    IEnumerator ParticleTimer()
    {
        yield return new WaitForSeconds(enableTime);

        particle.SetActive(true);
    }
}
