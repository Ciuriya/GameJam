using UnityEngine;
using UnityEngine.UI;

public class ImageFillSetter : MonoBehaviour
{
	[Tooltip("Current fill amount on the image.")]
	public FloatReference m_fillAmount;

	[Tooltip("Minimum fill amount the image can have.")]
	public FloatReference m_minimumFill;

	[Tooltip("Maximum fill amount the image can have.")]
	public FloatReference m_maximumFill;

	[Tooltip("Image to set the fill amount on.")]
	public Image m_image;

    public void OnEnable()
    {
        UpdateFill();
    }

    public void UpdateFill()
    {
        m_image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(m_minimumFill.Value, m_maximumFill.Value, m_fillAmount.Value));
    }
}
