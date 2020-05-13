// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace IosCustomPaint
{
    [Register ("CustomPaintView")]
    partial class CustomPaintView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView cPaintView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (cPaintView != null) {
                cPaintView.Dispose ();
                cPaintView = null;
            }
        }
    }
}