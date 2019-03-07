//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

using UnityEngine;

namespace Pixeye
{
	public class ActorTrigger : Actor
	{
		[FoldoutGroup("Setup")]
		public ComponentAlarm componentAlarm;

		protected override void Setup()
		{
			Add(componentAlarm);
		}


		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, componentAlarm.radius);
		}
	}
}