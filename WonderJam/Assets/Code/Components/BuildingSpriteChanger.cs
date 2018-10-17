using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpriteChanger : MonoBehaviour {


    public Sprite m_summerSprite;
    public Sprite m_winterSprite;
    public SeasonVariable m_currentSeason;
    public Season m_seasonSpring;
    public Season m_seasonSummer;
    public Season m_seasonFall;
    public Season m_seasonWinter;

	private Color m_springColor = new Color(1f, 1f, 1f); //new Color(255f/255f, 155f/255f, 125f/255f);
	private Color m_fallColor = new Color(255f/255f, 155f/255f, 125f/255f);//new Color(255f/255f, 120f/255f, 115f/255f);
	private Color m_summerColor = new Color(255f/255f, 255f/255f, 180f/255f);
    private Color m_baseColor = new Color(255f/255f, 255f/255f, 255f/255f);
    private SpriteRenderer m_theSprite;
    //***WARNING THIS CODE MIGHT MAKE YOU THROW UP A LITTLE IN YOUR MOUTH***
    public void ChangeSprite()
    {
        m_theSprite = GetComponent<SpriteRenderer>();

        //Load spring sprite and apply color to it
        if (m_currentSeason.Value == m_seasonSpring)
        {
            if(m_theSprite.sprite!=m_summerSprite)
                m_theSprite.sprite = m_summerSprite;
            m_theSprite.color=m_springColor;
        }

        //Load summer sprite witch summercolor
        if (m_currentSeason.Value == m_seasonSummer)
        {
            if (m_theSprite.sprite != m_summerSprite)
                m_theSprite.sprite = m_summerSprite;
            m_theSprite.color = m_summerColor;
        }

        //Load fall sprite and apply color
        if (m_currentSeason.Value == m_seasonFall)
        {
            if (m_theSprite.sprite != m_summerSprite)
                m_theSprite.sprite = m_summerSprite;
            m_theSprite.color = m_fallColor;
        }

        //Load Winter sprite With base color
        if (m_currentSeason.Value == m_seasonWinter)
        {
            if (m_theSprite.sprite != m_winterSprite)
                m_theSprite.sprite = m_winterSprite;
            m_theSprite.color = m_baseColor;

        }

    }

    
}
