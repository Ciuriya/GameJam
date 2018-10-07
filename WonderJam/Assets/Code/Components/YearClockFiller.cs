using UnityEngine;
using UnityEngine.UI;

public class YearClockFiller : MonoBehaviour
{
    [Tooltip("Current year ratio on the clock.")]
    public FloatVariable m_currentYearRatio;

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
       m_image.fillAmount = m_currentYearRatio.Value;
    }
}
