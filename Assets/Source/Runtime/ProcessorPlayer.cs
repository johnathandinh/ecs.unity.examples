//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/21/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class ProcessorPlayer : Processor, ITick
	{

		public static Group<ComponentPlayer> group_players;
		public Group<ComponentPlayer, ComponentWeapon> group_players_armed;

		 
		public void Tick()
		{
			foreach (var entity in group_players)
			{
				var cPlayer = entity.ComponentPlayer();

				Debug.Log(string.Format("{0} with id {1}", cPlayer.name, entity.id));
			}

			foreach (var entity in group_players_armed)
			{
				var cPlayer = entity.ComponentPlayer();
				var cWeapon = entity.ComponentWeapon();
				Debug.Log(string.Format("{0} with id {1} holds {2}", cPlayer.name, entity.id, cWeapon.name));
			}
		}

	}
}