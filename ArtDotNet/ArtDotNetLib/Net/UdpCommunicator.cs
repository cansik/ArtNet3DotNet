using System;
using System.Net.Sockets;
using System.ComponentModel;
using System.Net;
using System.CodeDom.Compiler;

namespace ArtDotNet
{
	public class UdpCommunicator
	{
		public event EventHandler<UdpPacket> DataReceived;

		UdpClient socket;
		BackgroundWorker server;

		public UdpCommunicator()
		{
		}

		public void Start(IPAddress address, int port)
		{
			socket = new UdpClient();
			socket.EnableBroadcast = true;
			socket.ExclusiveAddressUse = false;
			socket.Client.SendTimeout = 100;
			socket.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
			socket.Client.Bind(new IPEndPoint(address, port));

			server = new BackgroundWorker();
			server.DoWork += Server_DoWork;
			server.RunWorkerAsync();
		}

		public void Stop()
		{
			server.CancelAsync();
			// server.CancelAsync();
			socket.Close();
		}

		public void Send(UdpPacket package)
		{
			socket.SendAsync(package.RawData, package.RawData.Length, package.EndPoint);
		}

		void Server_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!server.CancellationPending)
			{
				var client = new IPEndPoint(IPAddress.Any, 0);
				var data = socket.Receive(ref client);

				if (DataReceived != null)
					DataReceived(this, new UdpPacket(client, data));
			}
		}
	}
}

