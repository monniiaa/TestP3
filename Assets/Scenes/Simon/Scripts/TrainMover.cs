using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    public float incrementAccel;
    public float acceleration;
    public float maxSpeed;
    public bool moveTrain = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    if(moveTrain)
    {
        transform.Translate(0, 0, -acceleration * Time.deltaTime);

        if(acceleration <= maxSpeed)
            {
            acceleration += incrementAccel;
            }
    }

    }

    public void MoveTrain()
    {
        moveTrain = true;
        Debug.Log("activated");
    }
}

