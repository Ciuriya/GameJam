using UnityEngine;
using UnityEngine.UI;

public class YearClockFiller : MonoBehaviour
{
    [Tooltip("Current season  on the clock.")]
    public SeasonVariable m_currentSeason;

    [Tooltip("Minimum fill amount the clock can have.")]
    public FloatReference m_minimumClockFill;

    [Tooltip("Maximum fill amount the clock can have.")]
    public FloatReference m_maximumClockFill;

    [Tooltip("Image to set to fill in the clock.")]
    public Image m_image;

    public void OnEnable()
    {
        UpdateClock();
    }

    public void UpdateClock()
    {
        m_image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(m_minimumClockFill.Value, m_maximumClockFill.Value, m_currentSeason.Value.yearProgress));
    }
}
