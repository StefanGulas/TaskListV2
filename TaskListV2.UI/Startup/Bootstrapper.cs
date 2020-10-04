using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<TaskListV2DataService>().As<ITaskListV2DataService>();

            return builder.Build();
        }
    }
}
