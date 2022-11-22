using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace FusionXExporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            var cmd = Environment.GetCommandLineArgs();
            
            OutputText.Text = cmd[2];
        }

        private void BuildBtn_OnClick(object sender, RoutedEventArgs e)
        {
            var ccnPath = Environment.GetCommandLineArgs()[1];
            var exePath = Environment.GetCommandLineArgs()[2];
            var newName = $"{Path.GetDirectoryName(exePath)}\\Application.ccn";
            if (File.Exists(newName))
            {
                File.Delete(newName);
            }
            File.Copy(ccnPath,newName);
            Environment.Exit(0);
            
            
        }
    }
}