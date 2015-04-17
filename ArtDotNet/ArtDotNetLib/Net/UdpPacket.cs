using System;
using System.Net;

namespace ArtDotNet
{
	public class UdpPacket
	{
		public IPEndPoint EndPoint { get; private set; }

		public byte[] Data { get; private set; }

		public UdpPacket (IPEndPoint endPoint, byte[] data)
		{
			EndPoint = endPoint;
			Data = data;
		}
	}
}

