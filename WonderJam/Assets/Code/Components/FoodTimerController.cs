using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodTimerController : MonoBehaviour
{
    public float lostHealthPerSecond = 0.05f;
    public float baseFoodLost = 0.5f; //qty of food lost every second;
	public GameEvent updateEvent;
    private const float STARVATION_THICK_DELAY = 1;
    private float lastHit;

    public FloatReference currentFood;
    public FloatReference maxHealth;
    UnitHealth unitHealth;
	private float stackedFood;
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
		if (stackedFood >= 5f)
		{
			stackedFood = 0f;
			currentFood.m_variable.Value -= 5f;
			updateEvent.Raise();

			if (currentFood.Value < 0)
			{
				currentFood.m_variable.Value = 0;
			}
		}

        if (currentFood.Value > 0f)
        {
            stackedFood += (baseFoodLost * Time.deltaTime);
        }
        else
        {
			if (lastHit - STARVATION_THICK_DELAY <= 0)
			{
				lastHit = Time.time;
				unitHealth.Starvation(maxHealth.Value * lostHealthPerSecond);
			}
        }
    }
}

