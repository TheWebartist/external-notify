namespace ExternalNotify.Demos.Uwp
{
    using ExternalNotify.Demos.Uwp.Views;
    using Windows.ApplicationModel.Activation;
    using Windows.UI.ViewManagement;
    using Windows.UI;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// Demo application class
    /// </summary>
    public sealed partial class App : Application
    {
        #region Constructor

        /// <summary>
        /// Entry point
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        #endregion Constructor

        #region Application events

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            var rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
                AdaptTitleBarUI();
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(WebViewPage), e.Arguments);
                }

                Window.Current.Activate();
            }
        }

        #endregion Application events

        #region Private methods

        private void AdaptTitleBarUI()
        {
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Set active window colors
            titleBar.ForegroundColor = Colors.White;
            titleBar.BackgroundColor = Color.FromArgb(255, 64, 54, 179);
            titleBar.ButtonForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Color.FromArgb(255, 100, 94, 172);
            titleBar.ButtonHoverBackgroundColor = Color.FromArgb(44, 64, 54, 179);
            titleBar.ButtonPressedForegroundColor = Colors.Gray;
            titleBar.ButtonPressedBackgroundColor = Color.FromArgb(28, 64, 54, 179);

            // Set inactive window colors
            titleBar.InactiveForegroundColor = Colors.Gainsboro;
            titleBar.InactiveBackgroundColor = Color.FromArgb(255, 64, 54, 179);
            titleBar.ButtonInactiveForegroundColor = Colors.Gainsboro;
            titleBar.ButtonInactiveBackgroundColor = Color.FromArgb(255, 64, 54, 179);
        }

        #endregion Private methods
    }
}