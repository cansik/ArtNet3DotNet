using System;
using ArtDotNet.Packets;
using System.Net;

namespace ArtDotNet.Packets
{
	public class ArtPollPacket : ArtNetPacket
	{
		public ArtPollPacket(IPEndPoint endPoint, byte[] data) : base(endPoint, data)
		{
		}

		public int ProtVerHi { get { return Data[10]; } }

		public int ProtVerLo { get { return Data[11]; } }

		public int TalkToMe { get { return Data[12]; } }

		public int Priority { get { return Data[13]; } }
	}
}

