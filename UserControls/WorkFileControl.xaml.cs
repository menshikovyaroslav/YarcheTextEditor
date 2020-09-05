using System;
using System.Collections.Generic;
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
using YarcheTextEditor.Controller;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.UserControls
{
    /// <summary>
    /// Логика взаимодействия для WorkFileControl.xaml
    /// </summary>
    public partial class WorkFileControl : UserControl
    {
        public MainWindow MainWindow { get; set; }
        private ILanguage _language { get { return MainWindow.CurrentLanguage; } }
        private ProgramController _programController { get { return MainWindow.ProgramController; } }

        public WorkFileControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _programController;
        }
    }
}
