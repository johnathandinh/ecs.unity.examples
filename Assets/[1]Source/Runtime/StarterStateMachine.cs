//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using UnityEngine;

namespace Homebrew
{
	public class StarterStateMachine : Starter
	{
		/// <summary>
		///  Use starter classes to register all scene processings. Processings are systems that do logic based on entity components.
		/// </summary>
		protected override void Setup() { Add<ProcessingGoblins>(); }

		protected override void PostSetup() { this.Populate("Obj Goblin", Vector3.zero, Quaternion.identity); }
	}
}