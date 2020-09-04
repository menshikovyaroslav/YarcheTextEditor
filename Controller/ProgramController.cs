using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YarcheTextEditor.Classes;
using YarcheTextEditor.Models;

namespace YarcheTextEditor.Controller
{
    public class ProgramController : INotifyPropertyChanged
    {
        public ILanguage Language { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProgramController()
        {
            Language = GetLanguage();

        }
        public void SetLanguage(string languageCode)
        {
            Language = LanguageMethods.GetLanguage(languageCode);

            OnPropertyChanged("Language");
            RegistryMethods.SetLanguage(Language.LanguageCode);
        }

        /// <summary>
        /// Get saved in options language or default language
        /// </summary>
        /// <returns></returns>
        public ILanguage GetLanguage()
        {
            return RegistryMethods.GetLanguage();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
