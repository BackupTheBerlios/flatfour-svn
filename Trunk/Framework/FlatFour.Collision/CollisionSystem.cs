using System;
using System.Diagnostics;

namespace FlatFour.Collision
{
	class CollisionSystem
	{
		#region Setup and Shutdown

		static CollisionSystem()
		{
			Framework.Startup += new EventHandler(OnStartup);
			Framework.Shutdown += new EventHandler(OnShutdown);
		}

		/* Stub used by other subsystems that depend on this one to force it 
		 * to call its static constructor and initialize */
		public static void EnsureReady()
		{
		}

		private static void OnStartup(object sender, EventArgs e)
		{
			Trace.WriteLine("Starting collision subsystem");
			Trace.WriteLine("Collision subsystem started");
		}


		private static void OnShutdown(object sender, EventArgs e)
		{
			Trace.WriteLine("Stopping collision subsystem");
			Trace.WriteLine("Collision subsystem stopped");
		}

		#endregion
	}
}
