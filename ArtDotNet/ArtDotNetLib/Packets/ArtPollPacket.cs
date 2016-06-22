using System;
using ArtDotNet.Packets;
using System.Net;

namespace ArtDotNet.Packets
{
	public class ArtPollPacket : ArtNetPacket
	{
		public ArtPollPacket(IPEndPoint endPoint, byte[] rawData) : base(endPoint, rawData) { }

		public ArtPollPacket(ArtNetPacket packet) : base(packet.EndPoint, packet.RawData) { }

		/// <summary>
		/// The TalkToMe field is a single byte encoded as bit fields.
		/// The bit fields all control basic protocol behaviour of the node that receives the packet.
		/// </summary>
		/// <value>The talk to me field.</value>
		public byte TalkToMe { get { return RawData[12]; } }

		/// <summary>
		/// The Priority field specifies the minimum priority of diagnostics message that the controller wishes to receive.
		/// </summary>
		/// <value>The priority.</value>
		public byte Priority { get { return RawData[13]; } }
	}
}

