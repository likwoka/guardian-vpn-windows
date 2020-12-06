// <copyright file="App.xaml.cs" company="Mozilla">
// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. If a copy of the MPL was not distributed with this file, you can obtain one at http://mozilla.org/MPL/2.0/.
// </copyright>

using System.Windows;
using System.Configuration;
using System.Windows.Interop;
using System.Windows.Media;


namespace FirefoxPrivateNetwork
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            // Ensure tunnel disconnect prior to exiting from the application.
            Manager.Tunnel.Disconnect();

            // Remove icon from the system tray.
            Manager.TrayIcon.Remove();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            bool.TryParse(ConfigurationManager.AppSettings["ForceSoftwareRendering"], out bool shouldRenderInSoftware);
            if (shouldRenderInSoftware)
            {
                RenderOptions.ProcessRenderMode = RenderMode.SoftwareOnly;
            }
            else
            {
                RenderOptions.ProcessRenderMode = RenderMode.Default;
            }

            if (!Manager.MainWindowViewModel.RanOnStartup)
            {
                var mainWindow = new UI.MainWindow();
                mainWindow.Show();
            }

            if (ProductConstants.IsDevMode)
            {
                UI.LogWindow.ShowLog(new Point(MainWindow.Left + MainWindow.Width, MainWindow.Top));
            }
        }
    }
}
