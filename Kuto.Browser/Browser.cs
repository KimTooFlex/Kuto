using CefSharp;
using CefSharp.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kuto.Browser
{
    public partial class Browser : Form
    {
        public Browser()
        {
            ////upgrade browser compatibility
            //var appName = System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe";

            //using (var Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true))
            //    Key.SetValue(appName, 99999, RegistryValueKind.DWord);

            InitializeComponent();


        }




        private void Browser_Shown(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
              

            var browser = new KutoBrowser("https://medeberiyaa.com/?s=cards", "Search Results for:");

            browser.OnComplete += (a, b) =>
            {
                 string html = a.Extract("Search Results for:", "</h1>").StripTags().ToString();
                 MessageBox.Show(html);
            };

            browser.OnError += (a, b) =>
            {

            };
        }

    }
}
