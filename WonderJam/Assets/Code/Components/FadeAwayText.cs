using UnityEngine;
using UnityEngine.UI;

public class FadeAwayText : MonoBehaviour
{
	public float m_speed;
	public float m_maxTime;
	private float m_startTime;

	void Awake()
	{
		m_startTime = Time.time * 1000;
	}
	
	void Update()
	{
		if (m_maxTime * 1000 + m_startTime < Time.time * 1000)
		{
			Destroy(gameObject);
		}

		transform.Translate(new Vector3(0, m_speed));

		float alphaPercentage = ((Time.time * 1000 - m_startTime) / (m_maxTime * 1000));

		Text text = GetComponent<Text>();
		text.color = new Color(text.color.r, text.color.g, text.color.b, 1 - alphaPercentage);
	}
}
