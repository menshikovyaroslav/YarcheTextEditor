using System.Windows;
using System.Windows.Controls;
using YarcheTextEditor.Controller;

namespace YarcheTextEditor
{
    public partial class MainWindow : Window
    {
        public ProgramController _programController;
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
    }
}
