//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentMove : IComponent
	{

		public int distanceToTarget = 0;
		public void Copy(int entityID)
		{
			var component = Storage<ComponentMove>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentMoveInit()
		{
			Storage<ComponentMove>.Instance.Creator = () => { return new ComponentMove(); };
		}

		public static ComponentMove ComponentMove(in this ent entity)
		{
			return Storage<ComponentMove>.Instance.components[entity];
		}

	}
}