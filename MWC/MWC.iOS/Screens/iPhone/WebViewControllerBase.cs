using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MWC.iOS
{
	public class WebViewControllerBase : UIViewController
	{
		protected string basedir;
		protected UIWebView webView;
		/// <summary>
		/// Shared Css styles
		/// </summary>
		public string StyleHtmlSnippet
		{
			get 
			{  // http://jonraasch.com/blog/css-rounded-corners-in-all-browsers

				return "<style>" +
				"body {background-color:#eeeeee; }"+
				"body,b,i,p,h2{font-family:Helvetica;}" +
				"h1,h2{color:#222222;}" +
				"h1,h2{margin-bottom:0px;}" +
				".footnote{font-size:small;}" +
				".sessionspeaker{color:#333333;font-weight:bold;}" +
				".sessionroom{color:#666666;}" +
				".sessiontime{color:#666666;}" +
				".sessiontag{color:#444444;}" +
				"div.sessionspeaker { -webkit-border-radius:12px; background:white; width:285; color:black; padding:8 10 10 8;  }" +
				"a.sessionspeaker {color:black; text-decoration:none;}"+
				"</style>";

			}
		}
		public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
			
Console.WriteLine("NSBundle.MainBundle.BundlePath " + NSBundle.MainBundle.BundlePath);
Console.WriteLine("NSBundle.MainBundle.BundleUrl " + NSBundle.MainBundle.BundleUrl);

			basedir = NSBundle.MainBundle.BundlePath;
			// no XIB !
			webView = new UIWebView()
			{
				ScalesPageToFit = false,
			};
			LoadHtmlString(FormatText());
            webView.SizeToFit();
            webView.Frame = new RectangleF (0, 0, this.View.Frame.Width, this.View.Frame.Height-93);
            // Add the table view as a subview
            this.View.AddSubview(webView);
		}
		protected virtual string FormatText()
		{ return ""; }

		protected void LoadHtmlString (string s)
		{
			webView.LoadHtmlString(s, new NSUrl(basedir, true));
		}
	}
}
