//   Project : Battlecruiser3.0
//  Contacts : Pixeye - info@pixeye.games 
//      Date : 8/16/2018


namespace Pixeye
{
	public static class Tag
	{
		/// Tags are used to define object states.
		/// All tags are written to Tag class.
		/// A good practice is to use #region with the logical name of the state groups and showing what numbers are reserved for the states.
		/// Don't use the same numbers for different states!
		/// TagFieldAttribute allows to show state in the inspector. Just write down the category name

		#region STATES 0 - 1000

		[TagField(categoryName = "States")]
		public const int StateNone = -1;

		[TagField(categoryName = "States")]
		public const int StateIdle = 0;

		[TagField(categoryName = "States")]
		public const int StateAttack = 1;

		[TagField(categoryName = "States")]
		public const int StateMove = 2;

		#endregion
	}
}