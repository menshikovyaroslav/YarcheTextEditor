using System.Windows;
using System.Windows.Controls;
using YarcheTextEditor.Controller;
using YarcheTextEditor.Models;

namespace YarcheTextEditor
{
    public partial class MainWindow : Window
    {
        public ProgramController _programController;
        private ILanguage _language { get { return _programController.Language; } }
        public MainWindow()
        {
            _programController = new ProgramController();
            DataContext = _programController;

            InitializeComponent();
        }

        private void SetRussianLanguage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _programController.SetRussianLanguage();
            LanguageMenuCheckChanged(RuLanguageMenu);
        }

        private void SetEnglishLanguage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _programController.SetEnglishLanguage();
            LanguageMenuCheckChanged(EngLanguageMenu);
        }

        private void LanguageMenuCheckChanged(MenuItem selectedMenuItem)
        {
            foreach (MenuItem menuItem in LanguageMenu.Items)
            {
                menuItem.IsChecked = menuItem == selectedMenuItem;
            }
        }

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
    }
}
