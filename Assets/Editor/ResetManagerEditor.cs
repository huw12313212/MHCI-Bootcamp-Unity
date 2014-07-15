using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(ResetManager))]
public class ResetManagerEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		ResetManager resetManager = (ResetManager)target;

		if(GUILayout.Button("FindAll"))
		{
			resetManager.FindAllRigidBody();
			//Debug.Log("Hello World");
		}
	}
}