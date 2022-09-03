namespace ExternalNotify.Demos.Uwp.Views
{
    using ExternalNotify.Demos.Uwp.Models;
    using System;
    using System.Collections.ObjectModel;
    using Windows.ApplicationModel;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Demo main page
    /// </summary>
    public sealed partial class WebViewPage : Page
    {
        #region Constructor

        public WebViewPage()
        {
            InitializeComponent();
            DemoWebView.ScriptNotify += OnDemoWebViewScriptNotify;
            DemoWebView.Navigate(WebViewSourceUri);
        }

        #endregion Constructor

        #region Properties

        public readonly ObservableCollection<ExternalNotifyDemoMessage> ReceivedMessages = new ObservableCollection<ExternalNotifyDemoMessage>();

        public string Version
            => GetFormatedVersion();

        public Uri WebViewSourceUri
            => new Uri("https://externalnotify.netlify.app");

        #endregion Properties

        #region Private methods

        private string GetFormatedVersion()
        {
            var appVersion = Package.Current.Id.Version;
            return $"{appVersion.Major}.{appVersion.Minor}.{appVersion.Revision}";
        }

        private void OnDemoWebViewScriptNotify(object sender, NotifyEventArgs e)
        {
            ReceivedMessages.Add(new ExternalNotifyDemoMessage { MessageType = "Raw", Value = e.Value });
        }

        #endregion Private methods
    }
}