using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace IosCustomPaint
{
    public partial class ViewController : UIViewController
    {
        CustomPaintView paintView;
        private List<UIButton> btnList;
        public ViewController(IntPtr handle) : base(handle)
        {
            btnList = new List<UIButton>();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            colorPicker.Model = new ColorPickerModel();
            
            clearBtn.TouchUpInside += ClearBtn_TouchUpInside;           

        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void ClearBtn_TouchUpInside(object sender, EventArgs e)
        {
            paintView.Clear();
        }
    }
}