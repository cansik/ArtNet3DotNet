using System;
using System.Net;
using System.Linq;
using System.Collections;

namespace ArtDotNet.Packets
{
	public class ArtNetPacket : UdpPacket
	{
		readonly byte[] ARTNETID = { 0x41, 0x72, 0x74, 0x2d, 0x4e, 0x65, 0x74, 0 };

		public ArtNetPacket(IPEndPoint endPoint, byte[] rawData) : base(endPoint, rawData) { }

		public ArtNetPacket(ArtNetPacket packet) : base(packet.EndPoint, packet.RawData) { }

		/// <summary>
		/// The OpCode identifies the packet type.
		/// </summary>
		/// <value>The op code.</value>
		public OpCode OpCode { get { return (OpCode)RawData.GetInt16LE(8); } }

		/// <summary>
		/// The ProtVer field identifies the version of the Art-Net protocol.
		/// </summary>
		/// <value>The protocol version.</value>
		public int ProtocolVersion { get { return RawData.GetInt16(10); } }

		/// <summary>
		/// Checks if the art net packet is valid.
		/// </summary>
		/// <value>Returns if the art net packet is valid.</value>
		public bool IsValid { get { return ARTNETID.SequenceEqual(RawData.Block(0, ARTNETID.Length)); } }
	}
}

