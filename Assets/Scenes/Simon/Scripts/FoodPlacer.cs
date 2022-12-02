using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodPlacer : MonoBehaviour
{
    public GameObject food;
    public GameObject køkkenBord;
    public bool foodPickedUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FoodPlacement(GameObject foodPlace)
    {
    food.tag = "Untagged";
    food.transform.SetParent(foodPlace.transform);
    food.transform.position = foodPlace.transform.position;
    food.transform.rotation = foodPlace.transform.rotation;
    food.transform.localScale = new Vector3(1.7f, 1f, 1f);
    //food.transform.localScale= new Vector3(1f, 1f, 1f);
    //food.transform.Rotate(0, 0, 0);

    Debug.Log("placed food");
    }

    public void PickedUpFood()
    {
    if(!foodPickedUp)
    {
    køkkenBord.SetActive(true);
    foodPickedUp = true;
    }
    }
}
