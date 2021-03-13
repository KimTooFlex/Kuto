using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuto
{
    public partial class KutoBrowser : Form
    {
        ChromiumWebBrowser browser;
        private readonly string url;
        private readonly string triger=null;

        public delegate void KutoEventHandler(Kuto kuto, EventArgs e);
        public event KutoEventHandler OnComplete;
        public event EventHandler OnError;
        public KutoBrowser()
        {
            InitializeComponent();
        }

        public KutoBrowser(string url, string triger = null)
        {
            this.url = url;
            this.triger = triger;
            InitializeComponent();
            this.Show();
        }


        private async void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {

                var html = await browser.GetSourceAsync();
                if (this.triger==null)
                {
                    this.Invoke((Action)delegate
                        {
                            OnComplete?.Invoke(new Kuto(html), new EventArgs());
                            this.Close();
                        });
                }
            }
        }

        private void Browser_LoadError(object sender, LoadErrorEventArgs e)
        {

            this.Invoke((Action)delegate
            {
                OnError.Invoke(e.ErrorText, new EventArgs());
                this.Close();
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmrLoader.Stop();
            browser = new ChromiumWebBrowser(url);
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            browser.LoadError += Browser_LoadError;
            browser.LoadingStateChanged += Browser_LoadingStateChanged;

            tmrTrigger.Enabled = (triger != null);
        }

        private async void tmrTrigger_Tick(object sender, EventArgs e)
        {
            tmrTrigger.Stop();
            var html = await browser.GetSourceAsync();

            if (html.Contains(this.triger))
            {
                this.Invoke((Action)delegate
                  {
                      OnComplete?.Invoke(new Kuto( html), new EventArgs());
                      this.Close();
                      return;
                  });
            }
            else
            {
                tmrTrigger.Start();
            }
        }

        private void timeout_Tick(object sender, EventArgs e)
        {

            this.Invoke((Action)delegate
            {
                OnError.Invoke("Timeout", new EventArgs());
                this.Close();
            });
        }
    }
}
