using nick_wpf_tools.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gei1076_tools.Views
{
    /// <summary>
    /// Interaction logic for SerialPortConfigurator.xaml
    /// </summary>
    public partial class SerialPortConfigurator : UserControl
    {
        public SerialPortConfigurator()
        {
            InitializeComponent();
            DataContext = new SerialPortViewModel();
        }
    }
}
