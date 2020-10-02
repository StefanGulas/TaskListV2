using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskListV2.Model;

namespace TaskListV2.UI.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<Task> Tasks{ get; set; }
    }
}
