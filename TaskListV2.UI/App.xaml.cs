﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;
using Autofac;
using TaskListV2.UI.Startup;

namespace TaskListV2.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
