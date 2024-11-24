using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(R.resource))]
public class DEBUG_EDITOR__R_resource : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		EditorGUI.indentLevel = 0;

		float partition = 0.3f;
		#region name
		EditorGUI.PropertyField(
			new Rect
			(
				position.x,
				position.y,
				position.width * partition,
				position.height
			),
			property.FindPropertyRelative("name"),
			GUIContent.none
		); 
		#endregion

		#region obj
		EditorGUI.PropertyField(
			new Rect
			(
				position.x + position.width * partition,
				position.y,
				position.width * (1 - partition),
				position.height
			),
			property.FindPropertyRelative("obj"),
			GUIContent.none
		); 
		#endregion

		EditorGUI.EndProperty();
		// base.OnGUI(position, property, label);
	}

}



