using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FloatReference))]
public class FloatReferenceDrawer : PropertyDrawer
{

	/// <summary>
	/// Options to display in the popup to select constant or variable.
	/// </summary>
	private readonly string[] popupOptions = { "Use Constant", "Use Variable" };

	/// <summary> Cached style to use to draw the popup button. </summary>
	private GUIStyle popupStyle;

	public override void OnGUI(Rect p_position, SerializedProperty p_property, GUIContent p_label)
	{
		if(popupStyle == null)
		{
			popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
			popupStyle.imagePosition = ImagePosition.ImageOnly;
		}

		p_label = EditorGUI.BeginProperty(p_position, p_label, p_property);
		p_position = EditorGUI.PrefixLabel(p_position, p_label);

		EditorGUI.BeginChangeCheck();

		// get properties
		SerializedProperty useConstant = p_property.FindPropertyRelative("m_useConstant");
		SerializedProperty constantValue = p_property.FindPropertyRelative("m_constantValue");
		SerializedProperty variable = p_property.FindPropertyRelative("m_variable");

		// calculate rectangle for config button
		Rect buttonRect = new Rect(p_position);

		buttonRect.yMin += popupStyle.margin.top;
		buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
		p_position.xMin = buttonRect.xMax;

		// store old indent level and set it to 0, the PrefixLabel takes care of it
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		int result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);

		useConstant.boolValue = result == 0;

		EditorGUI.PropertyField(p_position, useConstant.boolValue ? constantValue : variable, GUIContent.none);

		if(EditorGUI.EndChangeCheck())	
			p_property.serializedObject.ApplyModifiedProperties();

		EditorGUI.indentLevel = indent;
		EditorGUI.EndProperty();
	}
}