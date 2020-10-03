using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.ViewModels
{
    public class LoadFileViewModel : INotifyPropertyChanged
    {
        public ILanguage Language { get { return Options.Language; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
