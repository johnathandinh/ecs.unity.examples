//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

namespace Pixeye
{
	public class ActorMovingCube : Actor
	{
		[FoldoutGroup("Setup")]
		public ComponentMotion componentMotion;

		protected override void Setup()
		{
			Add(componentMotion);
		}
	}
}