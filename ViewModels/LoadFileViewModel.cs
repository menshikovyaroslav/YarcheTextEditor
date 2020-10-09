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
    public class LoadFileViewModel : BaseViewModel
    {
        public ILanguage Language
        {
            get
            {
                return LanguageSettings.Language;
            }
        }

        public LoadFileViewModel()
        {
            LanguageSettings.LanguageChangedHandler += LanguageChangedHandler;
        }

        private void LanguageChangedHandler(object sender, LanguageEventArgs languageEventArgs)
        {
            OnPropertyChanged("Language");
        }
    }
}
