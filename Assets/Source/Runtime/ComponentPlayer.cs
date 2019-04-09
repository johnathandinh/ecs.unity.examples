//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/21/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentPlayer : IComponent
	{
		public string name;
		public void Copy(int entityID)
		{
			var component = Storage<ComponentPlayer>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		 
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentPlayerInit()
		{
			Storage<ComponentPlayer>.Instance.Creator = () => { return new ComponentPlayer(); };
		}

		public static ComponentPlayer ComponentPlayer(in this ent entity)
		{
			return Storage<ComponentPlayer>.Instance.components[entity];
		}

	}
}