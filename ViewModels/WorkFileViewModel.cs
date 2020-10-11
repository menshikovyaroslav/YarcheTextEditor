using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.ViewModels
{
    public class WorkFileViewModel : BaseViewModel
    {
        public static ObservableCollection<StringElement> TextCollection { get { return Collections.TextCollection; } }

        public WorkFileViewModel()
        {
            Collections.TextCollectionChangedHandler += TextCollectionChangedHandler;
        }

        private void TextCollectionChangedHandler(object sender, EventArgs EventArgs)
        {
            OnPropertyChanged("TextCollection");
        }
    }
}
