//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/22/2019 

namespace Homebrew
{
	[System.Serializable]
	public class ComponentTurret : IComponent
	{
		public int state = Tag.StateIdle;
		public int statePrevious = Tag.StateNone;
	}

	public static class ExtensionComponentTurret
	{
		public static ComponentTurret ComponentTurret(this int entity) { return Storage<ComponentTurret>.Instance.components[entity]; }

		public static bool TryGetComponentTurret(this int entity, out ComponentTurret component)
		{
			component = Storage<ComponentTurret>.Instance.TryGet(entity);
			return component != null;
		}

		public static bool HasComponentTurret(this int entity) { return Storage<ComponentTurret>.Instance.HasComponent(entity); }
	}
}