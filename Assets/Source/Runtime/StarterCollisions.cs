//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

using Pixeye.Framework;

namespace Pixeye
{
	public class StarterCollisions : Starter
	{

		protected override void Setup()
		{
			Add<ProcessorCollisions>();
		}

	}
}