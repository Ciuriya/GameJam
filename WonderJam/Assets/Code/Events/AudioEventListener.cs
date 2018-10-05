using UnityEngine;
using UnityEngine.Events;

public class AudioEventListener : GameEventListener
{
	public Sound m_sound;
	private AudioSource m_source;

	protected override void OnEnable()
	{
		base.OnEnable();

		m_source = gameObject.AddComponent<AudioSource>();
	}

	protected override void OnDisable()
	{
		base.OnDisable();

		Destroy(m_source);
	}

	public void SetupSound()
	{
		m_sound.Setup(m_source);
	}

	public void Play()
	{
		m_source.Play();
	}

	public void Stop()
	{
		m_source.Stop();
	}
}