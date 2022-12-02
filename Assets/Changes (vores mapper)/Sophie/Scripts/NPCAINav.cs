using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAINav : MonoBehaviour
{

    public GameObject theDestination;
    public NavMeshAgent theAgent;


    
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
        theAgent.SetDestination(theDestination.transform.position);
    }

    

        
}
