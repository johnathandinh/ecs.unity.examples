//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games

using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Pixeye.Framework
{
	public class EditorWindowFramework : EditorWindow
	{

		[MenuItem("Tools/Actors/Preferences", priority = -10)]
		public static void ShowWindow()
		{
			GetWindow<EditorWindowFramework>(false, "Actors preferences");
		}

		void OnGUI()
		{
			DataFramework.nameSpace = EditorGUILayout.TextField("Namespace: ", DataFramework.nameSpace);
			DataFramework.pathTagsEditor = EditorGUILayout.TextField("Tags path: ", DataFramework.pathTagsEditor);
		}

	}

	#if !ODIN_INSPECTOR
	[InitializeOnLoad]
	public static class EditorFramework
	{

		internal static bool needToRepaint;

		internal static Event currentEvent;
		internal static float t;

		static EditorFramework()
		{
			EditorApplication.update += Updating;
		}

		static void Check()
		{
		}

		static void Updating()
		{
			CheckMouse();

			if (needToRepaint)
			{
				t += UnityEngine.Time.deltaTime;

				if (t >= 0.3f)
				{
					t -= 0.3f;
					needToRepaint = false;
				}
			}
		}

		static void CheckMouse()
		{
			var ev = currentEvent;
			if (ev == null) return;

			if (ev.type == EventType.MouseMove)
				needToRepaint = true;
		}
	}
	#endif
}