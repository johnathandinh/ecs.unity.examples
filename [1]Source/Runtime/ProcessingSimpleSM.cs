//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/22/2019 

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pixeye
{
	public delegate void State(int entity);

	public class ProcessingSimpleSM : ProcessingBase, ITick
	{
		Group<ComponentTurret> groupTurrets;

		Dictionary<int, State> stateMap = new Dictionary<int, State>(3, new FastComparable());

		public ProcessingSimpleSM()
		{
			// fill stateMap with methods
			stateMap.Add(Tag.StateIdle, HandleStateIdle);
			stateMap.Add(Tag.StateMove, HandleStateMove);
			stateMap.Add(Tag.StateAttack, HandleStateAttack);

			// create turret

			var composer = new EntityComposer(1);
			composer.Add<ComponentTurret>();
			composer.Deploy();
		}

		public void Tick()
		{
			foreach (var entity in groupTurrets)
			{
				var cTurret = entity.ComponentTurret();

				if (cTurret.state != cTurret.statePrevious)
				{
					cTurret.statePrevious = cTurret.state;
					stateMap[cTurret.state](entity);
				}
			}
		}


		void HandleStateIdle(int entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : IDLE", entity));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = this.Between(Tag.StateMove, Tag.StateAttack); });
			
		}

		void HandleStateMove(int entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : MOVES", entity));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = Tag.StateIdle; });
		}

		void HandleStateAttack(int entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : ATTACKS", entity));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = Tag.StateIdle; });
		}
	}
}