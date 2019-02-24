//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

namespace Pixeye
{
	[System.Serializable]
	public class ComponentMove : IComponent
	{
		public int distanceToTarget = 0;
	}

	public static class ExtensionComponentMove
	{
		public static ComponentMove ComponentMove(this int entity) { return Storage<ComponentMove>.Instance.components[entity]; }

		public static bool TryGetComponentMove(this int entity, out ComponentMove component)
		{
			component = Storage<ComponentMove>.Instance.TryGet(entity);
			return component != null;
		}

		public static bool HasComponentMove(this int entity) { return Storage<ComponentMove>.Instance.HasComponent(entity); }
	}
}