using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            /* Vector3 newtarget = player.position;
            newtarget.y = transform.position.y;
            transform.LookAt(newtarget);
            */

            transform.LookAt(player);
       
        }
    }
}
