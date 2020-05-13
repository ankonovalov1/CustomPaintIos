// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace IosCustomPaint
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton clearBtn { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView colorPicker { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (clearBtn != null) {
                clearBtn.Dispose ();
                clearBtn = null;
            }

            if (colorPicker != null) {
                colorPicker.Dispose ();
                colorPicker = null;
            }
        }
    }
}