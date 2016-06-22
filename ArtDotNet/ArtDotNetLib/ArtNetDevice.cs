
using System;
using System.Net.Sockets;
using System.ComponentModel;
using System.Collections.Generic;
using System.Net;
using ArtDotNet.Packets;

namespace ArtDotNet
{
	public abstract class ArtNetDevice
	{
		public const int PORT = 6454;
		public const string BROADCAST = "255.255.255.255";
		public const string NAME = "ArtDotNetServer";

		public string Name { get; set; }

		public IPAddress Address { get; set; }

		public int Port { get; set; }

		UdpCommunicator communicator;

		public event EventHandler<ArtNetPacket> PacketReceived;

		public event EventHandler<ArtPollPacket> PollPacketReceived;

		public event EventHandler<ArtDmxPacket> DmxPacketReceived;

		public ArtNetDevice() : this(NAME)
		{

		}

		public ArtNetDevice(string name) : this(name, IPAddress.Any, PORT)
		{

		}

		public ArtNetDevice(string name, IPAddress address, int port)
		{
			Name = name;
			Address = address;
			Port = port;
		}

		public void Start()
		{
			communicator = new UdpCommunicator();
			communicator.DataReceived += Communicator_DataReceived;
			communicator.Start(Address, Port);
		}

		public void Stop()
		{
			communicator.Stop();
		}

		public void SendData()
		{

		}

		void Communicator_DataReceived(object sender, UdpPacket e)
		{
			var packet = new ArtNetPacket(e.EndPoint, e.RawData);
			if (packet.IsValid)
			{
				//Console.WriteLine("{0}: Code: {1} - {2}", e.EndPoint, packet.OpCode, e.RawData.Length);
				RoutePacket(packet);
			}
		}

		void RoutePacket(ArtNetPacket packet)
		{
			if (PacketReceived != null) PacketReceived(this, packet);

			switch (packet.OpCode)
			{
				case OpCode.OpPoll:
					if (PollPacketReceived != null) PollPacketReceived(this, new ArtPollPacket(packet));
					break;
				case OpCode.OpDmx:
					if (DmxPacketReceived != null) DmxPacketReceived(this, new ArtDmxPacket(packet));
					break;
			}
		}
	}
}

