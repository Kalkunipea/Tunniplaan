using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using HtmlAgilityPack;
using System;
using AngleSharp;

namespace Tunniplaan
{
    [Activity(Label = "Tunniplaan", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        WebView webView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            ryhmadList();
          
            SetContentView(Resource.Layout.Main);
            webView = FindViewById<WebView>(Resource.Id.webView1);
            webView.SetWebViewClient(new WebViewClient());
            webView.Settings.JavaScriptEnabled = true;
            Button g = FindViewById<Button>(Resource.Id.grupid);
            

            string data = "<body>" + "<img src=\"http://www.tptlive.ee/wp-content/uploads/2014/07/tpt_logo2.png\"/> </body>";

            webView.LoadData(data, "text/html", "UTF-8");
            // webView.LoadUrl("http://www.tptlive.ee/wp-content/uploads/2014/07/tpt_logo2.png");
            g.Click += delegate
            {
                webView.LoadUrl("https://tpt.siseveeb.ee/veebivormid/kiosk/tunniplaan?tyyp=grupid");
            };

      




        }


        public  void ryhmadList()
        {
            var document = new HtmlDocument();
            document.LoadHtml("https://tpt.siseveeb.ee/veebivormid/kiosk/tunniplaan?tyyp=grupid");
    
        }
    }
    
}

