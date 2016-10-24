using System;
using System.Net;
using ArtDotNet;

namespace ArtDotNetClient
{
	class MainClass
	{

		public static void Main(string[] args)
		{
			var subUni = 0;
			var running = true;

			Console.WriteLine("ArtDotNet Client");
			var controller = new ArtNetController();
			controller.Address = IPAddress.Loopback;

			controller.DmxPacketReceived += (s, p) =>
			{
				if (p.SubUni != subUni)
					return;

				Console.Clear();
				Console.WriteLine("ArtNet Universe " + subUni);

				for (int i = 0; i < p.Length; i++)
				{
					if (i % 24 == 0)
						Console.WriteLine();

					Console.Write(string.Format("{000:00} ", p.Data[i]));
				}
			};

			controller.Start();

			while (running)
			{
				var key = Console.ReadKey(true);

				if (key.Key == ConsoleKey.UpArrow)
					subUni++;

				if (key.Key == ConsoleKey.DownArrow)
					subUni--;

				if (key.Key == ConsoleKey.Escape)
					running = false;
			}

			controller.Stop();
		}
	}
}
