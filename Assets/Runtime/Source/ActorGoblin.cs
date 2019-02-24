//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using UnityEngine;

namespace Pixeye
{
	public class ActorGoblin : Actor
	{
		/// <summary>
		/// Inherit from Actor class to describe components of the entity.
		/// </summary>
		[FoldoutGroup("Setup")]
		public ComponentViewGoblin componentViewGoblin;
 

		[FoldoutGroup("Setup")]
		public ComponentWeapon componentWeapon;

		[FoldoutGroup("Setup")]
		public ComponentState componentState;

		protected override void Setup()
		{
			 
			Add(componentViewGoblin);
			Add(componentWeapon);
			Add(componentState);
			Add<ComponentMove>();
		}
 
	}
}