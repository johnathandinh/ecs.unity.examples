//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentWeapon : IComponent
	{

		public string name;
		public void Copy(int entityID)
		{
			var component = Storage<ComponentWeapon>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentWeaponInit()
		{
			Storage<ComponentWeapon>.Instance.Creator = () => { return new ComponentWeapon(); };
		}

		public static ComponentWeapon ComponentWeapon(in this ent entity)
		{
			return Storage<ComponentWeapon>.Instance.components[entity];
		}

	}
}