//  Project  : ACTORS
//  Contacts : Pixeye - ask@pixeye.games

#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif
using UnityEngine;

namespace Pixeye.Framework
{
	/// <summary>
	/// <para>Links a game object with specific entity.</para>
	/// </summary>
	public class MonoEntity : MonoBehaviour, IEntity
	{

		#if UNITY_EDITOR
		[FoldoutGroup("Main"), SerializeField, ReadOnly]
		public int _entity = -1;
		#endif

		[HideInInspector]
		public ent entity = -1;

		bool conditionInitialized;

		public virtual void OnEnable()
		{
			if (!conditionInitialized)
			{
				conditionInitialized = true;
				return;
			}

			CoreEntity.isAlive[entity] = true;
			CoreEntity.Delayed.Set(entity, 0, CoreEntity.Delayed.Action.Activate);
		}

		public virtual void OnDisable()
		{
			CoreEntity.isAlive[entity] = false;
			CoreEntity.Delayed.Set(entity, 0, CoreEntity.Delayed.Action.Deactivate);
		}

		public void Release()
		{
			entity.Release();
		}

		public ref readonly ent GetEntity()
		{
			return ref entity;
		}

	}
}