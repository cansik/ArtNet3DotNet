using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using AppKit;
using ArtDotNet;
using CoreGraphics;
using Foundation;

namespace ArtNetViewer
{
	public partial class ViewController : NSViewController
	{
		bool running = false;

		int currentUniverse = 0;

		ArtNetController artnet = new ArtNetController();

		NSTextField[] dataViews = new NSTextField[512];

		int[] values = new int[512];

		NSColor color = NSColor.FromRgb(41, 128, 185);

		public ViewController(IntPtr handle) : base(handle)
		{

		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			Title = "Bildspur ArtNet Viewer";

			startButton.Activated += StartButton_Activated;
			artnet.DmxPacketReceived += Artnet_DmxPacketReceived;
			universeNumber.Changed += (sender, e) => currentUniverse = universeNumber.IntValue;

			SetupDMXView();

			var worker = new BackgroundWorker();
			worker.DoWork += (sender, e) =>
			{
				while (true)
				{
					InvokeOnMainThread(() =>
					{
						for (int i = 0; i < dataViews.Length; i++)
						{
							dataViews[i].StringValue = values[i].ToString();
							dataViews[i].BackgroundColor = NSColor.FromRgba(color.RedComponent,
																			color.GreenComponent,
																			color.BlueComponent,
																			values[i] / 255.0f);
						}
					});
					Console.WriteLine("work work");
					Thread.Sleep(25);
				}
			};
			worker.RunWorkerAsync();
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		void SetupDMXView()
		{
			float textWidth = 35;
			float textHeight = 20;

			float width = (float)dataView.Frame.Width;
			float height = (float)dataView.Frame.Height;

			int itemsPerRow = (int)(width / textWidth);
			int heightIndex = 0;

			for (int i = 0; i < dataViews.Length; i++)
			{
				if (i % itemsPerRow == 0)
					heightIndex++;

				var view = new NSTextField();
				view.Alignment = NSTextAlignment.Center;
				view.SetFrameSize(new CGSize(textWidth, textHeight));
				view.StringValue = "0";
				view.Editable = false;
				view.Selectable = false;
				view.BackgroundColor = NSColor.FromRgba(color.RedComponent, color.GreenComponent, color.BlueComponent, 0);
				view.Bordered = false;

				float x = textWidth * (i % itemsPerRow);
				float y = height - (textHeight * heightIndex);

				view.SetFrameOrigin(new CGPoint(x, y));

				dataViews[i] = view;
				dataView.AddSubview(view);
			}
		}

		void StartButton_Activated(object sender, EventArgs e)
		{
			// handle button state
			if (running)
			{
				if (artnet != null)
					artnet.Stop();

				running = false;
				startButton.Title = "Start";
				interfaceText.Enabled = true;
			}
			else
			{
				running = true;
				startButton.Title = "Stop";
				interfaceText.Enabled = false;
			}

			// Artnet
			artnet.Address = IPAddress.Parse(interfaceText.StringValue);
			artnet.Start();
		}

		void Artnet_DmxPacketReceived(object sender, ArtDotNet.Packets.ArtDmxPacket e)
		{
			if (currentUniverse == e.SubUni)
			{
				for (int i = 0; i < e.Data.Length; i++)
				{
					values[i] = e.Data[i];
				}
			}
		}
	}
}
