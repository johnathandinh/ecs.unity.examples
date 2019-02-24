//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

namespace Pixeye
{
	[System.Serializable]
	public class ComponentState : IComponent
	{
		/// <summary>
		/// TagFilter allows putting a tag to the int variable. Choose Tag class where your tags defined.
		/// </summary>
		
		
		[TagFilter(typeof(Tag))]
		public int current=-1;
		[TagFilter(typeof(Tag))]
		public int previous=-1;
	}

	public static class ExtensionComponentState
	{
		public static ComponentState ComponentState(this int entity) { return Storage<ComponentState>.Instance.components[entity]; }

		public static bool TryGetComponentState(this int entity, out ComponentState component)
		{
			component = Storage<ComponentState>.Instance.TryGet(entity);
			return component != null;
		}

		public static bool HasComponentState(this int entity) { return Storage<ComponentState>.Instance.HasComponent(entity); }
	}
}