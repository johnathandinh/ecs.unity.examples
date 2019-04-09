//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	[System.Serializable]
	public class ComponentState : IComponent
	{

		/// <summary>
		/// TagFilter allows putting a tag to the int variable. Choose Tag class where your tags defined.
		/// </summary>
		[TagFilter(typeof(Tag))]
		public int current = -1;

		[TagFilter(typeof(Tag))]
		public int previous = -1;

		public void Copy(int entityID)
		{
			var component = Storage<ComponentState>.Instance.GetFromStorage(entityID);
		}
		public void Dispose()
		{
		}

	}

	public static partial class HelperComponents
	{

		[RuntimeInitializeOnLoadMethod]
		static void ComponentStateInit()
		{
			Storage<ComponentState>.Instance.Creator = () => { return new ComponentState(); };
		}

		public static ComponentState ComponentState(in this ent entity)
		{
			return Storage<ComponentState>.Instance.components[entity];
		}

	}
}