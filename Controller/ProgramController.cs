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
    public class ProgramController :INotifyPropertyChanged
    {
        public ILanguage _language { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProgramController()
        {
            _language = GetLanguage();

        }
        public void SetRussianLanguage()
        {
            _language = new RussianLanguage();
            UpdateLanguage();
        }

        public void SetEnglishLanguage()
        {
            _language = new EnglishLanguage();
            UpdateLanguage();
        }

        /// <summary>
        /// Fire language changed event for view and save chosen language in options
        /// </summary>
        private void UpdateLanguage()
        {
            OnPropertyChanged("_language");
            RegistryMethods.SetLanguage(_language.LanguageCode);
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
