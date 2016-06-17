using System;
using ArtDotNet;

namespace ArtDotNetClient
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("ArtDotNet Client");
			var controller = new ArtNetController();
			controller.Address = System.Net.IPAddress.Parse("127.0.0.1");
			controller.Start();

			Console.ReadKey(true);

			controller.Stop();
		}
	}
}
