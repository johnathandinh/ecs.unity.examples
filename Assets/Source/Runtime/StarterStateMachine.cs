//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public class StarterStateMachine : Starter
	{

		/// <summary>
		///  Use starter classes to register all scene processings. Processings are systems that do logic based on entity components.
		/// </summary>
		protected override void Setup()
		{
			Add<ProcessorGoblins>();
		}

		protected override void PostSetup()
		{
			Actor.Create("Obj Goblin");
		}

	}
}