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
    /// Логика взаимодействия для LoadFileControl.xaml
    /// </summary>
    public partial class LoadFileControl : UserControl
    {
        public MainWindow MainWindow { get; set; }
        private ILanguage _language { get { return MainWindow.CurrentLanguage; } }
        private ProgramController _programController { get { return MainWindow.ProgramController; } }

        public LoadFileControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DataContext = _programController;
        }

        private void DropFile(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Supported one file for drop
            if (files != null && files.Length != 1)
            {
                MessageBox.Show(_language.OnlyOneFileSupported);
                return;
            }

            _programController.LoadFile(files[0]);
        }

        private void FileOpenClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _programController.ChooseFile();
        }

        private void UserControl_Initialized(object sender, EventArgs e)
        {
            
        }
    }
}
