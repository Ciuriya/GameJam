using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

    private int m_level = 0;
    private int m_upgradePrice;
    public FloatVariable m_goldInPockets;
    public FloatVariable m_seasonModifier;
    public FloatVariable m_RessourceCapacity;
    public FloatVariable m_ressourceToGenerate;
    public GameEvent m_RessourceGenerated;
    public GameEvent m_GoldUsed;

    //Verify if nessecary ressouces are owned in Interactions.
    public void LevelUp()
    {
        if (m_goldInPockets.Value >= m_level * 7 + 5)
        {
            m_level++;
            m_RessourceCapacity.Value = (m_level * 10) + 5;
            m_goldInPockets.Value -= (m_level * 7 + 5);
            m_GoldUsed.Raise();
        }
    }

    public void GenerateRessources()
    {
        m_ressourceToGenerate.Value=m_ressourceToGenerate.Value + (m_level + m_seasonModifier.Value);
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            LevelUp();
            GenerateRessources();
            m_RessourceGenerated.Raise();
        }
    }


}
