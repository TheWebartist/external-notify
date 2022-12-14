namespace ExternalNotify.Demos.Wasdk
{
    using ExternalNotify.Demos.Wasdk.Views;
    using Microsoft.UI;
    using Microsoft.UI.Xaml;
    using Windows.UI;
    using Windows.UI.ViewManagement;

    /// <summary>
    /// Demo application class
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        private Window startWindow;

        #endregion Fields

        #region Constructor

        /// <summary>
        /// Entry point
        /// </summary>
        public App()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region Application events

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            startWindow = new WebViewWindow();
            startWindow.Activate();
        }

        #endregion Application events
    }
}