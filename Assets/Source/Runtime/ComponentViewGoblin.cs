//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentViewGoblin : IComponent
	{

		public void Copy(int entityID)
		{
			var component = Storage<ComponentViewGoblin>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
	 
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentViewGoblinInit()
		{
			Storage<ComponentViewGoblin>.Instance.Creator = () => { return new ComponentViewGoblin(); };
		}

		public static ComponentViewGoblin ComponentViewGoblin(in this ent entity)
		{
			return Storage<ComponentViewGoblin>.Instance.components[entity];
		}

	}
}