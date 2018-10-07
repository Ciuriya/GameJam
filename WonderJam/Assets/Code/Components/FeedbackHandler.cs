using UnityEngine;
using UnityEngine.UI;

public class FeedbackHandler : MonoBehaviour
{
	public FeedbackRuntimeSet m_feedbacks;
	public GameObject m_feedbackCanvas;
	public GameObject m_feedbackTemplate;
	public Damager m_playerDamager;
	public Sprite m_playerDamageSprite;
	public Color m_gainColor;
	public Color m_lossColor;

	void OnEnable()
	{
		UpdateFeedbacks(false);
	}

	public void UpdateFeedbacks(bool p_change)
	{
		for(int i = 0; i < m_feedbacks.Length(); ++i)
		{
			Feedback feedback = m_feedbacks.m_items[i];
			float diff = feedback.UpdateLocalValue();

			if(Mathf.Abs(diff) > 0 && p_change)
			{
				GenerateFeedback(diff, feedback.m_spriteValue, false);
			}
		}
	}

	public void GenerateFeedback(float p_amount, Sprite p_sprite, bool p_moved)
	{
		GameObject feedback = Instantiate(m_feedbackTemplate, m_feedbackCanvas.transform);
		Image image = feedback.GetComponentInChildren<Image>();
		Text feedbackText = feedback.GetComponent<Text>();

		feedbackText.text = p_amount > 0 ? ("+" + p_amount) : ("-" + Mathf.Abs(p_amount));
		feedbackText.color = p_amount > 0 ? m_gainColor : m_lossColor;
		image.sprite = p_sprite;

		if(p_moved) feedback.transform.Translate(new Vector3(100, 0));

		feedback.SetActive(true);
	}

	public void GenerateFeedbackFromPlayerDamage()
	{
		GenerateFeedback(-m_playerDamager.m_damage.Value, m_playerDamageSprite, true);
	}
}
