//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/21/2019 

using UnityEngine;

namespace Homebrew
{
	public class ProcessingPlayer : ProcessingBase, ITick
	{
		public static Group<ComponentPlayer, ComponentObject> groupPlayers;
	    Group<ComponentPlayer, ComponentWeapon, ComponentObject> groupPlayersWithWeapon;

		public ProcessingPlayer() { }

		public void Tick()
		{
			foreach (var entity in groupPlayers)
			{
				var cPlayer = entity.ComponentPlayer();

				Debug.Log(string.Format("{0} with id {1}", cPlayer.name, entity));
			}

			foreach (var entity in groupPlayersWithWeapon)
			{
				var cPlayer = entity.ComponentPlayer();
				var cWeapon = entity.ComponentWeapon();
				Debug.Log(string.Format("{0} with id {1} holds {2}", cPlayer.name, entity, cWeapon.name));
			}
		}
	}
}