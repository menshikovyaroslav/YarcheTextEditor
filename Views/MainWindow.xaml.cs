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
            InitializeComponent();

            LoadFileControl.MainWindow = this;
            WorkFileControl.MainWindow = this;
            ProgramController.MainWindow = this;
            DataContext = ProgramController;
        }

        public void AddMessage(string message)
        {
            WindowInformer.Items.Insert(0, message);
        }
    }
}
