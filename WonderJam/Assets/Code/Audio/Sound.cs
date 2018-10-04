using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu (menuName = "Audio/Sound")]
public class Sound : ScriptableObject
{
	public AudioClip m_clip;
	public FloatReference m_volume;
	public FloatReference m_volumeVariance;
	public FloatReference m_pitch;
	public FloatReference m_pitchVariance;
	public bool m_loop;

	public void Setup(AudioSource p_source)
	{
		p_source.clip = m_clip;
		p_source.volume = m_volume.Value * (1f + UnityEngine.Random.Range(-m_volumeVariance.Value / 2f, m_volumeVariance.Value / 2f));
		p_source.pitch = m_pitch.Value * (1f + UnityEngine.Random.Range(-m_pitchVariance.Value / 2f, m_pitchVariance.Value / 2f));
		p_source.loop = m_loop;
	}
}
