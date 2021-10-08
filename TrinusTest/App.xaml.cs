using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrinusTest.ViewModels;

namespace TrinusTest
{
    /// <summary>
    /// Interação lógica para App.xaml
    /// </summary>
    public partial class App : Application
    {
        static public MainViewModel MainViewModel { get => (MainViewModel)Current.Resources["mainViewModel"]; }
    }
}
