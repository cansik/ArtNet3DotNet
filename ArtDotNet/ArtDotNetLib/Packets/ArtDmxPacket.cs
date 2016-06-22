using System;
using System.Net;

namespace ArtDotNet.Packets
{
	public class ArtDmxPacket : ArtNetPacket
	{
		public ArtDmxPacket(IPEndPoint endPoint, byte[] rawData) : base(endPoint, rawData) { }

		public ArtDmxPacket(ArtNetPacket packet) : base(packet.EndPoint, packet.RawData) { }

		/// <summary>
		/// The Sequence field is an 8-bit number that is designed to show the order in which packets were originated.
		/// </summary>
		/// <value>The sequence number.</value>
		public byte Sequence { get { return RawData[12]; } }

		/// <summary>
		/// The Physical field is an number that defines the physical port that generated the packet.
		/// </summary>
		/// <value>The physical field.</value>
		public byte Physical { get { return RawData[13]; } }

		/// <summary>
		/// Gets the sub uni.
		/// </summary>
		/// <value>The sub universe.</value>
		public byte SubUni { get { return RawData[14]; } }

		/// <summary>
		/// Gets the net.
		/// </summary>
		/// <value>The net.</value>
		public byte Net { get { return RawData[15]; } }

		/// <summary>
		/// The Length field defines the number of bytes encoded in the Data field.
		/// </summary>
		/// <value>The length of the Data field.</value>
		public int Length { get { return RawData.GetInt16(16); } }

		/// <summary>
		/// The Data field contains the data slot (channel levels). The size of this array is defined by the Length field.
		/// </summary>
		/// <value>The dmx data.</value>
		public byte[] Data { get { return RawData.Block(18, Length); } }
	}
}

