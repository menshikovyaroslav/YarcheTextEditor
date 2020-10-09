using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarcheTextEditor.ViewModels
{
    public class ViewModelLocator
    {
        private static MainViewModel _mainViewModel = new MainViewModel();
        private static LoadFileViewModel _loadFileViewModel = new LoadFileViewModel();

        public static MainViewModel MainViewModel { get { return _mainViewModel; } }
        public static LoadFileViewModel LoadFileViewModel { get { return _loadFileViewModel; } }
    }
}
