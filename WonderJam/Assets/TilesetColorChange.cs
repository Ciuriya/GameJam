using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesetColorChange : MonoBehaviour {

    private Tilemap m_theTilemap;
    public SeasonVariable m_currentSeason;
    public Season m_seasonSpring;
    public Season m_seasonSummer;
    public Season m_seasonFall;
    public Season m_seasonWinter;
    private Color m_springColor = new Color(255f / 255f, 155f / 255f, 125f / 255f);
    private Color m_fallColor = new Color(255f / 255f, 120f / 255f, 115f / 255f);
    private Color m_summerColor = new Color(255f / 255f, 255f / 255f, 180f / 255f);
    private Color m_baseColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);

    public void ChangeTilesetColor()
    {
        m_theTilemap = GetComponent<Tilemap>();

        //Load spring sprite and apply color to it
        if (m_currentSeason.Value == m_seasonSpring)
        {
            m_theTilemap.color = m_springColor;
        }

        //Load summer sprite witch summercolor
        if (m_currentSeason.Value == m_seasonSummer)
        {
            m_theTilemap.color = m_summerColor;
        }

        //Load fall sprite and apply color
        if (m_currentSeason.Value == m_seasonFall)
        {
            m_theTilemap.color = m_fallColor;
        }

        //Load Winter sprite With base color
        if (m_currentSeason.Value == m_seasonWinter)
        {
            m_theTilemap.color = m_baseColor;

        }
    }
}
