using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehaviour : MonoBehaviour {

    private int m_level = 0;
    public FloatVariable m_seasonModifier;
    public FloatVariable m_RessourceCapacity;
    public FloatVariable m_ressourceToGenerate;
    public GameEvent m_RessourceGenerated;

    //Verify if nessecary ressouces are owned in Interactions.
    public void LevelUp()
    {
        m_level++;
        m_RessourceCapacity.Value=(m_level * 10)+5;
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
