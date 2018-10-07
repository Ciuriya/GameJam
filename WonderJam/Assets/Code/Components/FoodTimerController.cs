using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTimerController : MonoBehaviour
{
    private const float HEALTH_LOST = 0.05f;
    private const float BASE_FOOD_LOST = 5; //qty of food lost every second;
    private const float STARVATION_THICK_DELAY = 1;
    private float lastHit;

    public FloatReference currentFood;
    public FloatReference maxHealth;
    UnitHealth unitHealth;
    //GameObject damager;   

    // Use this for initialization
    void Start()
    {
        lastHit = 1f;
        unitHealth = GetComponent<UnitHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFood.Value == 0f)
        {
            currentFood.m_variable.Value = currentFood.Value - (BASE_FOOD_LOST * Time.deltaTime);
            if (currentFood.Value < 0)
            {
                currentFood.m_variable.Value = 0;
            }
        }
        else
        {
            if (lastHit - STARVATION_THICK_DELAY <= 0) ;
            {
                lastHit = Time.time;
                unitHealth.Starvation(maxHealth.Value * HEALTH_LOST);
            }
        }
    }
}

