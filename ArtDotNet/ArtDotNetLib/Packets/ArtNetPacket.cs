using System;
using System.Net;
using System.Linq;
using System.Collections;

namespace ArtDotNet.Packets
{
	public abstract class ArtNetPacket : UdpPacket
	{
		readonly byte[] ARTNETID = { 0x41, 0x72, 0x74, 0x2d, 0x4e, 0x65, 0x74, 0 };

		public ArtNetPacket(IPEndPoint endPoint, byte[] data) : base(endPoint, data)
		{
		}

		public OpCode OpCode
		{
			get
			{
				return (OpCode)Data.GetInt16LE(8);
			}
		}

		public bool ValidArtNetPacket
		{
			get
			{
				return ARTNETID.SequenceEqual(Data.Block(0, ARTNETID.Length));
			}
		}
	}
}

