using CefHost.Models;
using CefSharp;
using CefSharp.WinForms;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CefHost
{
    public partial class Form1 : Form
    {
        private WebView webView;
        private SIMBA.StandardApplication app;
        private SIMBA.IWModel model;
        private IntPtr model2;

        public Form1()
        {
            InitializeComponent();

            var browserSettings = new BrowserSettings();
            browserSettings.FileAccessFromFileUrlsAllowed = true;
            browserSettings.UniversalAccessFromFileUrlsAllowed = true;
            browserSettings.TextAreaResizeDisabled = true;

            webView = new WebView(Path.Combine(GetViewDirectory(), "mainpage.html"), browserSettings)
            {
                Dock = DockStyle.Fill
            };

            app = new SIMBA.StandardApplication();
            var activation = (SIMBA.IWActivator)app;
            activation.Handle("2890A816-E915-4ffc-9379-6700720A1CC4");

            model = app.Model;            
            model.SyncLoad(@"C:\Users\Public\Documents\Lanner Group\WITNESS 14\Demo\En\Bells.mod", SIMBA.FileTypeEnum.FileTypeModel);

            // It would be better if we could pass the native model but does'n appear to work.
            // Perhaps because there is a RCW in between?
            webView.RegisterJsObject("model", new SimbaWrapper(model));

            Controls.Add(webView);
        }

        private string GetViewDirectory()
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase), "View");
        }

        private void button1_Click(object sender, System.EventArgs e)
        {            
        }

        private void viewDeveloperToolsMenuItem_Click(object sender, System.EventArgs e)
        {
            webView.ShowDevTools();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (app != null)
            {
                app.Quit();
            }
        }
    }
}
