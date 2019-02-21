//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/21/2019 

using UnityEngine;

namespace Homebrew
{
	public class StarterScripts : Starter
	{
		static readonly string[] weaponNames = {"Bone Crusher", "Iron Fist", "Sword"};
		static readonly string[] playerNames = {"Alfred", "Saitama", "Luffy"};

		protected override void Setup() { Add<ProcessingPlayer>(); }


		// usually you dont need Update method.
		void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				// create new player
				var composer = new EntityComposer(2);
				var cPlayer  = composer.Add<ComponentPlayer>();
				var cObject  = composer.Add<ComponentObject>();
				cPlayer.name = playerNames.Random();
				cObject.transform = this.Populate("Obj Player", Vector3.zero, Quaternion.identity);
				cObject.transform.AddGet<MonoEntity>().entity = composer.entity;
				composer.Deploy();
			}

			if (Input.GetKeyDown(KeyCode.W))
			{
				// groups can be global static!
				var players = ProcessingPlayer.groupPlayers;

				foreach (var entity in players)
				{
					// add new component to selected player entity
					var composer = new EntityComposer(entity, 1);
					var cWeapon  = composer.Add<ComponentWeapon>();
					cWeapon.name = weaponNames.Random();
					composer.Deploy();
				}
			}
		}
	}
}
