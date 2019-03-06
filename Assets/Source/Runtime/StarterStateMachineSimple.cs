//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/22/2019 

namespace Pixeye
{
	public class StarterStateMachineSimple : Starter
	{
		/// <summary>
		///  Use starter classes to register all scene processings. Processings are systems that do logic based on entity components.
		/// </summary>
		protected override void Setup()
		{
			Add<ProcessingSimpleSM>();
			
		}
	}
}