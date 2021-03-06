//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pixeye.Framework
{
	public class StarterKernel : MonoBehaviour
	{

		[FoldoutGroup("SetupData")]
		public DataSession gameSession;

		[FoldoutGroup("SetupData")]
		public DataSession gameSettings;

		[FoldoutGroup("SetupData")]
		public List<Pluggable> pluggables = new List<Pluggable>();

		[FoldoutGroup("Settings")]
		public int sizeEntities = 2048;
		[FoldoutGroup("Settings")]
		public int sizeComponents = 256;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		void PreStart()
		{
			SettingsEngine.SizeEntities = sizeEntities;
			SettingsEngine.SizeComponents = sizeComponents;
		}

		void Awake()
		{
			
			
			
			
			for (var i = 0; i < pluggables.Count; i++)
			{
				pluggables[i].Plug();
			}

			if (gameSession != null)
			{
				Toolbox.Add(gameSession);
			}
			if (gameSettings != null)
			{
				Toolbox.Add(gameSettings);
			}

			HandleFastPool<Timer>.Instance.Populate(50);
			
			
			
			
			
		}

		IEnumerator OnApplicationFocus(bool hasFocus)
		{
			if (Application.runInBackground) yield break;
			yield return new WaitForSeconds(0.01f);
			if (!hasFocus)
			{
				Time.Default.timeScaleCached = Time.Default.timeScale;
				Time.Default.timeScale = 0;
			}
			else
			{
				Time.Default.timeScale = Time.Default.timeScaleCached;
			}
		}

	}
}