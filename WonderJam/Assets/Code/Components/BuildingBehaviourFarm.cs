using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviourFarm : MonoBehaviour {

    private int m_upgradeCost = 1;
    public FloatVariable m_farmLevel;
    public FloatVariable m_seasonModifier;
    public FloatVariable m_foodRessource;
    public FloatVariable m_foodMax;
    public FloatVariable m_goldInPockets;
    public GameEvent m_GoldUsed;
    public GameEvent m_FoodGenerated;


    public void LevelUp()
    {
        if (m_goldInPockets.Value >= m_upgradeCost)
        {
            m_farmLevel.Value++;
            m_goldInPockets.Value -= m_upgradeCost;
            m_GoldUsed.Raise();
        }
    }

    public void GenerateFood()
    {
        m_foodRessource.Value = m_farmLevel.Value + m_seasonModifier.Value;
        if (m_foodRessource.Value > m_foodMax.Value)
        {
            m_foodRessource.Value = m_foodMax.Value;
        }
        m_FoodGenerated.Raise();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LevelUp();
            GenerateFood();
        }
    }


}
