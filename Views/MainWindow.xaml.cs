using System.Windows;
using System.Windows.Controls;
using YarcheTextEditor.Controller;
using YarcheTextEditor.Models;

namespace YarcheTextEditor
{
    public partial class MainWindow : Window
    {
        public ProgramController ProgramController;
        private ILanguage _language { get { return ProgramController.Language; } }
        public MainWindow()
        {
            ProgramController = new ProgramController();

            InitializeComponent();

            DataContext = ProgramController;
        }

        #region Change language

        private void SetLanguage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var languageCode = ((MenuItem)sender).Tag.ToString();
            ProgramController.SetLanguage(languageCode);
        }

        #endregion

        #region Load File

        private void DropFile(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Supported one file for drop
            if (files != null && files.Length != 1)
            {
                MessageBox.Show(_language.OnlyOneFileSupported);
                return;
            }

            LoadFile(files[0]);
        }

        private void LoadFile(string path)
        {
            MessageBox.Show(path);
        }

        private void TextBlock_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChooseFile();
        }

        private void ChooseFile()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog();
            var file = fileDialog.ShowDialog();
            if (file == false) return;

            LoadFile(fileDialog.FileName);
        }

        private void FileOpenMenuItemClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ChooseFile();
        }

        #endregion

        private void CloseProgram(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Close();
        }
    }
}
