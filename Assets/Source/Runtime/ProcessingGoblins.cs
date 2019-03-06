//  Project : Actors-Examples
// Contacts : Pixeye - info@pixeye.games
//     Date : 2/20/2019 

using System;
using UnityEngine;

namespace Pixeye
{
	public class ProcessingGoblins : ProcessingBase, ITick
	{
		Group<ComponentViewGoblin, ComponentState> groupBrains;

		[GroupBy(Tag.StateAttack)]
		Group<ComponentViewGoblin, ComponentWeapon> groupAttack;

		[GroupBy(Tag.StateMove)]
		Group<ComponentViewGoblin, ComponentMove> groupMove;

		[GroupBy(Tag.StateIdle)]
		Group<ComponentViewGoblin> groupIdle;

		public ProcessingGoblins()
		{
			groupBrains.Add += entity =>
			{
				var cState = entity.ComponentState();
				cState.current = Tag.StateIdle;
			};

			groupIdle.Add += entity =>
			{
				var cState = entity.ComponentState();
				Timer.Add(1f, () => { cState.current = Tag.StateMove; });
				Debug.Log(String.Format("Goblin with id {0} is waiting !", entity));
			};

			groupMove.Add += entity =>
			{
				var сMove = entity.ComponentMove();
				сMove.distanceToTarget = 5;
			};

			groupAttack.Add += entity =>
			{
				var cWeapon = entity.ComponentWeapon();
				var cState  = entity.ComponentState();
				Debug.Log(String.Format("Goblin with id {0} performs an attack with mighty {1} !", entity, cWeapon.name));
				Timer.Add(1f, () => { cState.current = Tag.StateIdle; });
			};
		}

		public void Tick()
		{
			var frames = Time.frame;
			
			// process all entities that are defined in the groupBrains
			foreach (var entity in groupBrains)
			{
				var cState = entity.ComponentState();

				if (cState.current != cState.previous)
				{
					if (cState.previous != -1)
						entity.Remove(cState.previous);

					cState.previous = cState.current;
					entity.Add(cState.current);
				}
			}

			foreach (var entity in groupMove)
			{
				var сMove  = entity.ComponentMove();
				var cState = entity.ComponentState();
				if (frames % 20 == 0)
				{
					сMove.distanceToTarget = сMove.distanceToTarget.Minus(1);

					Debug.Log(String.Format("Goblin with id {0} moves to target. {1} meters left!", entity, сMove.distanceToTarget));

					if (сMove.distanceToTarget == 0) cState.current = Tag.StateAttack;
				}
			}
		}
	}
}