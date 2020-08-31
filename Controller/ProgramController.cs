using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Controller
{
    public class ProgramController :INotifyPropertyChanged
    {
        public ILanguage _language { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProgramController()
        {
            _language = new EnglishLanguage();

        }
        public void SetRussianLanguage()
        {
            _language = new RussianLanguage();
            OnPropertyChanged("_language");
        }

        public void SetEnglishLanguage()
        {
            _language = new EnglishLanguage();
            OnPropertyChanged("_language");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
