//  Project : Actors-Examples
// Contacts : Pixeye - ask@pixeye.games
//     Date : 2/22/2019 

using System;
using System.Collections.Generic;
using Pixeye.Framework;
using UnityEngine;

namespace Pixeye
{
	public delegate void State(ent entity);

	public class ProcessorSimpleSM : Processor, ITick
	{

		public Group<ComponentTurret> group_turrets;

		Dictionary<int, State> stateMap = new Dictionary<int, State>(3, new FastComparable());

		public ProcessorSimpleSM()
		{
			// fill stateMap with methods
			stateMap.Add(Tag.StateIdle, HandleStateIdle);
			stateMap.Add(Tag.StateMove, HandleStateMove);
			stateMap.Add(Tag.StateAttack, HandleStateAttack);

			// create turret

//			var composer = new EntityComposer(1);
//			composer.Add<ComponentTurret>();
//			composer.Deploy();

			var entity = ent.Create();
			entity.Add<ComponentTurret>();
		}

		public void Tick()
		{
			foreach (var entity in group_turrets)
			{
				var cTurret = entity.ComponentTurret();

				if (cTurret.state != cTurret.statePrevious)
				{
					cTurret.statePrevious = cTurret.state;
					stateMap[cTurret.state](entity);
				}
			}
		}

		void HandleStateIdle(ent entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : IDLE", entity.id));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = this.Between(Tag.StateMove, Tag.StateAttack); });
		}

		void HandleStateMove(ent entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : MOVES", entity.id));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = Tag.StateIdle; });
		}

		void HandleStateAttack(ent entity)
		{
			Debug.Log(String.Format("Turret with ID {0} : ATTACKS", entity.id));
			Timer.Add(1.0f, () => { entity.ComponentTurret().state = Tag.StateIdle; });
		}

	}
}