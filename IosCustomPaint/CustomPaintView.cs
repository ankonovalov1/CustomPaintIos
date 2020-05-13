using CoreGraphics;
using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UIKit;

namespace IosCustomPaint
{
    [DesignTimeVisible(true)]
    public partial class CustomPaintView : UIView, IComponent
    {        
        UIBezierPath currentPath;
        public static UIColor Color { get; set; }
        private CGPoint previousPoint;
        private List<VESLine> Lines;

        public CustomPaintView (IntPtr handle) : base (handle)
        {
            currentPath = new UIBezierPath();
            Lines = new List<VESLine>();
            Color = UIColor.Black;
        }

        public ISite Site { get ; set ; }

        public event EventHandler Disposed;

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            using (CGContext context = UIGraphics.GetCurrentContext())
            {                             

                foreach (var line in Lines)
                {
                    line.Color.SetStroke();
                    line.Path.Stroke();
                }                
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            previousPoint = touch.PreviousLocationInView(this);

            var path = new UIBezierPath
            {
                LineWidth = 5
            };

            var newPoint = touch.LocationInView(this);
            path.MoveTo(newPoint);
            InvokeOnMainThread(SetNeedsDisplay);
            currentPath = path;
            var line = new VESLine
            {
                Path = currentPath,
                Color = Color,                
            };

            Lines.Add(line);

        }
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            var currentPoint = touch.LocationInView(this);
            currentPoint = touch.LocationInView(this);
            if (Math.Abs(currentPoint.X - previousPoint.X) >= 4 ||
                Math.Abs(currentPoint.Y - previousPoint.Y) >= 4)
            {
                var newPoint = new CGPoint((currentPoint.X + previousPoint.X) / 2, (currentPoint.Y + previousPoint.Y) / 2);

                currentPath.AddQuadCurveToPoint(newPoint, previousPoint);
                previousPoint = currentPoint;
            }

            InvokeOnMainThread(SetNeedsDisplay);
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
            InvokeOnMainThread(SetNeedsDisplay);
        }
        
        public void Clear()
        {
            currentPath.Dispose();
            currentPath = new UIBezierPath();
            InvokeOnMainThread(SetNeedsDisplay);
        }

    }

    internal class VESLine
    {
        public UIBezierPath Path { get; set; }
        public UIColor Color { get; set; }        
    }
}