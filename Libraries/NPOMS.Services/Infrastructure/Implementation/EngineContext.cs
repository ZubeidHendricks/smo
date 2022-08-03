using NPOMS.Services.Infrastructure.Interfaces;

namespace NPOMS.Services.Infrastructure.Implementation
{
	/// <summary>
	/// Provides access to the singleton instance of the Nop engine.
	/// </summary>
	public class EngineContext
	{
		private static IEngine _engine;

		#region Methods

		/// <summary>
		/// Create a static instance of the Nop engine.
		/// </summary>
		// [MethodImpl(MethodImplOptions.Synchronized)]
		public static IEngine Create()
		{
			//create NopEngine as engine
			_engine = _engine ?? new AppEngine();
			return _engine;
		}

		/// <summary>
		/// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
		/// </summary>
		/// <param name="engine">The engine to use.</param>
		/// <remarks>Only use this method if you know what you're doing.</remarks>
		public static void Replace(IEngine engine)
		{
			_engine = engine;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets the singleton Nop engine used to access Nop services.
		/// </summary>
		public static IEngine Current
		{
			get
			{
				if (_engine == null)
				{
					Create();
				}

				return _engine;
			}
		}

		#endregion
	}
}
