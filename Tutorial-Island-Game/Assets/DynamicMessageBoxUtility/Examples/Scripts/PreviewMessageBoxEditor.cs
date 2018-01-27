using CustomMessageBoxes;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (StylePreviewer), true)]
public class PreviewMessageBoxEditor : Editor {

		private StylePreviewer script;

		public void OnEnable()
		{
			script = (StylePreviewer) target;
		}

	public override void OnInspectorGUI(){
		DrawDefaultInspector();

		EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
		if (GUILayout.Button("Preview"))
		{
			MessageBoxCreator.CreateMessageBox (script.style, script.customTitle, script.customMessage, script.customButtonText);
			EditorGUI.EndDisabledGroup();
		}

		if (GUILayout.Button ("Delete all")) 
		{
			MessageBoxCreator.DestroyAllMessageBoxes();
		}
	}
}
