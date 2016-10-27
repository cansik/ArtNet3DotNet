// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ArtNetViewer
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSView dataView { get; set; }

		[Outlet]
		AppKit.NSTextField interfaceText { get; set; }

		[Outlet]
		AppKit.NSButton startButton { get; set; }

		[Outlet]
		AppKit.NSTextField universeNumber { get; set; }

		[Action ("startClicked:")]
		partial void startClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (dataView != null) {
				dataView.Dispose ();
				dataView = null;
			}

			if (interfaceText != null) {
				interfaceText.Dispose ();
				interfaceText = null;
			}

			if (startButton != null) {
				startButton.Dispose ();
				startButton = null;
			}

			if (universeNumber != null) {
				universeNumber.Dispose ();
				universeNumber = null;
			}
		}
	}
}
