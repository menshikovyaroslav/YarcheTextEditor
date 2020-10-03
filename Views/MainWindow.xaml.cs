using System.Windows;

namespace YarcheTextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void AddMessage(string message)
        {
            WindowInformer.Items.Insert(0, message);
        }
    }
}
