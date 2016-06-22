using System;
using System.Net;

namespace ArtDotNet.Packets
{
	public class ArtDmxPacket : ArtPollPacket
	{
		public ArtDmxPacket(IPEndPoint endPoint, byte[] data) : base(endPoint, data)
		{
		}
	}
}

