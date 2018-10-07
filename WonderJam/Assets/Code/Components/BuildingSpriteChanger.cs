using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpriteChanger : MonoBehaviour {


    public Sprite m_summerSprite;
    public Sprite m_winterSprite;
    public GameEvent seasonChangeEvent;
    public SeasonVariable m_currentSeason;
    public Season m_seasonSpring;
    public Season m_seasonSummer;
    public Season m_seasonFall;
    public Season m_seasonWinter;

    //***WARNING THIS CODE MIGHT MAKE YOU THROW UP A LITTLE IN YOUR MOUTH***
    public void ChangeSprite()
    {
        //LoadSprite to change

        //Load summer sprite and apply color to it
        if (m_currentSeason.Value == m_seasonSpring)
        {

        }

        //Load summer sprite witch summercolor
        if (m_currentSeason.Value == m_seasonSummer)
        {

        }

        //Load summer sprite and apply color
        if (m_currentSeason.Value == m_seasonFall)
        {

        }

        //Load Winter sprite With base color
        if (m_currentSeason.Value == m_seasonWinter)
        {

        }

    }

    
}
