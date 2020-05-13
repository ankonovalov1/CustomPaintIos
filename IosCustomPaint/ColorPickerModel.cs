using System;
using System.Collections.Generic;
using UIKit;

namespace IosCustomPaint
{
    public class ColorPickerModel : UIPickerViewModel
    {
        private List<string> _myItems;
        protected int selectedIndex = 0;

        public ColorPickerModel()
        {
            _myItems = new List<string>();
            _myItems.Add("Black");
            _myItems.Add("White");
            _myItems.Add("Red");
            _myItems.Add("Green");
            _myItems.Add("Blue");
            _myItems.Add("Gray");
        }

        public string SelectedItem
        {
            get { return _myItems[selectedIndex]; }
        }

        public override nint GetComponentCount(UIPickerView picker)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView picker, nint component)
        {
            return _myItems.Count;
        }

        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return _myItems[(int)row];
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            selectedIndex = (int)row;
            switch (selectedIndex)
            {
                case 0: CustomPaintView.Color = UIColor.Black;
                    break;
                case 1:
                    CustomPaintView.Color = UIColor.White;
                    break;
                case 2:
                    CustomPaintView.Color = UIColor.Red;
                    break;
                case 3:
                    CustomPaintView.Color = UIColor.Green;
                    break;
                case 4:
                    CustomPaintView.Color = UIColor.Blue;
                    break;
                case 5:
                    CustomPaintView.Color = UIColor.Gray;
                    break;
            }
            
        }
    }
}
