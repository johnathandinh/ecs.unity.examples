//  Project : ecs.examples
// Contacts : Pix - info@pixeye.games
//     Date : 3/7/2019 

using Pixeye.Framework;
using UnityEngine;
using Time = Pixeye.Framework.Time;

namespace Pixeye
{
	public class ProcessorCollisions : Processor, ITick
	{

		readonly Color colorIdle = new Color(90 / 255f, 1, 140 / 255f, 1);
		readonly Color colorAttack = new Color(1, 90 / 255f, 90 / 255f, 1);

		public Group<ComponentAlarm> group_alarm;
		public Group<ComponentMotion> group_motion;

		public void Tick()
		{
			var delta = Time.delta;

			foreach (var entity in group_alarm)
			{
				var cAlarm = entity.ComponentAlarm();
				var position = entity.transform.position;

				var target = position.Overlap2D(cAlarm.radius);

				if (target == cAlarm.target) continue;

				var renderer = entity.transform.GetComponent<SpriteRenderer>();
				renderer.color = target == -1 ? colorIdle : colorAttack;

				cAlarm.target = target;
			}

			foreach (var entity in group_motion)
			{
				var cMotion = entity.ComponentMotion();
				var transform = entity.transform;
				var position = transform.position;
				var direction = cMotion.direction;
				var x = position.x;

				if (x > 5 && direction == 1)
					direction = -1;
				else if (x < -5 && direction == -1)
					direction = 1;

				position.x += direction * cMotion.speed * delta;

				transform.position = position;
				cMotion.direction = direction;
			}
		}

	}

	public static class Phys
	{

		public static ent Overlap2D(this Vector3 position, float radius, int mask = 1 << 0)
		{
			var collider = Physics2D.OverlapCircle(position, radius, mask);

			if (collider == null) return new ent(-1);

			IEntity monoEntity;
			monoEntity = collider.GetComponentInParent<IEntity>();
			if (monoEntity == null) return new ent(-1);

			return monoEntity.GetEntity();
		}

	}
}