//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentAlarm : IComponent
	{

		public int target = -1;
		public float radius;

		public void Copy(int entityID)
		{
			var component = Storage<ComponentAlarm>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentAlarmInit()
		{
			Storage<ComponentAlarm>.Instance.Creator = () => { return new ComponentAlarm(); };
		}

		public static ComponentAlarm ComponentAlarm(in this ent entity)
		{
			return Storage<ComponentAlarm>.Instance.components[entity];
		}

	}
}