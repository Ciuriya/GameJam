using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;



public class TileChanger : MonoBehaviour {

    private Color m_springColor = new Color(255f / 255f, 155f / 255f, 125f / 255f);
    private Color m_fallColor = new Color(255f / 255f, 120f / 255f, 115f / 255f);
    private Color m_summerColor = new Color(255f / 255f, 255f / 255f, 180f / 255f);

    public SeasonVariable m_currentSeason;
    public Season m_seasonSpring;
    public Season m_seasonSummer;
    public Season m_seasonFall;
    public Season m_seasonWinter;

    public Tilemap m_summerTileMap;
    public Tilemap m_winterTileMap;

    //***WARNING THIS CODE MIGHT MAKE YOU THROW UP A LITTLE IN YOUR MOUTH***
    public void ChangeSprite()
    {


        //Load spring sprite and apply color to it
        if (m_currentSeason.Value == m_seasonSpring)
        {
            m_summerTileMap.color = m_springColor;
            m_winterTileMap.color=Color.clear;
        }

        //Load summer sprite witch summercolor
        if (m_currentSeason.Value == m_seasonSummer)
        {
            m_winterTileMap.color = Color.clear;
            m_summerTileMap.color = m_summerColor;
        }

        //Load fall sprite and apply color
        if (m_currentSeason.Value == m_seasonFall)
        {
            m_winterTileMap.color = Color.clear;
            m_summerTileMap.color = m_fallColor;
        }

        //Load Winter sprite With base color
        if (m_currentSeason.Value == m_seasonWinter)
        {
            m_summerTileMap.color = Color.clear;
            m_winterTileMap.color = Color.white;
        }

    }

}
