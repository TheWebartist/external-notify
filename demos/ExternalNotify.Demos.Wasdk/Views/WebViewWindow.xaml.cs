namespace ExternalNotify.Demos.Wasdk.Views
{
    using ExternalNotify.Demos.Uwp.Models;
    using Microsoft.UI;
    using Microsoft.UI.Windowing;
    using Microsoft.UI.Xaml;
    using Microsoft.UI.Xaml.Controls;
    using Microsoft.Web.WebView2.Core;
    using System;
    using System.Collections.ObjectModel;
    using Windows.ApplicationModel;
    using WinRT.Interop;

    /// <summary>
    /// Demo main page
    /// </summary>
    public sealed partial class WebViewWindow : Window
    {
        #region Constructor

        public WebViewWindow()
        {
            InitializeComponent();
            DemoWebView2.WebMessageReceived += OnDemoWebView2WebMessageReceived;
            TryAdaptTitleBar();
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

        private void TryAdaptTitleBar()
        {
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(WindowNative.GetWindowHandle(this));
            var appWindow = AppWindow.GetFromWindowId(wndId);
            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                var titleBar = appWindow.TitleBar;
                // Hide default title bar.
                titleBar.ExtendsContentIntoTitleBar = true;

                // Set active window colors
                titleBar.ForegroundColor = Colors.White;
                titleBar.BackgroundColor = Colors.Transparent;
                titleBar.ButtonForegroundColor = Colors.White;
                titleBar.ButtonBackgroundColor = Colors.SlateBlue;
                titleBar.ButtonHoverForegroundColor = Colors.Gainsboro;
                titleBar.ButtonHoverBackgroundColor = Colors.DarkSlateBlue;
                titleBar.ButtonPressedForegroundColor = Colors.Silver;
                titleBar.ButtonPressedBackgroundColor = Colors.DarkSlateBlue;

                // Set inactive window colors
                titleBar.InactiveForegroundColor = Colors.Gainsboro;
                titleBar.InactiveBackgroundColor = Colors.LightSteelBlue;
                titleBar.ButtonInactiveForegroundColor = Colors.Gainsboro;
                titleBar.ButtonInactiveBackgroundColor = Colors.LightSteelBlue;
            }
            else
            {
                // Title bar customization using these APIs is currently
                // supported only on Windows 11. In other cases, hide
                // the custom title bar element.
                AppTitleBar.Visibility = Visibility.Collapsed;
            }
        }

        #region Event handlers

        private void OnDemoWebView2WebMessageReceived(WebView2 sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            if (!string.IsNullOrWhiteSpace(args.WebMessageAsJson))
            {
                ReceivedMessages.Add(new ExternalNotifyDemoMessage { MessageType = "JSON", Value = args.WebMessageAsJson });
            }
            else
            {
                ReceivedMessages.Add(new ExternalNotifyDemoMessage { MessageType = "Raw", Value = args.TryGetWebMessageAsString() });
            }
        }

        #endregion Event handlers

        #endregion Private methods
    }
}