using System.Windows;
using System.Windows.Controls;
using YarcheTextEditor.Controller;
using YarcheTextEditor.Models;

namespace YarcheTextEditor
{
    public partial class MainWindow : Window
    {
        public ProgramController ProgramController = new ProgramController();
        public ILanguage CurrentLanguage { get { return ProgramController.Language; } }
        public MainWindow()
        {
       //     ProgramController = new ProgramController();

            InitializeComponent();

            LoadFileControl.MainWindow = this;
            WorkFileControl.MainWindow = this;
            ProgramController.MainWindow = this;
            DataContext = ProgramController;

        }

        private void SetLanguage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var languageCode = ((MenuItem)sender).Tag.ToString();
            ProgramController.SetLanguage(languageCode);
        }

        private void FileOpenMenuItemClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ProgramController.ChooseFile();
        }

        private void CloseProgram(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
