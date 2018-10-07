using UnityEngine;
using UnityEngine.UI;

public class FloatTextReplacer : MonoBehaviour
{
	[Tooltip("The text to replace.")]
	public Text m_text;

	[Tooltip("The variable to update the text to.")]
	public FloatVariable m_variable;

    public void OnEnable()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        m_text.text = m_variable.Value.ToString();
    }
}
