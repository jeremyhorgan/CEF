using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CefHost
{
    public partial class Form1 : Form
    {
        private WebView webView;

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
    }
}
