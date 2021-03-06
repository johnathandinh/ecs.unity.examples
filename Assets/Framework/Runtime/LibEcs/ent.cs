//  Project : ecs
// Contacts : Pix - info@pixeye.games
//     Date : 3/16/2019 

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Pixeye.Framework
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Unicode)]
	public readonly struct ent : IComparable<int>, IComparable, IEquatable<ent>
	{

		internal static Queue<ent> entityStack = new Queue<ent>(0);
		internal static int entityStackLength;
		internal static int lastID;

		public readonly int id;
		internal readonly byte age;

		public ref readonly Transform transform => ref Entity.transforms[id];

		#region ENTITY

		public static EntityComposer Modify()
		{
			EntityComposer.Default.entity = default;
			return EntityComposer.Default;
		}

		public ent(int id = -1, byte age = 0)
		{
			this.id = id;
			this.age = age;
		}

		static public implicit operator int(ent value)
		{
			return value.id;
		}

		static public implicit operator ent(int value)
		{
			return new ent(value);
		}

		public static ent operator +(ent a, int b)
		{
			return new ent(a.id + b, a.age);
		}

		public static ent operator -(ent a, int b)
		{
			return new ent(a.id - b, a.age);
		}

		public int CompareTo(int value)
		{
			if (id < value)
				return -1;
			return id > value ? 1 : 0;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			return obj is ent other && Equals(other);
		}

		public bool Equals(int other)
		{
			return id == other;
		}

		public override int GetHashCode()
		{
			return age;
		}

		public int CompareTo(object obj)
		{
			ent other = (ent) obj;
			return id.CompareTo(other.id);
		}

		public bool Has<T>() where T : class, IComponent, new()
		{
			var id = Storage<T>.componentMask;
			return (Entity.generations[id, Storage<T>.generation] & id) == id;
		}

		public void Release()
		{
			Entity.isAlive[id] = false;
			Entity.Delayed.Set(this, 0, Entity.Delayed.Action.Kill);
			Entity.entitiesCount--;
		}

		public bool Equals(ent other)
		{
			return id == other.id && age == other.age;
		}

		public bool Exist()
		{
			return Entity.isAlive[id];
		}

		#endregion

		#region GET

		/// <summary>
		/// <para>Safely gets the component by type from the entity.</para>
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="arg0"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns>Returns true if the entity has this component.</returns>
		[Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks, false)]
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Get<T>(out T arg0) where T : class, IComponent, new()
		{
			return (arg0 = (Entity.generations[id, Storage<T>.generation] & Storage<T>.componentMask) == Storage<T>.componentMask ? Storage<T>.Instance.components[id] : default) != null;
		}

		/// <summary>
		/// <para>Safely gets the components by type from the entity.</para>
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Y"></typeparam>
		/// <returns>Returns true if the entity has these components.</returns>
		[Il2CppSetOption(Option.NullChecks | Option.ArrayBoundsChecks, false)]
		public bool Get<T, Y>(out T arg0, out Y arg1) where T : class, IComponent, new() where Y : class, IComponent, new()
		{
			arg0 = default;
			arg1 = default;
			if ((arg0 = Storage<T>.Instance.TryGet(id)) == null) return false;
			if ((arg1 = Storage<Y>.Instance.TryGet(id)) == null) return false;

			return true;
		}

		/// <summary>
		/// <para>Safely gets the components by type from the entity.</para>
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Y"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <returns>Returns true if the entity has these components.</returns>
		[Il2CppSetOption(Option.NullChecks, false)]
		public bool Get<T, Y, U>(out T arg0, out Y arg1, out U arg2) where T : class, IComponent, new() where Y : class, IComponent, new() where U : class, IComponent, new()
		{
			arg0 = default;
			arg1 = default;
			arg2 = default;
			if ((arg0 = Storage<T>.Instance.TryGet(id)) == null) return false;
			if ((arg1 = Storage<Y>.Instance.TryGet(id)) == null) return false;
			if ((arg2 = Storage<U>.Instance.TryGet(id)) == null) return false;

			return true;
		}

		/// <summary>
		/// <para>Safely gets the components by type from the entity.</para>
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Y"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <typeparam name="I"></typeparam>
		/// <returns>Returns true if the entity has these components.</returns>
		[Il2CppSetOption(Option.NullChecks, false)]
		public bool Get<T, Y, U, I>(out T arg0, out Y arg1, out U arg2, out I arg3) where T : class, IComponent, new() where Y : class, IComponent, new() where U : class, IComponent, new() where I : class, IComponent, new()
		{
			arg0 = default;
			arg1 = default;
			arg2 = default;
			arg3 = default;
			if ((arg0 = Storage<T>.Instance.TryGet(id)) == null) return false;
			if ((arg1 = Storage<Y>.Instance.TryGet(id)) == null) return false;
			if ((arg2 = Storage<U>.Instance.TryGet(id)) == null) return false;
			if ((arg3 = Storage<I>.Instance.TryGet(id)) == null) return false;
			return true;
		}

		/// <summary>
		/// Safely gets the components by type from the entity.
		/// </summary>
		/// <param name="entity"></param>
		/// <param name="arg0"></param>
		/// <param name="arg1"></param>
		/// <param name="arg2"></param>
		/// <param name="arg3"></param>
		/// <param name="arg4"></param>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="Y"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <typeparam name="I"></typeparam>
		/// <typeparam name="O"></typeparam>
		/// <returns>Returns true if the entity has these components.</returns>
		[Il2CppSetOption(Option.NullChecks, false)]
		public bool Get<T, Y, U, I, O>(out T arg0, out Y arg1, out U arg2, out I arg3, out O arg4) where T : class, IComponent, new()
				where Y : class, IComponent, new()
				where U : class, IComponent, new()
				where I : class, IComponent, new()
				where O : class, IComponent, new()
		{
			arg0 = default;
			arg1 = default;
			arg2 = default;
			arg3 = default;
			arg4 = default;
			if ((arg0 = Storage<T>.Instance.TryGet(id)) == null) return false;
			if ((arg1 = Storage<Y>.Instance.TryGet(id)) == null) return false;
			if ((arg2 = Storage<U>.Instance.TryGet(id)) == null) return false;
			if ((arg3 = Storage<I>.Instance.TryGet(id)) == null) return false;
			if ((arg4 = Storage<O>.Instance.TryGet(id)) == null) return false;
			return true;
		}

		#endregion

	}
}