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
	[Register ("DmxItemView")]
	partial class DmxItemView
	{
		[Outlet]
		AppKit.NSTextField dataText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (dataText != null) {
				dataText.Dispose ();
				dataText = null;
			}
		}
	}
}
