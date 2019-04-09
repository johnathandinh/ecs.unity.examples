//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/22/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentTurret : IComponent
	{

		public int state = Tag.StateIdle;
		public int statePrevious = Tag.StateNone;
		public void Copy(int entityID)
		{
			var component = Storage<ComponentTurret>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentTurretInit()
		{
			Storage<ComponentTurret>.Instance.Creator = () => { return new ComponentTurret(); };
		}

		public static ComponentTurret ComponentTurret(in this ent entity)
		{
			return Storage<ComponentTurret>.Instance.components[entity];
		}

	}
}