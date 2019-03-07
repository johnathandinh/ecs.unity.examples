//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/21/2019 

using UnityEngine;

namespace Pixeye
{
	public class ProcessingPlayer : ProcessingBase, ITick
	{
		public static Group<ComponentPlayer, ComponentObject> group_players;
	  public Group<ComponentPlayer, ComponentWeapon, ComponentObject> group_players_armed;

		public ProcessingPlayer() { }

		public void Tick()
		{
			foreach (var entity in group_players)
			{
				var cPlayer = entity.ComponentPlayer();

				Debug.Log(string.Format("{0} with id {1}", cPlayer.name, entity));
			}

			foreach (var entity in group_players_armed)
			{
				var cPlayer = entity.ComponentPlayer();
				var cWeapon = entity.ComponentWeapon();
				Debug.Log(string.Format("{0} with id {1} holds {2}", cPlayer.name, entity, cWeapon.name));
			}
		}
	}
}