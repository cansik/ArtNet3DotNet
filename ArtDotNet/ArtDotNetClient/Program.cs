using System;
using System.Net;
using ArtDotNet;

namespace ArtDotNetClient
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("ArtDotNet Client");
			var controller = new ArtNetController();
			controller.Address = IPAddress.Loopback;
			controller.Start();

			Console.ReadKey(true);

			controller.Stop();
		}
	}
}
