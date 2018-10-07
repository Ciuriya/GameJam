using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTimerController : MonoBehaviour
{
    private const float HEALTH_LOST = 0.5;
    private const float BASE_FOOD_LOST = 5; //qty of food lost every second;


    public FloatReference currentFood;
    //public Game    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFood == 0f)
        {
            currentFood = currentFood - (BASE_FOOD_LOST / Time.deltaTime);
            if (currentFood < 0)
            {
                currentFood = 0;
            }
        }
    }
}

