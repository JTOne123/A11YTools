﻿using A11YTools;
using A11YTools.iOS;
using A11YTools.Views;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AccessibilityContentView), typeof(AccessibilityContentViewRenderer))]
namespace A11YTools.iOS
{
    public class AccessibilityContentViewRenderer : ViewRenderer, IUIAccessibilityContainer
    {


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            this.SetAccessibilityElements(NSArray.FromNSObjects(this.GetAccessibilityElements()?.ToArray()));
        }


        AccessibilityContentView AccessibilityContentView => (AccessibilityContentView)Element;
        #region Accessibility

        private List<NSObject> GetAccessibilityElements()
        {
            var viewOrder = AccessibilityContentView.ViewOrder;

            List<NSObject> returnValue = new List<NSObject>();
            foreach(var view in viewOrder)
            {
                returnValue.Add(Platform.GetRenderer(view).NativeView);
            }

            return returnValue;
        }

        #endregion
    }
}