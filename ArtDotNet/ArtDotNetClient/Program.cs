using System;
using ArtDotNet;

namespace ArtDotNetClient
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("ArtDotNet Client");
			var controller = new ArtNetController ();
			controller.Start ();

			Console.ReadKey (true);

			controller.Stop ();
		}
	}
}
