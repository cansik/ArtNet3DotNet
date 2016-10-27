using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace ArtNetViewer
{
	public partial class DmxItemView : AppKit.NSView
	{
		int dataValue = 0;

		#region Constructors

		// Called when created from unmanaged code
		public DmxItemView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public DmxItemView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
		}

		public int DataValue
		{
			get
			{
				return dataValue;
			}
			set
			{
				dataValue = value;
				dataText.StringValue = dataValue.ToString();
			}
		}
	}
}
