//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/21/2019 

namespace Homebrew
{
	[System.Serializable]
	public class ComponentPlayer : IComponent
	{
		public string name;
	}

	public static class ExtensionComponentPlayer
	{
		public static ComponentPlayer ComponentPlayer(this int entity) { return Storage<ComponentPlayer>.Instance.components[entity]; }

		public static bool TryGetComponentPlayer(this int entity, out ComponentPlayer component)
		{
			component = Storage<ComponentPlayer>.Instance.TryGet(entity);
			return component != null;
		}

		public static bool HasComponentPlayer(this int entity) { return Storage<ComponentPlayer>.Instance.HasComponent(entity); }
	}
}